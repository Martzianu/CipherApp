using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CipherApp.DataLayer.TableModule
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool? isProf { get; set; }
        public int Score { get; set; }

        public User setUser(SqlDataReader reader)
        {
            return new User{
            id = reader.GetInt32(0),
            username = reader.GetString(1),
            password = reader.GetString(2),
            email = reader.GetString(3),
            isProf = reader.GetBoolean(4),
            Score = reader.GetInt32(5)
            };
            

        }
    }
}