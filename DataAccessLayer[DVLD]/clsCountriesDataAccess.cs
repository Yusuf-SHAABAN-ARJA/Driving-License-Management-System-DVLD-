using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DVLD_
{
    public class clsCountriesDataAccess
    {
        static public DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Countries order by CountryName";

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

        static public string GetCountryNameByNationalCountryID(int NationalityCountryID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string CountryName = string.Empty;

            string Query = @"SELECT CountryName FROM Countries WHERE CountryID=@NationalityCountryID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if (temp != DBNull.Value)
                {
                    CountryName = temp.ToString();
                    
                }


            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                Connection.Close();
            }

            return CountryName;
            
        }

        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT CountryName FROM Countries WHERE CountryID=@ID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ID", ID);

            try
            {
                Connection.Open();

                object temp = Command.ExecuteScalar();

                if(temp!=DBNull.Value)
                {
                    CountryName = temp.ToString();
                    return true;
                }


            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();

            }
            return false;
        }

        public static bool GetCountryInfoByName(string CountryName,ref int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT CountryName FROM Countries WHERE CountryName=@CountryName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                object temp = Command.ExecuteScalar();

                if (temp != DBNull.Value)
                {
                    if(int.TryParse(temp.ToString(),out int result))
                    {
                        ID = result;
                        return true;
                    }                    
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();

            }
            return false;
        }
    }
}
