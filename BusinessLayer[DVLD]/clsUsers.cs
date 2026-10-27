using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsUsers
    {
        public enum enMode { AddNewMode=1,UpdateMode=2};
        public enMode Mode = enMode.AddNewMode;

        public int UserID { get; private set; }
        public int PersonID { get;  set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPeople PersonInfo;
        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            PersonInfo = null;

            Mode = enMode.AddNewMode;
        }

        private clsUsers(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            PersonInfo = clsPeople.Find(this.PersonID);

            Mode = enMode.UpdateMode;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);


            return (this.UserID != -1);
        }

        private bool _Update()
        {
            return clsUserDataAccess.UpdateUser(this.UserID,this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        public static clsUsers FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);

            return null;
        }

        public static clsUsers FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);

            return null;
        }

        public static clsUsers FindByUsernameAndPassword(string Username,string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if(clsUserDataAccess.GetUserInfoByUsernameAndPassword(Username, Password, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Username, Password, IsActive);
            }

            return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewUser())
                    {
                        this.Mode = enMode.UpdateMode;
                        return true;
                    }
                    break;
                case enMode.UpdateMode:
                    return _Update();
            }
            return false;
        }


        public static bool DeleteUser(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUserDataAccess.IsUserExistByPersonID(PersonID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserDataAccess.IsUserExist(UserName);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserDataAccess.IsUserExist(UserID);
        }



       
    }
}
