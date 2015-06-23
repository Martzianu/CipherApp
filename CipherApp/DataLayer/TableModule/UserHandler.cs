using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CipherApp.DataLayer.TableModule
{
    public class UserHandler
    {
        // pentru log in
        public bool LogIn(User user)
        {
            ConnectDB conDB = new ConnectDB();
            string query = "select * from dbo.users where username = @name and password=@pass";
            SqlConnection connection = conDB.connection;
            if (UserExists(user.username,user.email) == true)
                return false;
                try
                {
                    connection.Open();
                    using (var comm = new SqlCommand(query, connection))
                    {
                        comm.Parameters.AddWithValue("@name", user.username);
                        comm.Parameters.AddWithValue("@pass", user.password);

                        var reader = comm.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Constants.isProfLogged = (bool)reader["IsProf"];
                                Constants.mail = reader["Email"].ToString();
                                Constants.pass = reader["Password"].ToString();
                            }
                            if (Constants.isProfLogged == null)
                                Constants.isProfLogged = false;
                            return true;
                        }
                            
                        else return false;

                    }
                }
                catch (SqlException e)
                {
                    string msg = e.Message;
                    return false;
                }
            
            
        }

        private bool UserExists(string username, string email)
        {
            ConnectDB conDB = new ConnectDB();
            string query = "select * from dbo.users where email = @email or username = @user";
            SqlConnection connection = conDB.connection;

            try
            {
                connection.Open();
                using (var comm = new SqlCommand(query, connection))
                {
                    comm.Parameters.AddWithValue("@email", email);
                    comm.Parameters.AddWithValue("@user", username);

                    var reader = comm.ExecuteReader();

                    if (reader.HasRows)
                        return true;
                    else return false;

                }
            }
            catch (SqlException e)
            {
                string msg = e.Message;
                return false;
            }
            
            
        }

        public bool RegisterUser(User user)
        {
            ConnectDB conDB = new ConnectDB();
            string query = "insert into dbo.users (username,password,email,isProf) values(@user,@pass,@email,@prof)";
            if (UserExists(user.username, user.email))
                return false;
            try
            {
                SqlConnection connection = conDB.connection;
                
                    connection.Open();
                    using (var comm = new SqlCommand(query, connection))
                    {
                        comm.Parameters.AddWithValue("@user", user.username);
                        comm.Parameters.AddWithValue("@pass", user.password);
                        comm.Parameters.AddWithValue("@email", user.email);
                        comm.Parameters.AddWithValue("@prof", user.isProf);

                        comm.ExecuteNonQuery();
                        Constants.isProfLogged = user.isProf;
                        if (Constants.isProfLogged == null)
                            Constants.isProfLogged = false;
                        return true;
                    }
                
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return false;
            }
        }

        public void Update(string mail, string tableColumn)
        {
            ConnectDB conDB = new ConnectDB();
            string query = "Update users set "+ tableColumn + " =@mail where username = @name";
            SqlConnection connection = conDB.connection;
            try
            {
                connection.Open();
                using (var comm = new SqlCommand(query, connection))
                {
                    comm.Parameters.AddWithValue("@name", Constants.name);
                    comm.Parameters.AddWithValue("@mail", mail);

                    comm.ExecuteNonQuery();

                }
            }
            catch (SqlException e)
            {
                string msg = e.Message;

            }
            
        }
      
        public void updatePass(string pass)
        {

        }
    }

}
