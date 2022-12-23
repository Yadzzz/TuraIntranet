using System.DirectoryServices.AccountManagement;
using System.Reflection.Metadata.Ecma335;

namespace TuraIntranet.Authentication
{
    public class UserAccountService
    {
        public UserAccountService()
        {
            
        }

        public bool GetByUsername(string username, string password, out UserAccount userAccount, out string error)
        {
            userAccount = null;
            error = string.Empty;

            PrincipalContext context = new PrincipalContext(ContextType.Domain, "192.168.1.110", null, username, password);
            UserPrincipal user = new UserPrincipal(context);
            user.SamAccountName = username;
            PrincipalSearcher searcher = new PrincipalSearcher(user);
            var userPrincipal = searcher.FindOne();
            var userGroups = new List<string>();

            if (userPrincipal != null)
            {
                userGroups = userPrincipal.GetGroups(context).Select(x => x.Name).ToList();

                if (!userGroups.Contains("Tura Intranet Users"))
                {
                    error = "Permission Denied for User";
                    return false;
                }
                else
                {
                    userAccount = new UserAccount()
                    {
                        Username = username,
                        Role = "User"
                    };

                    return true;
                }
            }
            else
            {
                error = "Invalid Credentials";
                return false;
            }
        }
    }
}
