using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.DbContexts
{
    public class BandAlbumContext : DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) : base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band()
            {
                ID = 1,
                Name = "FirstBand",
                Founded = new DateTime(2000, 1, 1),
                Genre = "Genre1"
            },
            new Band() 
            {
                ID = 2,
                Name = "SecondBand",
                Founded = new DateTime(2001, 5, 6),
                Genre = "Genre2"
            });
            modelBuilder.Entity<Album>().HasData(new Album()
            {
                AlbumID = 1,
                Description = "Description of Album 1",
                Title = "Album1",
                BandID = 1
            }, new Album() 
            {
                AlbumID = 2,
                Description = "Description of Album 2",
                Title = "Album2",
                BandID = 1
            }, new Album() 
            {
                AlbumID = 3,
                Description = "Description of Album 3",
                Title = "Album3",
                BandID = 2
            }, new Album() 
            {
                AlbumID = 4,
                Description = "Description of Album 4",
                Title = "Album4",
                BandID = 2
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
