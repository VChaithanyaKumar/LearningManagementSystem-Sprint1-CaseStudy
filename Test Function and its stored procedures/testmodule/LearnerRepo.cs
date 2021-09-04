using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace testmodule
{
    public class LearnerRepo : ILearnerRepo
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-P4UMIEHT\SQLEXPRESS;Initial Catalog=LearningManagementSystem;Integrated Security=True");
        SqlCommand command = null;
        public List<decimal> CompletedCourses(decimal UserId)
        {
            command = new SqlCommand("CompletedCourses", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", UserId);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            List<decimal> completedcourses = new List<decimal>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    completedcourses.Add((decimal)dataReader["CourseId"]);
                }
            }
            connection.Close();
            return completedcourses;
        }

        public List<decimal> CourseQuestion(decimal CourseId)
        {
            command = new SqlCommand("CourseQuestion",connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CourseId", CourseId);
            connection.Open();
            List<decimal> questionidlist = new List<decimal>();
            
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    questionidlist.Add((decimal)dataReader["QuestionId"]);
                }
            }
            connection.Close();
            return questionidlist;
        }

        public int CourseQuestionNo(decimal CourseId)
        {
            command = new SqlCommand("CourseQuestionNo", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CourseId", CourseId);
            connection.Open();
            int NoOfQuestions = (int)command.ExecuteScalar();
            connection.Close();
            return NoOfQuestions;
        }

        public string GetAnswer(decimal QuestionId)
        {
            command = new SqlCommand("GetAnswer", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@QuestionId", QuestionId);
            connection.Open();
            string Answer = (string)command.ExecuteScalar();
            connection.Close();
            return Answer;
        }

        public string GetQuestion(decimal QuestionId)
        {
            command = new SqlCommand("GetQuestion", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@QuestionId", QuestionId);
            connection.Open();
            string Question = (string)command.ExecuteScalar();
            connection.Close();
            return Question;
        }

        public void StartTest(decimal UserId, decimal CourseId)
        {
            command = new SqlCommand("StartTest", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@CourseId", CourseId);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        

        public void UpdateResult(decimal UserId,decimal CourseId,decimal Percentage)
        {
            command = new SqlCommand("Updateresult", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@CourseId", CourseId);
            command.Parameters.AddWithValue("@Percentage", Percentage);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
