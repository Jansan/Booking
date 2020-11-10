using AutoMapper;
using Booking.Core.Entities;
using Booking.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Data.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateGymClassViewModel, GymClass>();
            CreateMap<EditGymClassViewModel, GymClass>().ReverseMap();

            CreateMap<GymClass, GymClassesViewModel>()
                .ForMember(dest => dest.Attending, opt => opt.Ignore());
        }
    }
}
