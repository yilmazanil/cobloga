using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cobloga.Business.Authentication
{
    public interface IAuthenticationProvider
    {
        bool Authenticate(string userEmail, string password);
        bool Register(User newUser);
        bool SignIn(User authenticationRequest);
        void SignOut();
    }
}
