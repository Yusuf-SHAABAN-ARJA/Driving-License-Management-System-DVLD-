using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DVLD_
{
    public  class clsTestTypesDataAccess
    {
        public static bool GetTestTypeInfoByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM TestTypes WHERE TestTypeID=@TestTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    TestTypeTitle = Reader["TestTypeTitle"].ToString();
                    TestTypeDescription = Reader["TestTypeDescription"].ToString();
                    TestTypeFees = (decimal)Reader["TestTypeFees"];
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

        public static DataTable GetAllTestTypes()
        {
            DataTable AllTestTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM TestTypes ORDER BY TestTypeTitle;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllTestTypes.Load(Reader);

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllTestTypes;
        }


        public static int AddNewTestType(string TestTypeTitle,string TestTypeDescription, decimal TestTypeFees)
        {
            int TestTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFees)
                            VALUES (@TestTypeTitle,@TestTypeDescription,@TestTypeFees)
                             SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);          
            Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != null & int.TryParse(temp.ToString(), out int InsertedTestTypeID))
                {
                    TestTypeID = InsertedTestTypeID;
                }
            }
            catch
            {
                TestTypeID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return TestTypeID;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int NumberOfRowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE TestTypes
                             SET TestTypeTitle=@TestTypeTitle,
                                 TestTypeDescription=@TestTypeDescription,
                                 TestTypeFees=@TestTypeFees
                                 WHERE TestTypeID=@TestTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

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
