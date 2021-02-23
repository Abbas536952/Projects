using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {
            CreateMap<Entities.Album, Models.AlbumDTO>(); //No need of ForMember because same data is copied from Album to AlbumDTO.
            CreateMap<Models.AlbumCreationDTO, Entities.Album>();
        }
    }
}
