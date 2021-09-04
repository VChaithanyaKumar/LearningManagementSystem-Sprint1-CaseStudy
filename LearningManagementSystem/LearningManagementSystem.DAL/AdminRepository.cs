using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using LearningManagementSystem.Entities;
namespace LMS.DAL
{
    public class AdminRepository: IAdminRepository
    {
        //Connecting to Database--Praveena
        SqlConnection connection = new SqlConnection(@"Data Source=NAINACHINNA\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        //Connecting to Database--SaiKiran
        //SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-P4UMIEHT\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        //Connecting to Database--Josy
        //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-N7MA7MU\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        //Connecting to Database--Chaitanya
        //SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-74GBGMH9\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        //Connecting to Database--Urjita
        //SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-V9LPMGA0\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        //Connecting to Database--Nimisha
        //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S7KB19C\SQLEXPRESS01;Initial Catalog=LearningManagementSystem;Integrated Security=True");

        SqlCommand command = null;
        public void UpdateUser(string UserEmail,string OldPassword,string NewPassword)
        {
            try
            {
                command = new SqlCommand("UpdatePassword", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                command.Parameters.AddWithValue("@UserOldPassword", OldPassword);
                command.Parameters.AddWithValue("@UserNewPassword", NewPassword);
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
        public void DeleteUser(string UserEmail)
        {
            try
            {
                command = new SqlCommand("DeleteUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
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
        public void DeleteCourse(string CourseTitle)
        {
            try
            {
                command = new SqlCommand("DeleteCourse", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CourseTitle", CourseTitle);
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
        //Assign Users to courses (Only incase if users are unable to register for the course.)
        public void AssignCourse(string UserEmail, string CourseTitle)
        {
            try
            {
                command = new SqlCommand("AssignCourse", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                command.Parameters.AddWithValue("@CourseTitle", CourseTitle);
                //command.Parameters.AddWithValue("@AssignCourseReturnMsg","out");
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
        public void UpdateCourseDescription(Course course)
        {
            try
            {
                command = new SqlCommand("UpdateCourseDescription", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CourseTitle", course.CourseTitle);
                command.Parameters.AddWithValue("@CourseDescription", course.CourseDescription);
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
        public void UpdateCourseOutComes(Course course)
        {
            try
            {
                command = new SqlCommand("UpdateCourseOutcome", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CourseTitle", course.CourseTitle);
                command.Parameters.AddWithValue("@CourseOutcomes", course.CourseOutcomes);
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
        //gets the Course Titles
        public List<string> GetCourseTitles()
        {
            try
            {
                command = new SqlCommand("GetCourseTitles", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<string> course = new List<string>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        course.Add(dr["CourseTitle"].ToString());
                    }

                }
                return course;
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
        public ArrayList CourseStatus(decimal UserId)
        {
            try
            {
                ArrayList courseStatus = null;
                command = new SqlCommand("CourseStatus", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", UserId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    courseStatus = new ArrayList();
                    while (reader.Read())
                    {
                        String status = reader["UserFirstName"].ToString() + "     " + reader["CourseTitle"].ToString() + "     " + reader["CourseStatus"].ToString();
                        courseStatus.Add(status);

                    }

                }
                return courseStatus;
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
        public ArrayList GenerateReport(string UserEmail)
        {
            try
            {
                ArrayList records = null;
                command = new SqlCommand("GenerateReport", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    records = new ArrayList();
                    while (reader.Read())
                    {
                        String report = reader["UserId"].ToString() + " " + reader["UserEmail"].ToString() + " " + reader["CourseId"].ToString() + " " + reader["CourseTitle"].ToString() + " " + reader["DateOfEnrollment"].ToString() + " " + reader["DateOfCompletion"].ToString() + " " + reader["CourseStatus"].ToString();
                        records.Add(report);

                    }

                }
                return records;
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
