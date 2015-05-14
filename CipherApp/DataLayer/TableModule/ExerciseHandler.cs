using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CipherApp.DataLayer.TableModule
{
    public class ExerciseHandler
    {
        public bool AddExercise(Exercise ex)
        {
            ConnectDB conDB = new ConnectDB();
            string query = "Insert into dbo.Exercitii values(@privat, @detalii,@cifru,@textnormal, @textcriptat, @obligatoriu,@enunt)";
            SqlConnection connection = conDB.connection;          
                try
                {
                    connection.Open();
                    using (var comm = new SqlCommand(query, connection))
                    {
                        if(ex.Enunt == "" || ex.Enunt == null)
                        {
                            ex.Enunt = "Criptat/Decriptati textul cu cifrul selectat";
                        }
                        if(ex.TextCriptat == null)
                        {
                            ex.TextCriptat = "";
                        }
                        comm.Parameters.AddWithValue("@enunt", ex.Enunt);
                        comm.Parameters.AddWithValue("@privat", ex.Privat);
                        comm.Parameters.AddWithValue("@detalii",ex.Detalii);
                        comm.Parameters.AddWithValue("@textnormal", ex.TextNormal);
                        comm.Parameters.AddWithValue("@textcriptat", ex.TextCriptat);
                        comm.Parameters.AddWithValue("@cifru", ex.Cifru);
                        comm.Parameters.AddWithValue("@obligatoriu", ex.Obligatoriu);

                        comm.ExecuteNonQuery();
                       
                        return true;

                    }
                }
                catch (SqlException e)
                {
                    string msg = e.Message;
                    return false;
                }
        }

        public List<Exercise> GetExercicesForCipher(string cipher)
        {
            // returneaza toate exercitiile unui cifru
            List<Exercise> exercises = new List<Exercise>();
             ConnectDB conDB = new ConnectDB();
            string query = "Select * from dbo.Exercitii where cifru = @cipher";
            SqlConnection connection = conDB.connection;
            try
            {
                connection.Open();
                using (var comm = new SqlCommand(query, connection))
                {
                    comm.Parameters.AddWithValue("@cipher", cipher);
                    var reader = comm.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            Exercise ex = new Exercise();
                            ex.Enunt = reader[7].ToString();
                            ex.Privat = Boolean.Parse(reader[1].ToString());
                            ex.Detalii = reader[2].ToString();
                            ex.Cifru = reader[3].ToString();
                            ex.TextNormal = reader[4].ToString();
                            ex.TextCriptat = reader[5].ToString();
                            ex.Obligatoriu = Boolean.Parse(reader[6].ToString());
                            exercises.Add(ex);
                        }
                    else return null;
                }
                return exercises;
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return null;
            }
        }

        public List<Exercise> GetMandatoryExercices(bool mandatory)
        {
            // ia toate exercitiile obligatorii
            List<Exercise> exercises = new List<Exercise>();
            ConnectDB conDB = new ConnectDB();
            string query = "Select * from dbo.Exercitii where obligatoriu = @obligatoriu";
            SqlConnection connection = conDB.connection;
            try
            {
                connection.Open();
                using (var comm = new SqlCommand(query, connection))
                {
                    comm.Parameters.AddWithValue("@obligatoriu", mandatory);
                    var reader = comm.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            Exercise ex = new Exercise();
                            ex.Enunt = reader[7].ToString();
                            ex.Privat = Boolean.Parse(reader[1].ToString());
                            ex.Detalii = reader[2].ToString();
                            ex.Cifru = reader[3].ToString();
                            ex.TextNormal = reader[4].ToString();
                            ex.TextCriptat = reader[5].ToString();
                            ex.Obligatoriu = Boolean.Parse(reader[6].ToString());
                            exercises.Add(ex);
                        }
                    else return null;
                }
                return exercises;
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return null;
            }
        }
        
    }
}