using DataAccessLayer_DVLD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_DVLD_
{
    public class clsLicenseClasses
    {
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinimumAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        decimal ClassFees { get; set; }

        public clsLicenseClasses()
        {
            this.LicenseClassID = -1;
            this.ClassName = string.Empty;
            this.ClassDescription = string.Empty;
            this.MinimumAllowedAge = -1;
            this.DefaultValidityLength = -1;
            this.ClassFees = -1;
        }

        private clsLicenseClasses(int LicenseClassID,string ClassName,string ClassDescription,
            short MinimumAllowedAge,short DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static DataTable GetAllLicesneClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasses();
        }

        public static clsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            short MinimumAllowedAge = -1;
            short DefaultValidityLength = -1;
            decimal ClassFees = -1;

            if(clsLicenseClassesDataAccess.GetLicesneClassInfoByClassID(LicenseClassID,ref ClassName,
                ref ClassDescription,ref MinimumAllowedAge,ref DefaultValidityLength,ref ClassFees))
            {
                return new clsLicenseClasses(LicenseClassID,
                    ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }

            return null;
        }

    }
}
