using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public class BandAlbumRepository : IBandAlbumRepository
    {
        private readonly BandAlbumContext _db; // Made it private readonly because we only want to read values from the database. Underscore is a good choice to put before private variable names.

        public BandAlbumRepository(BandAlbumContext db)
        {
            //Part from ?? checks if the context/database sent is empty. If empty, it throws an error
            //with the name of db otherwise our injection is successfull. ?? is to check if smth is null.
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddAlbum(int bandID, Album album)
        {
           //if(bandID == 0)
           //{
                //throw new ArgumentNullException(nameof(bandID));
           //}

           if(album == null)
           {
                throw new ArgumentNullException(nameof(album));
           }

           album.BandID = bandID;
           _db.Albums.Add(album);
        }

        public void AddBand(Band band)
        {
            if(band == null)
            {
                throw new ArgumentNullException(nameof(band));
            }

            _db.Bands.Add(band); //Here Bands refers to our dbSet we created in BandAlbumContext.
         
        }

        public Album GetAlbumForABand(int bandID, int albumID)
        {
            
            return _db.Albums.Where(c => c.BandID == bandID && c.AlbumID == albumID).FirstOrDefault();
            //FirstOrDefault() means grab the first result where values match.

        }

        public IEnumerable<Album> GetAlbumsForABand(int bandID)
        {

            return _db.Albums.Where(c => c.BandID == bandID).ToList();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _db.Albums.ToList();
        }

        public IEnumerable<Band> GetAllBands()
        {
            return _db.Bands.ToList();
        }

        public IEnumerable<Band> GetAllBands(//string Genre, string Search
            BandsResourceParameters bandsResourceParameters)
        {
            if(bandsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(bandsResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(bandsResourceParameters.Genre) && 
                string.IsNullOrWhiteSpace(bandsResourceParameters.Search))
            {
                GetAllBands();
            }

            //Saving all bands in this var so changes can be done in this var and not whole database set.
            var collectionOfAllBands = _db.Bands as IQueryable<Band>;
            
            //Filter according to Genre.
            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.Genre))
            {
                var Genre1 = bandsResourceParameters.Genre.Trim(); //Remove whitespaces and format the string to make search/filter easy.
                collectionOfAllBands = collectionOfAllBands.Where(
                    c => c.Genre == Genre1);
            }

            //Search according to Search query provided.
            //Whatever band has the characters provided in Search string will be returned.
            if(!string.IsNullOrWhiteSpace(bandsResourceParameters.Search))
            {
                var Search1 = bandsResourceParameters.Search.Trim();
                collectionOfAllBands = collectionOfAllBands.Where(
                    c => c.Name.Contains(Search1));
            }
            return collectionOfAllBands.ToList();
        }

        public Band GetBand(int bandID)
        {
            
            return _db.Bands.Where(c => c.ID == bandID).FirstOrDefault();
            //If above statement shows error, simply add .FirstOrDefault() to fix.
        }

        public IEnumerable<Band> GetSpecificBands(IEnumerable<int> bandIDs)
        {
            if(bandIDs == null)
            {
                throw new ArgumentNullException(nameof(bandIDs));
            }

            return _db.Bands.Where(c => bandIDs.Contains(c.ID)).ToList();
            //return _db.Bands.Where(c => bandIDs.Contains(c.ID)).OrderBy(c => c.Name).ToList(); Optional but useful when ordering result with name of bands.
        }

        public void RemoveAlbum(Album album)
        {
            if(album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }
            _db.Albums.Remove(album);
        }

        public void RemoveBand(Band band)
        {
            if (band == null)
            {
                throw new ArgumentNullException(nameof(band));
            }
            _db.Bands.Remove(band);
        }

        public bool SaveChanges()
        {
            //SaveChanges() returns the number of records that were saved.
            //If it returns 0, it means 0 records were saved, which means the save was successful but
            //there were no records to save. -1 shows that the saving was unsuccessful.

            if(_db.SaveChanges() < 0)
            {
                return false;
            }
            return true;
        }

        public void UpdateAlbum(Album album) //Will be implemented in Controllers directly.
        {
            throw new NotImplementedException();
        }

        public void UpdateBand(Band band)
        {
            throw new NotImplementedException();
        }

        public bool BandExists(int bandID)
        {
            return _db.Bands.Any(c => c.ID == bandID); //Simply returns true or false.
        }

        public bool AlbumExists(int albumID)
        {
            return _db.Albums.Any(c => c.AlbumID == albumID); //Simply returns true or false.
        }
    }
}
