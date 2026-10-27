using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsTests
    {
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public enTestResult TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public enum enTestResult { Pass = 1, Fail = 2 };

        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode;

        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = enTestResult.Fail;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
        }

        private clsTests(int TestID,int TestAppointmentID,enTestResult TestResult,string Notes,int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static DataTable GetAllTests()
        {
            return clsTestsDataAccess.GetAllTests();
        }

        public static clsTests FindByTestID(int TestID)
        {
            int TestAppointmentID = -1;
            byte TestResult = 0;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if(clsTestsDataAccess.GetTestByTestID(TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, (enTestResult)TestResult, Notes, CreatedByUserID);
            }

            return null;
        }

        public static clsTests FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1;
            byte TestResult = 0;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestsDataAccess.GetTestByTestAppointmentID(TestAppointmentID, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, (enTestResult)TestResult, Notes, CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestsDataAccess.AddNewTest(this.TestAppointmentID, (byte)this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestsDataAccess.UpdateTest(this.TestID, this.TestAppointmentID, (byte)this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestsDataAccess.DeleteTestTest(TestAppointmentID);
        }

        public static byte GetNumberOfPassedTestsByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsDataAccess.GetNumberOfPassedTestsByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static int GetNumberOfTrials(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            return clsTestsDataAccess.GetNumberOfTrial(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsPassedTest(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {
            return clsTestsDataAccess.IsPassedTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTest())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                    }
                    break;
                case enMode.Update:
                    return _UpdateTest();
            }
            return false;
        }
    }
}
