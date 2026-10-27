using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer_DVLD_.clsApplications;

namespace BusinessLayer_DVLD_
{
    public class clsApplications
    {
        public enum enApplicationStatus { New = 1, Completed = 2, Canceled = 3 };
        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode = enMode.AddNew;

        public clsPeople PersonInfo;

        public clsUsers UserInfo;

        public clsApplicationTypes ApplicationTypeInfo;
        public int ApplicationID { get; private set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = new DateTime();
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.Canceled;
            this.LastStatusDate = new DateTime();
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        protected clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate
            , decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            PersonInfo = clsPeople.Find(ApplicantPersonID);
            UserInfo = clsUsers.FindByUserID(CreatedByUserID);
            ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);

            Mode = enMode.Update;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }

        public static clsApplications Find(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = new DateTime();
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = new DateTime();
            decimal PaidFees = 0;
            int CreatedByUserID = -1;

            if (clsApplicationsDataAccess.GetApplicationByApplicationID(ApplicationID, ref ApplicantPersonID,
               ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplications(ApplicationID, ApplicantPersonID,
                    ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return null;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDataAccess.AddNewApplication(this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate,
                this.PaidFees, this.CreatedByUserID);
        }

        protected bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateApplication();

            }
            return false;
        }

      
    }
}
