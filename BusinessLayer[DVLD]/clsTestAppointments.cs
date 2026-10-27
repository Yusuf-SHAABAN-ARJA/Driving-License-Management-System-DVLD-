using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsTestAppointments
    {
        public int TestAppointmentID { get; private set; }
        public byte TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsUsers CreatedUserInfo;

        public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplicationInfo;

        public clsTestTypes TestTypeInfo;

        public enum enMode { AddNew=1,Update=2};

        public enMode Mode;

        public clsTestAppointments()
        {
            TestAppointmentID = -1;
            TestTypeID = 0;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = new DateTime();
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;
        }

        private clsTestAppointments(int TestAppointmentID, byte TestTypeID,
            int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees,
            int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            CreatedUserInfo = clsUsers.FindByUserID(this.CreatedByUserID);
            LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplications.Find(this.LocalDrivingLicenseApplicationID);
            TestTypeInfo = clsTestTypes.Find((clsTestTypes.enTestType)this.TestTypeID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointments();
        }

        public static DataTable GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointmentsByLocalDrivingLicenseApplicationIDAndTestTypeID(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static DataTable GetAllTestAppointmentsByTestTypeID(byte TestTypeID)
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointmentsByTestTypeID(TestTypeID);
        }

        public clsTestAppointments FindByTestAppointmentID(int TestAppointmentID)
        {
            byte TestTypeID = 0;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = new DateTime();
            decimal PaidFees = -1;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if(clsTestAppointmentsDataAccess.GetTestAppointmentByTestAppointmentID(TestAppointmentID,ref TestTypeID,ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }

            return null;
        }

        public clsTestAppointments FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            byte TestTypeID = 0;
            int TestAppointmentID = -1;
            DateTime AppointmentDate = new DateTime();
            decimal PaidFees = -1;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (clsTestAppointmentsDataAccess.GetTestAppointmentByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID,
                ref TestAppointmentID,ref TestTypeID,ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }

            return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewTestAppointment(this.TestTypeID,
                this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID,
                this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsDataAccess.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID,
                 this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsDataAccess.DeleteTestAppointment(TestAppointmentID);
        }

        public static bool IsAppointmentActive(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            return clsTestAppointmentsDataAccess.IsAppointmentAcitveByLocalDrivingLicenseIDAndTestTypeID(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewTestAppointment())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                    }
                    break;
                case enMode.Update:
                    return _UpdateTestAppointment();
            }
            return false;
        }


    }
}
