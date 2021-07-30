using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.Common.Helpers;
using WebAPI.Entities;
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

        public async Task CreateBandAsync(BandCreationDTO request)
        {
            if (await _bandAlbumRepository.BandExistsAsync(request.Name))
                CustomErrors.BandAlreadyExists.ThrowCustomErrorException(System.Net.HttpStatusCode.BadRequest);

            var band  = _mapper.Map<Band>(request);
            await _bandAlbumRepository.AddBandAsync(band);
            await _bandAlbumRepository.SaveChangesAsync();
        }

        public async Task DeleteBandAsync(int bandID)
        {
            var band = await _bandAlbumRepository.GetBandAsync(bandID);

            if (band == null)
                CustomErrors.BandNotFound.ThrowCustomErrorException(System.Net.HttpStatusCode.BadRequest);

            await _bandAlbumRepository.RemoveBandAsync(band);
            await _bandAlbumRepository.SaveChangesAsync();
        }

        public async Task<List<BandDTO>> GetAllBandsAsync()
        {
            var bands = await _bandAlbumRepository.GetAllBandsAsync();

            var response = _mapper.Map<List<BandDTO>>(bands);
            return response;
        }

        public async Task<BandDTO> GetBandAsync(int bandID)
        {
            var band = await _bandAlbumRepository.GetBandAsync(bandID);

            if (band == null)
                CustomErrors.BandNotFound.ThrowCustomErrorException(System.Net.HttpStatusCode.BadRequest);

            var response = _mapper.Map<BandDTO>(band);
            return response;
        }

        public async Task UpdateBandAsync(int bandID, BandUpdateDTO updateRequest)
        {
            var band = await _bandAlbumRepository.GetBandAsync(bandID);

            if (band == null)
                CustomErrors.BandNotFound.ThrowCustomErrorException(System.Net.HttpStatusCode.BadRequest);

            band.Name = updateRequest.Name;
            band.Founded = updateRequest.Founded;
            band.Genre = updateRequest.Genre;

            var albumsToDelete = new List<Album>();

            foreach (var album in band.Albums)
            {
                var albumFromRequest = updateRequest.Albums.Where(x => x.AlbumID == album.AlbumID).FirstOrDefault();

                if (albumFromRequest != null)
                {
                    album.Title = albumFromRequest.Title;
                    album.Description = albumFromRequest.Description;
                }
                else
                {
                    albumsToDelete.Add(album);
                }
            }

            foreach (var album in albumsToDelete)
            {
                await _bandAlbumRepository.RemoveAlbumAsync(album);
            }

            var newAlbums = updateRequest.Albums.Where(x => x.AlbumID == 0 || x.AlbumID == null).ToList();
            foreach (var newAlbum in newAlbums)
            {
                band.Albums.Add(new Album
                {
                    Title = newAlbum.Title,
                    BandID = band.ID,
                    Description = newAlbum.Description
                });
            }

            await _bandAlbumRepository.UpdateBandAsync(band);
            await _bandAlbumRepository.SaveChangesAsync();
        }
    }
}
