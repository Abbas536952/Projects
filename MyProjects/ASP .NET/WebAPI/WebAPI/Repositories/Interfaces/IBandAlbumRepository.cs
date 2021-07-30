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
        List<Album> GetAlbumsForABand(int bandID); 
        Album GetAlbumForABand(int bandID, int albumID);
        List<Album> GetAllAlbums();
        void AddAlbum(int bandID, Album album);
        void UpdateAlbum(Album album);
        void RemoveAlbum(Album album); 
        Band GetBand(int bandID);
        List<Band> GetAllBands();
        List<Band> GetAllBands(BandsResourceParameters bandsResourceParameters);
        List<Band> GetSpecificBands(List<int> bandIDs);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void RemoveBand(Band band);
        bool BandExists(int bandID); //Self-explanatory and enable when use required.
        bool AlbumExists(int albumID);
        bool SaveChanges(); // Returns a true or false value denoting if the changes were successful.
    }
}
