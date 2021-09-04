﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
        public void EnrollCourse(string UserEmail, string CourseTitle)
        {
            try
            {
                command = new SqlCommand("EnrollCourse", connection)
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

    }
}
