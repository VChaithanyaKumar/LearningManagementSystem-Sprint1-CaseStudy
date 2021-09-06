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
    public class LearnerRepository:ILearnerRepository
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

        public void CompleteCourse(User user, string CourseTitle)
        {
            try
            {
                command = new SqlCommand("CompleteCourse", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
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

        public void EnrollCourse(User user, Course course)
        {
            try
            {
                command = new SqlCommand("EnrollCourse", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                command.Parameters.AddWithValue("@CourseTitle", course.CourseTitle);
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
        public List<string> GetCompletedCourses(string UserEmail)
        {
            try
            {
                command = new SqlCommand("GetCompletedCourses", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                List<string> completedcourses = new List<string>();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        completedcourses.Add(dataReader["CourseTitle"].ToString());
                    }
                }
                return completedcourses;
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
        public List<string> GetEnrolledCourses(string UserEmail)
        {
            try
            {
                command = new SqlCommand("GetEnrolledCourses", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                List<string> completedcourses = new List<string>();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        completedcourses.Add(dataReader["CourseTitle"].ToString());
                    }
                }
                return completedcourses;
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



        public List<string> GetAnswers(string CourseTitle)
        {
            try
            {
                command = new SqlCommand("GetAnswers", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CourseTitle", CourseTitle);
                connection.Open();
                List<string> Answers = new List<string>();

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Answers.Add(dataReader["AnswerDescription"].ToString());
                    }
                }
                return Answers;
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

        public List<string> GetQuestions(string CourseTitle)
        {
            try
            {
                command = new SqlCommand("GetQuestions", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CourseTitle", CourseTitle);
                connection.Open();
                List<string> Questions = new List<string>();

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Questions.Add(dataReader["QuestionDescription"].ToString());
                    }
                }
                return Questions;
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

        public void StartTest(string UserEmail, string CourseTitle)
        {
            try
            {
                command = new SqlCommand("StartTest", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
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



        public void UpdateResult(string UserEmail, string CourseTitle, float Percentage)
        {
            command = new SqlCommand("Updateresult", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserEmail", UserEmail);
            command.Parameters.AddWithValue("@CourseTitle", CourseTitle);
            command.Parameters.AddWithValue("@Percentage", Percentage);
            connection.Open();
            command.ExecuteNonQuery(); try
            {

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

        public Result GetResult(User user, string CourseTitle)
        {
            try
            {
                Result result = null;
                command = new SqlCommand("GetResult", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                command.Parameters.AddWithValue("@CourseTitle", CourseTitle);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    result = new Result()
                    {
                        ResultDescription = (double)dataReader["ResultDescription"]
                    };
                    return result;
                }
                return result;
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
        public User GetUserDetails(string UserEmail)
        {
            try
            {
                User user = null;
                command = new SqlCommand("GetUserDetails", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    user = new User()
                    {
                        UserFirstName = dataReader["UserFirstName"].ToString(),
                        UserLastName = dataReader["UserLastName"].ToString(),
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
