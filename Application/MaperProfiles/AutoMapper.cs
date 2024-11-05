using AutoMapper;
using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MaperProfiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
