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

            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain, "192.168.1.110", null, username, password);
                UserPrincipal user = new UserPrincipal(context);
                user.SamAccountName = username;
                PrincipalSearcher searcher = new PrincipalSearcher(user);
                var userPrincipal = searcher.FindOne();
                var userGroups = new List<string>();

                if (userPrincipal != null)
                {
                    userGroups = userPrincipal.GetGroups(context).Select(x => x.Name).ToList();

                    //foreach (var group in userGroups)
                    //{
                    //    Console.WriteLine(group);
                    //}

                    if (!userGroups.Contains("Tura Intranet Users") && !userGroups.Contains("Tura Intranet Administrators") && !userGroups.Contains("Tura Intranet Power Users"))
                    {
                        error = "Permission Denied for User";
                        return false;
                    }
                    else
                    {
                        string role = string.Empty;

                        if (userGroups.Contains("Tura Intranet Administrators"))
                        {
                            role = "Administrator";
                        }
                        else if (userGroups.Contains("Tura Intranet Power Users"))
                        {
                            role = "Power User";
                        }
                        else
                            role = "User";

                        userAccount = new UserAccount()
                        {
                            Username = username,
                            Role = role
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
            catch(Exception ex)
            {
                error = "Invalid Credentials";
                return false;
            }
        }
    }
}
