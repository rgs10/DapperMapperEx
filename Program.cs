using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Linq;
using Dapper;
using Dapper.FluentColumnMapping;
using static Dapper.SqlMapper;

namespace DapperMapperExp
{
    class Program
    {
        static void Main(string[] args)
        {


            //using (var command = new SqlCommand("pCustomPublicHolidays", (SqlConnection) db)
            //using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            //{
            //    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            //    {
            //        cmd.CommandText = "pCustomPublicHolidays";
            //        cmd.Connection = conn;
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        conn.Open();

            //        System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);

            //        DataSet ds = new DataSet();
            //        adapter.Fill(ds);

            //        conn.Close();
            //    }
            //}

            SetupDapperMappings();

            IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var grid = connection.QueryMultiple("pCustomPublicHolidays", commandType: CommandType.StoredProcedure);

            var customPublicHolidayList = grid.Read<AnnualHoliday>().ToList();
            var customPublicHolidayDayList = grid.Read<Day>().ToList();

            customPublicHolidayList = grid.MapChild(
                customPublicHolidayList,
                customPublicHolidayDayList,
                customPublicHoliday => customPublicHoliday.Ref,
                customPublicHolidayDay => customPublicHolidayDay.CustomPublicHolidayRef,
                (customPublicHoliday, customPublicHolidayDay) =>
                {
                    customPublicHoliday.CustomPublicHolidayDays = customPublicHolidayDay.ToList();
                }).ToList();
        }

        private static void SetupDapperMappings()
        {
            var mappings = new ColumnMappingCollection();

            mappings.RegisterType<Day>()
                .MapProperty(x => x.Ref).ToColumn("CustomPublicHolidayDayRef")
                .MapProperty(x => x.Name).ToColumn("HolidayDayName")
                .MapProperty(x => x.Date).ToColumn("HolidayDate");

            mappings.RegisterType<AnnualHoliday>()
                .MapProperty(x => x.Ref).ToColumn("CustomPublicHolidayRef")
                .MapProperty(x => x.HolidayGroupName).ToColumn("CustomPublicHolidayName");


            mappings.RegisterWithDapper();
        }
    }

    public static class DapperHelper
    {
        public static IEnumerable<TFirst> MapChild<TFirst, TSecond, TKey>(
             this GridReader reader,
             List<TFirst> parent,
             List<TSecond> child,
             Func<TFirst, TKey> firstKey,
             Func<TSecond, TKey> secondKey,
             Action<TFirst, IEnumerable<TSecond>> addChildren)
        {
            var childMap = child.GroupBy(secondKey).ToDictionary(g => g.Key, g => g.AsEnumerable());
            foreach (var item in parent)
            {
                IEnumerable<TSecond> children;
                if (childMap.TryGetValue(firstKey(item), out children))
                {
                    addChildren(item, children);
                }
            }
            return parent;
        }
    }
}
