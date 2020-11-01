using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activity1Part3.Models;
using System.Data.SqlClient;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user) {
            string conncectionString = "Data Source=DESKTOP-BEPLE8D;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = @"SELECT * FROM dbo.Users WHERE dbo.Users.USERNAME = " + "'" + user.Username + "'";
            bool results = false;
            using ( SqlConnection connection = new SqlConnection(conncectionString))
            {
                try
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string foo = reader.GetString(1);
                            if (reader.GetString(1).Equals(user.Username))
                            {
                                results = true;
                            }
                        }
                    }

                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return results;
        }
    }
}