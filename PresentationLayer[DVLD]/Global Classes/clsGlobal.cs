using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer_DVLD_;
using Microsoft.Win32;

namespace DVLD.Global_Classes
{
    internal class clsGlobal
    {

        public static clsUsers CurrentUser;
        public static void SaveCredentials(string Username,string Password)
        {
            string KeyPath = @"SOFTWARE\DVLD";

            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(KeyPath))
            {
                if(Key!=null)
                {
                    Key.SetValue("Username", Username);
                    Key.SetValue("Password", Password);
                }
            }
        }

        public static bool GetStoredCredentials(ref string Username,ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            Username = Registry.GetValue(keyPath, "Username", null) as string ;
            Password = Registry.GetValue(keyPath, "Password", null) as string;

            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
                return false;
            else
                return true;
        }

        public static void DeleteCredentials()
        {
            string keyPath = @"SOFTWARE\DVLD";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                   
                    key.DeleteValue("Username", false);
                    key.DeleteValue("Password", false);
                }
            }
        }
    }
}
