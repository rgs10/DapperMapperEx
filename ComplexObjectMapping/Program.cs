namespace ComplexObjectMapping
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    public class Program
    {
        const string sql = "select t.TeamRef as TeamId, " +
                           "t.TeamName as TeamName, " +
                           "p.PlayerRef as Players_PlayerId, " +
                           "p.TeamRef as Players_TeamId, " +
                           "p.PlayerName as Players_Name " +
                           "from Team t " +
                           "join Player p on t.TeamRef = p.TeamRef";

        private static string connectionString =
            @"Data Source=DESKTOP-89NPQR1\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

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
                    //Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Team), new List<string> { "TeamId" });
                    //Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Player), new List<string> { "PlayerId" });

                    var testTeam = (Slapper.AutoMapper.MapDynamic<Team>(test) as IEnumerable<Team>).ToList();

                    foreach (var c in testTeam)
                    {
                        foreach (var p in c.Players)
                        {
                            Console.Write("TeamName: {0}: TeamMember: {1}\n", c.TeamName, p.Name);
                        }
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
