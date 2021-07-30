using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Repositories.Interfaces
{
    public interface IBandAlbumRepository
    {
        Task<List<Album>> GetAlbumsForABandAsync(int bandID); 
        Task<Album> GetAlbumForABandAsync(int bandID, int albumID);
        Task<List<Album>> GetAllAlbumsAsync();
        Task<bool> BandExistsAsync(string name);
        Task<bool> AlbumExistsAsync(string title);
        Task AddAlbumAsync(int bandID, Album album);
        Task UpdateAlbumAsync(Album album);
        Task RemoveAlbumAsync(Album album); 
        Task<Band> GetBandAsync(int bandID);
        Task<List<Band>> GetAllBandsAsync();
        Task<List<Band>> GetAllBandsAsync(BandsResourceParameters bandsResourceParameters);
        Task<List<Band>> GetSpecificBandsAsync(List<int> bandIDs);
        Task AddBandAsync(Band band);
        Task UpdateBandAsync(Band band);
        Task RemoveBandAsync(Band band);
        Task<bool> BandExistsAsync(int bandID); //Self-explanatory and enable when use required.
        Task<bool> AlbumExistsAsync(int albumID);
        Task<bool> SaveChangesAsync(); // Returns a true or false value denoting if the changes were successful.
    }
}
