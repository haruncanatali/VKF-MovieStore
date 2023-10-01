using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Persistence.Configurations;

public class PurchasedMovieConfiguration : IEntityTypeConfiguration<PurchasedMovie>
{
    public void Configure(EntityTypeBuilder<PurchasedMovie> builder)
    {
        builder.Property(c => c.FilmId)
            .IsRequired();
        builder.Property(c => c.UserId)
            .IsRequired();
        builder.Property(c => c.Amount)
            .IsRequired();
    }
}