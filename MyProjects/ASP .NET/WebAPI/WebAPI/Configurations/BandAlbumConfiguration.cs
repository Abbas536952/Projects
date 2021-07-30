using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Configurations
{
    public class BandAlbumConfiguration : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasMany(x => x.Albums)
                .WithOne(x => x.Band)
                .HasForeignKey(x => x.BandID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
