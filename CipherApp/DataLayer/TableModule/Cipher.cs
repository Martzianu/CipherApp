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
        public string Security { get; set; }
        public string Algoritm { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public List<string> Texts { get; set; }
        public string Gif { get; set; }

        /*select Cifruri.id, 
        titlu, 
         * descriere,
         * link,
         * Securitate,
         * Algoritm 
         * TipCifruri from Cifruri inner join dbo.TipCifruri on TipCifruri.id = Cifruri.TipCifru*/
        public Cipher setCipher(SqlDataReader reader)
        {
            
            return new Cipher
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Description = reader.GetString(2),
                Link = reader.GetString(3),
                Security = reader.GetString(4),
                Algoritm = reader.GetString(5),
                Type = reader.GetString(6)
            };
        }
    }
}