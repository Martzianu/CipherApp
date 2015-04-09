using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CipherApp.DataLayer.TableModule
{
    public class Cipher
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Cipher setCipher(SqlDataReader reader)
        {
            return new Cipher
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Description = reader.GetString(2)
            };
        }
    }
}