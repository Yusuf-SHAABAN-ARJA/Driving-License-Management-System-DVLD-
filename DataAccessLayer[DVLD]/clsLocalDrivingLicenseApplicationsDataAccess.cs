using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer_DVLD_
{
    public class clsLocalDrivingLicenseApplicationsDataAccess
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable AllLocalDrivingLicenseApplications = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
                                LicenseClasses.ClassName, 
                                People.NationalNo,
                                 FullName=People.FirstName+' '+People.SecondName+' '+ISNULL(People.ThirdName,'')+' '+ People.LastName, 
                                  Applications.ApplicationDate,Status=Applications.ApplicationStatus, 
                                  StatusCaption = case when Applications.ApplicationStatus=1 then 
                                'New' when Applications.ApplicationStatus=2 then 'Completed' Else 'Cancelled' End,
                                  PassedTests=(SELECT Count(Tests.TestID) From Tests Left join TestAppointments 
                                  ON Tests.TestAppointmentID=TestAppointments.TestAppointmentID 
                                  where Tests.TestResult=1 and TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID)
                                         FROM     Applications INNER JOIN
                                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                                         LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                                         People ON Applications.ApplicantPersonID = People.PersonID ;";
                       


                                                                                                                 
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllLocalDrivingLicenseApplications.Load(Reader);
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllLocalDrivingLicenseApplications;
        }

        /// from here
        /// 
        public static bool GetLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID,
            ref int ApplicationID,ref int LicenseClassID,ref int ApplicantPersonID,
            ref DateTime ApplicationDate,ref byte ApplicationStatus,
            ref DateTime LastStatusDate,ref decimal PaidFees,ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT LocalDrivingLicenseApplications.*, Applications.*
                             FROM     Applications INNER JOIN
                             LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;


                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
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

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID,int LicenseClassID)
        {
            int InsertedLocalDrivingLicenseApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO LocalDrivingLicenseApplications
                             (ApplicationID, LicenseClassID)
                             VALUES (@ApplicationID,@LicenseClassID)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null && int.TryParse(temp.ToString(), out int result))
                    InsertedLocalDrivingLicenseApplicationID = result;


            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return InsertedLocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID,int ApplicationID, int LicenseClassID)

        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE LocalDrivingLicenseApplications
                            SET  ApplicationID = @ApplicationID
                                ,LicenseClassID =@LicenseClassID
                                WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            

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

        public static int IsLocalDrivingLicenseApplicationActiveByApplicantPersonIDForThisLicenseClass(int ApplicantPersonID,int LicenseClassID)
        {
            int ApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select Applications.ApplicationID from LocalDrivingLicenseApplications INNER JOIN 
                             Applications ON LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID
                            where Applications.ApplicantPersonID=@ApplicantPersonID and Applications.ApplicationStatus = 1
                             and LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID;";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();


                object temp = Command.ExecuteScalar();

                if (temp != null && int.TryParse(temp.ToString(), out int result))
                    ApplicationID = result;
                  

            }
            catch
            {
                ApplicationID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }

        public static bool IsLocalDrivingLicenseApplicationCompletedByApplicantPersonIDForThisLicenseClass(int ApplicantPersonID, int LicenseClassID)
        {
            bool isCompleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select Applications.ApplicationID from LocalDrivingLicenseApplications INNER JOIN 
                             Applications ON LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID
                            where Applications.ApplicantPersonID=@ApplicantPersonID and Applications.ApplicationStatus = 2
                             and LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID;";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();


                object temp = Command.ExecuteScalar();

                if (temp != null)
                    isCompleted = true;


            }
            catch
            {
                isCompleted = false;
            }
            finally
            {
                Connection.Close();
            }

            return isCompleted;
        }



        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM LocalDrivingLicenseApplications
                             WHERE  (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


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


        public static bool CancelLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int NumberOfRowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Applications
                              set Applications.ApplicationStatus=3
                              from Applications inner join LocalDrivingLicenseApplications 
                              on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
                              where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            


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

        public static int GetApplicationIDByLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID )
        {
              int ApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT ApplicationID FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            


            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if(temp!=null && int.TryParse(temp.ToString(),out int result))
                {
                    ApplicationID = result;
                }

            }
            catch
            {
                 ApplicationID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }
    }
}
