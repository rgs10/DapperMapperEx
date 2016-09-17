using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Linq;
using Dapper;
using Dapper.FluentColumnMapping;

namespace DapperMapperExp
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetupDapperMappings();

            IDbConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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
}
