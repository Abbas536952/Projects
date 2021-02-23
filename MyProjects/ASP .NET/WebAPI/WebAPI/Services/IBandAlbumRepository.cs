using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public interface IBandAlbumRepository
    {
        IEnumerable<Album> GetAlbumsForABand(int bandID); 
        Album GetAlbumForABand(int bandID, int albumID);
        IEnumerable<Album> GetAllAlbums();
        void AddAlbum(int bandID, Album album);
        void UpdateAlbum(Album album);
        void RemoveAlbum(Album album); 
        Band GetBand(int bandID);
        IEnumerable<Band> GetAllBands();
        IEnumerable<Band> GetAllBands(BandsResourceParameters bandsResourceParameters);
        IEnumerable<Band> GetSpecificBands(IEnumerable<int> bandIDs);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void RemoveBand(Band band);
        bool BandExists(int bandID); //Self-explanatory and enable when use required.
        bool AlbumExists(int albumID);
        bool SaveChanges(); // Returns a true or false value denoting if the changes were successful.
    }
}
