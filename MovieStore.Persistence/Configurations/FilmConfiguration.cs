using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Persistence.Configurations;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(c => c.Year)
            .IsRequired();
        builder.Property(c => c.Price)
            .IsRequired().HasPrecision(8,2);
        builder.Property(c => c.DirectorId)
            .IsRequired();
        builder.Property(c => c.GenreId)
            .IsRequired();
    }
}