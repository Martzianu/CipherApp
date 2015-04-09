using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CipherApp.DataLayer
{
    public class ConnectDB
    {
        public SqlConnection connection { get; set; }
        private const String connectionString = @"Data Source=DRAGOS-PC\SQLEXPRESS;Initial Catalog=CypherApp;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public ConnectDB()
        {
            this.connection = new SqlConnection(connectionString);
        }

    }
}