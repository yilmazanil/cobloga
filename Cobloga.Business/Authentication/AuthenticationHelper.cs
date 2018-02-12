using Cobloga.Data;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cobloga.Business.Authentication
{
    public class AuthenticationHelper
    {
        public static bool Authenticate(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                using (var context = new CoblogaDataContext())
                {
                    var user = context.User.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        var decryptedPassword = CustomDecrypt.Decrypt(user.Password);
                        if (password == decryptedPassword)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool Register(User newUser)
        {
            if (newUser != null && !string.IsNullOrWhiteSpace(newUser.Email) 
                && !string.IsNullOrWhiteSpace(newUser.Password) && !string.IsNullOrWhiteSpace(newUser.Name))
            {
                newUser.Password = CustomEncrypt.Encrypt(newUser.Password);
                using (var context = new CoblogaDataContext())
                {
                    context.User.Add(newUser);
                    context.SaveChanges();
                    return true;
                }
            };
            return false;
        }

        public static int? GetUserIdIfExists()
        {
            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
            if (sessionEmail != null)
            {
                using (var context = new CoblogaDataContext())
                {
                    if (!string.IsNullOrWhiteSpace(sessionEmail.Value))
                    {
                        var user = context.User.FirstOrDefault(u => u.Email == sessionEmail.Value);
                        if (user != null)
                        {
                            return user.Id;
                        }
                    }
                }
            }
            return null;
        }
    }
}
