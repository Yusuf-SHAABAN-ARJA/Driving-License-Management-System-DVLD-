using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DVLD_
{
    public class clsTestAppointmentsDataAccess
    {
        public static DataTable GetAllTestAppointments()
        {
            DataTable AllTestAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM TestAppointments;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllTestAppointments.Load(Reader);

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllTestAppointments;
        }

        public static DataTable GetAllTestAppointmentsByTestTypeID(byte TestTypeID)
        {
            DataTable AllTestAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM TestAppointments WHERE TestTypeID=@TestTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllTestAppointments.Load(Reader);

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllTestAppointments;
        }

        public static DataTable GetAllTestAppointmentsByLocalDrivingLicenseApplicationIDAndTestTypeID(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            DataTable AllTestAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments
                            WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                            AND TestTypeID=@TestTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllTestAppointments.Load(Reader);

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllTestAppointments;
        }

        public static bool GetTestAppointmentByTestAppointmentID(int TestAppointmentID,ref byte TestTypeID,
            ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,ref decimal PaidFees,
            ref int CreatedByUserID,ref bool IsLocked,ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID=@TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestTypeID = (byte)Reader["TestTypeID"]; 
                    LocalDrivingLicenseApplicationID= (int)Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsLocked = (bool)Reader["IsLocked"];

                    if (Reader["RetakeTestApplicationID"] == null)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"];

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

        public static bool GetTestAppointmentByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, ref int TestAppointmentID, ref byte TestTypeID,
            ref DateTime AppointmentDate, ref decimal PaidFees,
           ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM TestAppointments WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestTypeID = (byte)Reader["TestTypeID"];
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsLocked = (bool)Reader["IsLocked"];

                    if (Reader["RetakeTestApplicationID"] == null)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"];

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

        public static bool IsAppointmentAcitveByLocalDrivingLicenseIDAndTestTypeID(int LocalDrivingLicenseApplicationID,
            byte TestTypeID)
        {
            bool IsActive = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select Active=1 from 
                             TestAppointments where 
                              LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                             and TestTypeID=@TestTypeID
                             and IsLocked=0;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null)
                    IsActive = true;
            }
            catch
            {
                IsActive = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsActive;
        }

        public static int AddNewTestAppointment(byte TestTypeID,
             int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees,
             int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TestAppointments
                  (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                   VALUES (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestApplicationID)
                   SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null && int.TryParse(temp.ToString(), out int InsertedTestAppointmentID))
                    TestAppointmentID = InsertedTestAppointmentID;
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return TestAppointmentID;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, byte TestTypeID,
             int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees,
             int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE TestAppointments
                             SET TestTypeID =@TestTypeID
                             , LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID
                             , AppointmentDate =@AppointmentDate
                             , PaidFees =@PaidFees
                             , CreatedByUserID =@CreatedByUserID
                             , IsLocked =@IsLockec
                             , RetakeTestApplicationID =@RetakeTestApplicationID
                               WHERE TestAppointmentID=@TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);



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

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM  TestAppointments WHERE TestAppointmentID=@TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


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


    }
}
