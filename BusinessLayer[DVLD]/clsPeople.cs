using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsPeople
    {

        public enum enMode { AddNewMode = 1, UpdateMode = 2 };
        public enMode Mode = enMode.AddNewMode;
        public int PersonID { get; private set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }

        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        private string _ImagePath;

        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }

        public int NationalityCountryID { get; set; }

        public clsCountries CountryInfo;
       
        public clsPeople()
        {
            this.PersonID = -1;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;  //done
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.NationalNo = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gendor = -1;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.NationalityCountryID = -1;
            CountryInfo = null;
            this.ImagePath = string.Empty;

            Mode = enMode.AddNewMode;
        }

        private clsPeople(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName
            , string NationalNo, DateTime DateOfBirth, short Gendor, string Phone, int NationalityCountryID, string Email, string Address, string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;  //done
            this.Gendor = Gendor;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.NationalityCountryID = NationalityCountryID;
            CountryInfo = clsCountries.Find(NationalityCountryID);
            this.ImagePath = ImagePath;

            Mode = enMode.UpdateMode;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor, this.Phone, this.Email, this.NationalityCountryID, this.Address, this.ImagePath);  //done

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.UpdatePreson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor, this.Phone, this.NationalityCountryID, this.Email, this.Address, this.ImagePath);  //done
        }


        public static clsPeople Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = -1;

            if (clsPeopleDataAccess.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName
                , ref NationalNo, ref DateOfBirth, ref Gendor, ref Phone, ref NationalityCountryID, ref Email, ref Address, ref ImagePath))  //done
            {
                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName
            , NationalNo, DateOfBirth, Gendor, Phone, NationalityCountryID, Email, Address, ImagePath);
            }
            else
                return null;


        }

        public static clsPeople Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = -1;
            int PersonID = -1;

            if (clsPeopleDataAccess.GetPersonInfoByNationalNo(NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName   //done
                , ref PersonID, ref DateOfBirth, ref Gendor, ref Phone, ref NationalityCountryID, ref Email, ref Address, ref ImagePath))
            {
                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName
            , NationalNo, DateOfBirth, Gendor, Phone, NationalityCountryID, Email, Address, ImagePath);
            }
            else
                return null;


        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.UpdateMode;  //done
                        return true;
                    }
                    else
                        return false;
                case enMode.UpdateMode:
                    return _UpdatePerson();



            }
            return false;
        }


        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople(); // same doctor solution  //done
        }

        public static bool isPersonExist(int PersonID)
        {
            return clsPeopleDataAccess.isPersonExist(PersonID);  //done
        }

        public static  bool isPersonExist(string NationalNo)
        {
            return clsPeopleDataAccess.isPersonExist(NationalNo);  //done
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);  //done
        }

       
    }
}
