using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DataAccessLayer_DVLD_
{
    public class clsTestsDataAccess
    {
        public static DataTable GetAllTests()
        {
            DataTable AllTests = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Tests;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllTests.Load(Reader);

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllTests;
        }

        public static bool GetTestByTestID(int TestID,ref int TestAppointmentID,ref byte TestResult,ref string Notes,ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Tests WHERE TestID=@TestID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (byte)Reader["TestResult"];

                    if (Reader["Notes"] == null)
                        Notes = string.Empty;
                    else
                        Notes = (string)Reader["Notes"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                }


                Reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool GetTestByTestAppointmentID(int TestAppointmentID, ref int TestID, ref byte TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Tests WHERE TestAppointmentID=@TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestID = (int)Reader["TestID"];
                    TestResult = (byte)Reader["TestResult"];

                    if (Reader["Notes"] == null)
                        Notes = string.Empty;
                    else
                        Notes = (string)Reader["Notes"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                }


                Reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static byte GetNumberOfPassedTestsByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            byte NumberOfPassedTests = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select PassedTests=Count(Tests.TestID) from 
                             Tests inner join TestAppointments 
                             on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
                             where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                             and Tests.TestResult=1;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null && int.TryParse(temp.ToString(), out int result))
                    NumberOfPassedTests = (byte)result;


            }
            catch
            {
                
            }
            finally
            {
                Connection.Close();
            }

            return NumberOfPassedTests;
        }

        public static int AddNewTest(int TestAppointmentID, byte TestResult,string Notes,int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Tests
                  (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                   VALUES (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID)
                   SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);

            if(string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", Notes);

            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null && int.TryParse(temp.ToString(), out int InsertedTestID))
                    TestID = InsertedTestID;
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }

        public static bool UpdateTest(int TestID,int TestAppointmentID, byte TestResult, string Notes, int CreatedByUserID)
        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Tests
                             SET  TestAppointmentID =@TestAppointmentID
                             , TestResult =@TestResult
                             , Notes =@Notes
                             , CreatedByUserID =@CreatedByUserID
                               WHERE TestID=@TestID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);

            if (string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", Notes);


            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
           



            try
            {
                Connection.Open();

                NumberOfRowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return (NumberOfRowsAffected > 0);
        }

        public static bool DeleteTestTest(int TestID)
        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM  Tests WHERE TestID=@TestID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);


            try
            {
                Connection.Open();

                NumberOfRowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return (NumberOfRowsAffected > 0);
        }

        public static int GetNumberOfTrial(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            int NumberOfTrials = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select Count(TestID) from 
                             TestAppointments  inner join Tests
                             on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
                              where TestAppointments.LocalDrivingLicenseApplicationID=36 
                             and  TestAppointments.TestTypeID=1 and Tests.TestResult=0;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

           

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null && int.TryParse(temp.ToString(), out int result))
                    NumberOfTrials = result;
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return NumberOfTrials;
        }

        public static bool IsPassedTest(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            bool IsPassed = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select passed=1 
                             from Tests Inner join TestAppointments 
                             on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
                             where 
                             TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                             and
                             Tests.TestResult=1 
                             and 
                             TestAppointments.TestTypeID=@TestTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null)
                    IsPassed = true;
            }
            catch
            {
                IsPassed = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsPassed;
        }
    }
}
