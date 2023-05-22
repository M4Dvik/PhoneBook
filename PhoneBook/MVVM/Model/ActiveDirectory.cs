using System;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing.Text;
using System.Security.Policy;

namespace PhoneBook.MVVM.Model
{
    public static class ActiveDirectory
    {

       public static SearchResultCollection Users
        {
            get
            {


                DirectorySearcher searcher = new DirectorySearcher(DomainEntry());
                searcher.Filter = ("(&(objectClass=user)(objectCategory=person)(department=*)(!userAccountControl:1.2.840.113556.1.4.803:=2))");
                searcher.PropertiesToLoad.Add("name");
                searcher.PropertiesToLoad.Add("telephoneNumber");
                searcher.PropertiesToLoad.Add("mobile");
                searcher.PropertiesToLoad.Add("mail");
                searcher.PropertiesToLoad.Add("title");
                searcher.PropertiesToLoad.Add("company");
                searcher.PropertiesToLoad.Add("department");
                searcher.PropertiesToLoad.Add("l");


                return searcher.FindAll();
            }
        }
       
        public static string? CurrentUserName
        {
            get
            {
                return CurrentUser().Name;
            }
        }
        public static string? CurrentUserDepartment
        {
            get
            {

                var directoryEntry = (DirectoryEntry)CurrentUser().GetUnderlyingObject();
                string? department = directoryEntry.Properties["department"].Value.ToString();

                return department;
            }
        }

        private static DirectoryEntry DomainEntry()
        {
            DirectoryEntry entry = new DirectoryEntry();
            return entry;
        }
        private static UserPrincipal CurrentUser()
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain);
            UserPrincipal CurrentUserPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Environment.UserName);

            return CurrentUserPrincipal;
        }

    }
}
