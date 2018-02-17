using AutoMapper;
using Cobloga.Business.ViewModel;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobloga.Business.AutoMapper
{
    public class RegisterDataToViewModelMapper
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserViewModel>();
            cfg.CreateMap<BlogPost, BlogPostViewModel>();
        }
    }
}
