using Cobloga.Business.Authentication;
using Cobloga.Data;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cobloga.WebUI.Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private IEncryptor dataEncryptor;
        private HttpRequestBase httpRequest;

        public AuthenticationProvider(IEncryptor encryptor, HttpRequestBase webRequest)
        {
            dataEncryptor = encryptor;
            httpRequest = webRequest;
        }

        public bool Authenticate(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                using (var context = new CoblogaDataContext())
                {
                    var user = context.User.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        var decryptedPassword = dataEncryptor.Decrypt(user.Password);
                        if (password == decryptedPassword)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool Register(User newUser)
        {
            if (newUser != null && !string.IsNullOrWhiteSpace(newUser.Email) 
                && !string.IsNullOrWhiteSpace(newUser.Password) && !string.IsNullOrWhiteSpace(newUser.Name))
            {
                newUser.Password = dataEncryptor.Encrypt(newUser.Password);
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


        public bool SignIn(User authenticationRequest)
        {
            if (Authenticate(authenticationRequest.Email, authenticationRequest.Password))
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, authenticationRequest.Email) }, "CoblogaCookie");
                httpRequest.GetOwinContext().Authentication.SignIn(identity);
                return true;
            }
            return false;
        }

        public void SignOut()
        {
            httpRequest.GetOwinContext().Authentication.SignOut("CoblogaCookie"); ;
        }
    }
}
