using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//using System.Collections.Generic;
using LearningManagementSystem.Entities;
namespace LMS.DAL
{
    public class LoginRepository: ILoginRepository
    {
        //Connecting to Database--Praveena
        SqlConnection connection = new SqlConnection(@"Data Source=NAINACHINNA\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        SqlCommand command = null;
        public User GetLoginDetails(string userEmail)
        {
            try
            {
                User user = null;
                command = new SqlCommand("GetLoginDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", userEmail);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    user = new User()
                    {
                        UserType = dr["UserType"].ToString(),
                        UserEmail = dr["UserEmail"].ToString(),
                        UserPassword = dr["UserPassword"].ToString()
                    };
                }
                return user;

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
