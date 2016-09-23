using System.Data;
using System.Runtime.CompilerServices;
using Dapper;
using DapperWrapper.Interfaces;

namespace ComplexObjectMapping
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        

        const string sql = "select t.TeamRef as TeamRef, " +
                           "t.TeamName as TeamName, " +
                           "p.PlayerRef as Players_PlayerRef, " +
                           "p.TeamRef as Players_TeamRef, " +
                           "p.PlayerName as Players_Name " +
                           "from Team t " +
                           "join Player p on t.TeamRef = p.TeamRef";

        private static string connectionString =
            @"Data Source=LAPTOP-RSMITH\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void Main(string[] args)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                {
                    // Step 1: Use Dapper to return the  flat result as a Dynamic.
                    dynamic test = conn.Query<dynamic>(sql);
                    //Slapper.AutoMapper.Configuration.IdentifierConventions.Add(type => type.Name + "_Id");

                    // Step 2: Use Slapper.Automapper for mapping to the POCO Entities.
                    // - IMPORTANT: Let Slapper.Automapper know how to do the mapping;
                    //   let it know the primary key for each POCO.
                    // - Must also use underscore notation ("_") to name parameters;
                    ////see Slapper.Automapper docs.
                    //Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Team), new List<string> {"TeamRef"});
                    Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Player), new List<string> { "PlayerRef" });

                    var testTeam = (Slapper.AutoMapper.MapDynamic<Team>(test) as IEnumerable<Team>).ToList();

                    foreach (var c in testTeam)
                    {
                        foreach (var p in c.Players)
                        {
                            Console.Write("TeamName: {0}: TeamMember: {1}  PlayerRef: {2}\n", c.TeamName, p.Name,
                                p.PlayerRef);
                        }
                    }
                    Console.ReadKey();
                }
            }
        }
    }

    public class MultipleQueryClass
    {
        protected IDbExecutor dbExecutor;

        private static string connectionString =
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Database2;Integrated Security=True;Pooling=False;Connect Timeout=30";


        public void GetResultsList()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                //conn.QueryMultiple()

            }


            //var grid = this.dbExecutor.QueryMultiple("pCustomPublicHoliday", commandType: CommandType.StoredProcedure);
            //var customPublicHolidayList = grid.Read<CustomPublicHoliday>().ToList();
            //var customPublicHolidayDateList = grid.Read<CustomPublicHolidayDate>()?.ToList() ?? new List<CustomPublicHolidayDate>();

            //customPublicHolidayList = grid.MapChild(
            //    customPublicHolidayList,
            //    customPublicHolidayDateList,
            //    customPublicHoliday => customPublicHoliday.Ref,
            //    customPublicHolidayDate => customPublicHolidayDate.CustomPublicHolidayRef,
            //    (customPublicHoliday, customPublicHolidayDate) => { customPublicHoliday.CustomPublicHolidayDates = customPublicHolidayDate.ToList(); }
            //).ToList();

            //customPublicHolidayList.ForEach(p =>
            //{
            //    p.Dirty = false;
            //    p.CustomPublicHolidayDates?.ForEach(x => x.Dirty = false);
            //});

            //return customPublicHolidayList;


        }

        

    }
}


