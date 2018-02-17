using Cobloga.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobloga.Business.UserStore
{
    public interface IUserStore
    {
        UserViewModel GetCurrentUser();
    }
}
