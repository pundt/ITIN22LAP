using AutoMapper;

using AutoMapperDemo.Models;
using AutoMapperDemo.Logic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperDemo
{
    public class AutoMapperConfig
    {
        public static IMapper CommonMapper;
  
        public static void RegisterMappings()
        {
            var commonConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<CommonProfile>());
         
            CommonMapper = commonConfiguration.CreateMapper();     
        }
    }

    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Ware, ShopModel>();
        }
    }
}