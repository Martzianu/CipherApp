using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace CipherApp.DataLayer.TableModule
{
    public class CipherHandler
    {
        public CipherTable getCiphers()
        {
            CipherTable table = new CipherTable();
            ConnectDB conDB = new ConnectDB();
            string query = "select Cifruri.id, titlu, descriere,link,Securitate,Algoritm,dbo.TipCifruri.Tip from Cifruri inner join dbo.TipCifruri on TipCifruri.id = Cifruri.TipCifru";
            SqlConnection connection = conDB.connection;
        
            try{
                connection.Open();
                 using(var comm = new SqlCommand(query,connection))
                 {
                     
                     var reader = comm.ExecuteReader();
                     
                     while (reader.Read())
                     {
                         Cipher cifru = new Cipher();
                         table.Add(cifru.setCipher(reader));
                     }
                     
                 }
            }
            catch(SqlException e)
            {
                string msg = e.Message;
            }
            return table;
        }
    }
}