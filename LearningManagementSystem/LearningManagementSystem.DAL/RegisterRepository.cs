using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LearningManagementSystem.Entities;

namespace LMS.DAL
{
    public class RegisterRepository : IRegisterRepository
    {
        //Connecting to Database--Praveena
        SqlConnection connection = new SqlConnection(@"Data Source=NAINACHINNA\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        SqlCommand command = null;

        public void AddingUser(User user)
        {

            try
            {
                command = new SqlCommand("Addinguser", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserType", user.UserType);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                command.Parameters.AddWithValue("@UserFirstName", user.UserFirstName);
                command.Parameters.AddWithValue("@UserLastName", user.UserLastName);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}