using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Persistence.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(c => c.Surname)
            .IsRequired()
            .HasMaxLength(50);
    }
}