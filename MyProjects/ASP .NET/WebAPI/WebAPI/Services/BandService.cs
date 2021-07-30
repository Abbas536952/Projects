using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class BandService : IBandService
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandService(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task CreateBand(BandCreationDTO request)
        {
            
        }

        public Task DeleteBand(int bandID)
        {
            throw new NotImplementedException();
        }

        public Task<List<BandDTO>> GetAllBands()
        {
            throw new NotImplementedException();
        }

        public Task<BandDTO> GetBand(int bandID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBand(BandCreationDTO updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
