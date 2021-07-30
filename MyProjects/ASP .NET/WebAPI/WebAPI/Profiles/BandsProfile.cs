using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class BandsProfile : Profile
    {
        public BandsProfile()
        {
            var currentDate = DateTime.Now;
            CreateMap<Band, BandDTO>()
                .ForMember(
                    dest => dest.FoundedYearsAgo,
                    opt => opt.MapFrom(src => "Year " + src.Founded.ToString("yyyy") +
                                      " (" + (currentDate.Year - src.Founded.Year).ToString() + " Years Ago)")
                    ).ReverseMap(); //ForMember is needed for variables with custom/modified information.

            CreateMap<BandCreationDTO, Band>();
            //CreateMap<List<BandDTO>, Band>().ReverseMap();
        }
    }
}
