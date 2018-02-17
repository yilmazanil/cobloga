using Cobloga.Business.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobloga.Business.ViewModel;
using System.Security.Claims;
using Cobloga.Data;
using AutoMapper;
using Cobloga.Data.DataModel;

namespace Cobloga.Business.UserStore
{
    public class CoblogaUserStore : IUserStore
    {
        public UserViewModel GetCurrentUser()
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
                            return Mapper.Map<UserViewModel>(user);
                        }
                    }
                }
            }
            return null;
        }
    }
}
