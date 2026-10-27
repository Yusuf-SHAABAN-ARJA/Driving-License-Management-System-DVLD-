using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DVLD_
{
    public class clsApplicationtypesDataAccess
    {

        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID=@ApplicationTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    ApplicationTypeTitle = Reader["ApplicationTypeTitle"].ToString();
                    ApplicationFees = (decimal)Reader["ApplicationFees"];
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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable AllApplicationTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM ApplicationTypes ORDER BY ApplicationTypeTitle;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllApplicationTypes.Load(Reader);

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return AllApplicationTypes;
        }


        public static int AddNewApplicationType(string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int ApplicationTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            VALUES (@TestTypeTitle,@ApplicationFees)
                             SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if(temp!=null & int.TryParse(temp.ToString(),out int InsertedApplicationTypeID))
                {
                    ApplicationTypeID = InsertedApplicationTypeID;
                }
            }
            catch
            {
                ApplicationTypeID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationTypeID;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID,string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int NumberOfRowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE ApplicationTypes
                             SET ApplicationTypeTitle=@ApplicationTypeTitle,
                                 ApplicationFees=@ApplicationFees
                                 WHERE ApplicationTypeID=@ApplicationTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

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
