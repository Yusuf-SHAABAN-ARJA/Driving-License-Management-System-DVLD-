using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsCountries
    {

        public int ID { get; private set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            ID = -1;
            CountryName = string.Empty;
        }
        private clsCountries(int ID,string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }


        public static clsCountries Find(int ID)
        {
            string CountryName = string.Empty;

            bool isFound = clsCountriesDataAccess.GetCountryInfoByID(ID, ref CountryName);

            if (isFound)
                return new clsCountries(ID, CountryName);
            else
                return null;
        }

        public static clsCountries Find(string CountryName)
        {
            int ID = -1;

            bool isFound = clsCountriesDataAccess.GetCountryInfoByName(CountryName,ref ID);

            if (isFound)
                return new clsCountries(ID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }

        public static string GetCountryNameByNationalCountryID(int NationalityCountryID)
        {
            return clsCountriesDataAccess.GetCountryNameByNationalCountryID(NationalityCountryID);
        }

    }
}
