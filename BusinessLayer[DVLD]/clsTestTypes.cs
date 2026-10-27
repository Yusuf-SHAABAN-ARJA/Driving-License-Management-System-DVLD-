using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public enTestType TestTypeID { get; set; }

        //public int TestTypeID { get; private set; } // enum is readable more than integer because maybe I'll have 100 test types in the future.
        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestTypes()
        {
            this.TestTypeID = clsTestTypes.enTestType.VisionTest;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
            Mode = enMode.AddNew;
        }

        private clsTestTypes(clsTestTypes.enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }

        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {
            string TestTypeTitle = string.Empty;
            string TestTypeDescription = string.Empty;
            decimal TestTypeFees = 0;

            if (clsTestTypesDataAccess.GetTestTypeInfoByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

            return null;
        }

        private bool _AddNewTestType()
        {
            this.TestTypeID = (clsTestTypes.enTestType)clsTestTypesDataAccess.AddNewTestType(this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);

            return ((int)this.TestTypeID != -1);
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
    }
}
