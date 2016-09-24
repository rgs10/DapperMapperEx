using System.Configuration;
using System.Data;
using Dapper;
using DapperWrapper.Interfaces;

namespace ComplexObjectMapping
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var dapperMapperClass = new DapperSlapperExampleClass();
            var results1 = dapperMapperClass.GetResultsList();

            var multipleQueryClass = new MultipleQueryClass();
            var results2 = multipleQueryClass.GetResultsList();
        }
    }



    public class DapperSlapperExampleClass
    {
        public IList<Team> GetResultsList()
        {
            const string sql = "select t.TeamRef as TeamRef, " +
                           "t.TeamName as TeamName, " +
                           "p.PlayerRef as Players_PlayerRef, " +
                           "p.TeamRef as Players_TeamRef, " +
                           "p.PlayerName as Players_PlayerName " +
                           "from Team t " +
                           "left join Player p on t.TeamRef = p.TeamRef";

            var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

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
                    Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Team), new List<string> { "TeamRef" });
                    Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Player), new List<string> { "PlayerRef" });

                    var testTeam = (Slapper.AutoMapper.MapDynamic<Team>(test) as IEnumerable<Team>).ToList();

                    //foreach (var c in testTeam)
                    //{
                    //    foreach (var p in c.Players)
                    //    {
                    //        Console.Write("TeamName: {0}: TeamMember: {1}  PlayerRef: {2}\n", c.TeamName, p.PlayerName,
                    //            p.PlayerRef);
                    //    }
                    //}
                    //Console.ReadKey();
                    return testTeam;
                }
            }
        }
    }



    public class MultipleQueryClass
    {
        protected IDbExecutor dbExecutor;

        private static string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        /// <summary>
        /// Using single stored proc to get all results (two tables)
        /// and mapping using custom helper function
        /// </summary>
        /// <returns></returns>
        public IList<Team> GetResultsList()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var grid = conn.QueryMultiple("pGetAll", commandType: CommandType.StoredProcedure);
                var teamList = grid.Read<Team>().ToList();
                var playerList = grid.Read<Player>().ToList();
                
                teamList = grid.MapChild(
                    teamList,
                    playerList,
                    team => team.TeamRef,
                    player => player.TeamRef,
                    (team, player) => { team.Players = player.ToList(); }
                    ).ToList();

                return teamList;
            }
        }
    }
}