using AutoMapper;
using Cobloga.Business.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobloga.WebUI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                RegisterDataToViewModelMapper.Register(cfg);
            });
        }
    }
}