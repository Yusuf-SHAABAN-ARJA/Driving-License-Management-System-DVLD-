using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNew=0,Update=1};
        public enMode Mode = enMode.AddNew;

        public enum enApplicationTypes { NewLocalDrivingLicenseService=1,RenewDrivingLicenseService=2,
        ReplacementForALostDrivingLicense=3,ReplacementForADamagedDrivingLicense=4,ReleaseDetainedDrivingLicense=5,NewInternationalLicense=6,
        RetakeTest=7};

        public int ApplicationTypeID { get; private set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationTypes()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationFees = 0;
            Mode = enMode.AddNew;
        }

        private clsApplicationTypes(int ApplicationTypeID,string ApplicationTypeTitle,decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllApllicationTypes()
        {
            return clsApplicationtypesDataAccess.GetAllApplicationTypes();
        }

        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = string.Empty;
            decimal ApplicationFees = 0;

            if (clsApplicationtypesDataAccess.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);

            return null;
        }

        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = clsApplicationtypesDataAccess.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);

            return (this.ApplicationTypeID != -1);
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationtypesDataAccess.UpdateApplicationType(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }
    }
}
