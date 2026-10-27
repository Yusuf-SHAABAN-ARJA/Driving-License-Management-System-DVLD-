using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsLocalDrivingLicenseApplications :clsApplications 
    {
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClasses LicenseClassInfo;
        public clsLocalDrivingLicenseApplications() : base()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID,int ApplicationID
            ,int LicenseClassID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate
            , decimal PaidFees, int CreatedByUserID) : base(ApplicationID,ApplicantPersonID,ApplicationDate,
                (int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicenseService, ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;

            LicenseClassInfo = clsLicenseClasses.Find(this.LicenseClassID);
        }

        public static DataTable GelAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        public static clsLocalDrivingLicenseApplications Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = new DateTime();
            int ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicenseService;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = new DateTime();
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(
                LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID,
               ref ApplicantPersonID, ref ApplicationDate, ref ApplicationStatus,
               ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID,
                    ApplicationID, LicenseClassID, ApplicantPersonID, ApplicationDate,
                    ApplicationTypeID, (clsApplications.enApplicationStatus)ApplicationStatus, LastStatusDate,
                    PaidFees, CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddNewLocalDrivingLicenseApplication(
                this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }


        public static int IsLocalDrivingLicenseApplicationActiveByApplicantPersonIDForThisLicenseClass(int ApplicantPersonID,int LicenseClassID )
        {
            return
                clsLocalDrivingLicenseApplicationsDataAccess.IsLocalDrivingLicenseApplicationActiveByApplicantPersonIDForThisLicenseClass
                (ApplicantPersonID, LicenseClassID);
        }

        public static bool IsLocalDrivingLicenseApplicationCompletedByApplicantPersonIDForThisLicenseClass(int ApplicantPersonID, int LicenseClassID)
        {
            return
                clsLocalDrivingLicenseApplicationsDataAccess.IsLocalDrivingLicenseApplicationCompletedByApplicantPersonIDForThisLicenseClass
                (ApplicantPersonID, LicenseClassID);
        }

        public static bool CancelLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.CancelLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.GetApplicationIDByLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);

            if (ApplicationID != -1)
            {
                if (clsLocalDrivingLicenseApplicationsDataAccess.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID))
                {
                    return clsApplicationsDataAccess.DeleteApplication(ApplicationID);
                }
            }



            return false;

        }

        public bool Save()
        {
            if (base.Save())
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            Mode = enMode.Update;  //done
                            return true;
                        }
                        else
                            return false;
                    case enMode.Update:
                        return _UpdateLocalDrivingLicenseApplication();

                }
                return false;
            }
            return false;
        }

    }
}
