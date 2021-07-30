using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
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

        public async Task AddAlbumAsync(int bandID, Album album)
        {
           album.BandID = bandID;
           await _db.Albums.AddAsync(album);
        }

        public async Task AddBandAsync(Band band)
        {
            await _db.Bands.AddAsync(band); //Here Bands refers to our dbSet we created in BandAlbumContext.
        }

        public async Task<Album> GetAlbumForABandAsync(int bandID, int albumID)
        {
            return await _db.Albums.Where(c => c.BandID == bandID && c.AlbumID == albumID).FirstOrDefaultAsync();
        }

        public async Task<List<Album>> GetAlbumsForABandAsync(int bandID)
        {
            return await _db.Albums.Where(c => c.BandID == bandID).ToListAsync();
        }

        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            return await _db.Albums.ToListAsync();
        }

        public async Task<List<Band>> GetAllBandsAsync()
        {
            return await _db.Bands.Include(x => x.Albums).ToListAsync();
        }

        public async Task<List<Band>> GetAllBandsAsync(//string Genre, string Search
            BandsResourceParameters bandsResourceParameters)
        {
            if(bandsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(bandsResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(bandsResourceParameters.Genre) && 
                string.IsNullOrWhiteSpace(bandsResourceParameters.Search))
            {
                await GetAllBandsAsync();
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
            return await collectionOfAllBands.ToListAsync();
        }

        public async Task<Band> GetBandAsync(int bandID)
        {
            return await _db.Bands.Where(c => c.ID == bandID).Include(x => x.Albums).FirstOrDefaultAsync();
        }

        public async Task<List<Band>> GetSpecificBandsAsync(List<int> bandIDs)
        {
            return await  _db.Bands.Where(c => bandIDs.Contains(c.ID)).Include(x => x.Albums).ToListAsync();
        }

        public async Task RemoveAlbumAsync(Album album)
        {
            _db.Albums.Remove(album);
        }

        public async Task RemoveBandAsync(Band band)
        {
            _db.Bands.Remove(band);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //SaveChanges() returns the number of records that were saved.
            //If it returns 0, it means 0 records were saved, which means the save was successful but
            //there were no records to save. -1 shows that the saving was unsuccessful.

            if(await _db.SaveChangesAsync() < 0)
            {
                return false;
            }
            return true;
        }

        public async Task UpdateAlbumAsync(Album album) //Will be implemented in Controllers directly.
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBandAsync(Band band)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> BandExistsAsync(int bandID)
        {
            return await _db.Bands.AnyAsync(c => c.ID == bandID); //Simply returns true or false.
        }

        public async Task<bool> BandExistsAsync(string name)
        {
            return await _db.Bands.AnyAsync(c => c.Name == name);
        }

        public async Task<bool> AlbumExistsAsync(int albumID)
        {
            return await _db.Albums.AnyAsync(c => c.AlbumID == albumID); //Simply returns true or false.
        }

        public async Task<bool> AlbumExistsAsync(string title)
        {
            return await _db.Albums.AnyAsync(c => c.Title == title);
        }
    }
}
