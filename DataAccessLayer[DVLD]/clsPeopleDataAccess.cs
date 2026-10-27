using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DVLD_
{
    public class clsPeopleDataAccess
    {
        static public DataTable GetAllPeople() //Same Doctor Solution //done
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT People.PersonID, People.NationalNo,
                       People.FirstName, People.SecondName, People.ThirdName,
                        People.LastName,People.DateOfBirth, People.Gendor,
                           CASE
                        WHEN People.Gendor=0 THEN 'Male'
                         ELSE 'Female' 
                         END as GendorCaption,
                         People.Address, People.Phone ,People.Email ,People.NationalityCountryID,
                 Countries.CountryName ,People.ImagePath
                        FROM     People INNER JOIN
                  Countries ON People.NationalityCountryID = Countries.CountryID
                              ORDER BY People.FirstName;";



            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dt;
        }
        public static bool isPersonExist(int PersonID)  //done
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 1 FROM People WHERE People.PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                isFound = (temp != null && temp != DBNull.Value);


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static bool isPersonExist(string NationalNo)  //done
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 1 FROM People WHERE People.NationalNo = @NationalNo;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                isFound = (temp != null && temp != DBNull.Value);


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }


        static public int AddNewPerson(string FirstName,string SecondName,string ThirdName
            ,string LastName,string NationalNo,DateTime DateOfBirth,short Gendor,string Phone,string Email,int NationalityCountryID,string Address,string ImagePath)
        {
           
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int PersonID = -1;

            string Query = @"INSERT INTO People (FirstName,SecondName,ThirdName,LastName,NationalNo
,DateOfBirth,Gendor,Phone,Email,NationalityCountryID,Address,ImagePath)
VALUES(@FirstName,@SecondName,@ThirdName,@LastName,@NationalNo
,@DateOfBirth,@Gendor,@Phone,@Email,@NationalityCountryID,@Address,@ImagePath)
SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);


            if (string.IsNullOrEmpty(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);


            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            

            Command.Parameters.AddWithValue("@Phone", Phone);

            if(string.IsNullOrEmpty(Email))
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            if (string.IsNullOrEmpty(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);



            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if(Result!=null &&int.TryParse(Result.ToString(),out int insertedID))
                {
                    PersonID = insertedID;
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

        public static bool UpdatePreson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName
        , string NationalNo, DateTime DateOfBirth, short Gendor, string Phone, int NationalityCountryID, string Email, string Address, string ImagePath)
        {
            int NumberOfRowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE People SET FirstName =@FirstName,
                           SecondName = @SecondName,ThirdName = @ThirdName,LastName = @LastName,
                          NationalNo = @NationalNo,DateOfBirth = @DateOfBirth,
                          Gendor = @Gendor,Address = @Address,
                           Phone = @Phone, Email = @Email,NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath
                            WHERE PersonID=@PersonID;";


           

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Gendor", Gendor);


            Command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrEmpty(Email))
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            if (string.IsNullOrEmpty(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();

                NumberOfRowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (NumberOfRowsAffected > 0);
        }

        public static bool DeletePerson(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM People WHERE PersonID=@PersonID;";


            int NumberOfRowsAffected = 0;

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();

                NumberOfRowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (NumberOfRowsAffected) > 0;
        }






        public static bool GetPersonInfoByID(int PersonID,ref string FirstName,ref string SecondName, ref string ThirdName,ref string LastName
            ,ref string NationalNo,ref DateTime DateOfBirth,ref short Gendor,ref string Phone,ref int NationalityCountryID,ref string Email,ref string Address,ref string ImagePath )
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM People WHERE PersonID=@PersonID;";

            bool isFound = false;


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();

                    if (Reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)Reader["ThirdName"];
                    }
                    else
                        ThirdName = "";


                    LastName = Reader["LastName"].ToString();
                    NationalNo = Reader["NationalNo"].ToString();
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (byte)Reader["Gendor"];


                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["Email"]!=DBNull.Value)
                        Email = Reader["Email"].ToString();
                    else
                        Email = "";

                    Address = Reader["Address"].ToString();

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = Reader["ImagePath"].ToString();
                    else
                        ImagePath = "";

                    Phone = Reader["Phone"].ToString();


                    isFound = true;
                }
                else
                    isFound = false;

                Reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }


        public static bool GetPersonInfoByNationalNo(string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
         , ref int PersonID, ref DateTime DateOfBirth, ref short Gendor, ref string Phone, ref int NationalityCountryID, ref string Email, ref string Address, ref string ImagePath)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM People WHERE NationalNo=@NationalNo;";

            bool isFound = false;


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();

                    if (Reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)Reader["ThirdName"];
                    }
                    else
                        ThirdName = "";


                    LastName = Reader["LastName"].ToString();
                    PersonID = (int)Reader["PersonID"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (byte)Reader["Gendor"];


                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = Reader["Email"].ToString();
                    else
                        Email = "";

                    Address = Reader["Address"].ToString();

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = Reader["ImagePath"].ToString();
                    else
                        ImagePath = "";

                    Phone = Reader["Phone"].ToString();


                    isFound = true;
                }
                else
                    isFound = false;

                Reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

    }
}
