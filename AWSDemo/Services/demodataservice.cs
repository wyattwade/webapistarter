using AWSDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AWSDemo.Services
{
    public class demodataservice
    {
        public List<DemoMessage> GetAllMessages()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDbConnection"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "GetAllMessages";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var results = new List<DemoMessage>();

                    while (reader.Read())
                    {
                        results.Add(new DemoMessage
                        {
                            Id = (int)reader["id"],
                            Message = (string)reader["message"]
                        });
                    }
                    return results;

                }
            }

        }
    }
}
