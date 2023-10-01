using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Persistence.Configurations;

public class CustomerFavoriteConfiguration : IEntityTypeConfiguration<CustomerFavorite>
{
    public void Configure(EntityTypeBuilder<CustomerFavorite> builder)
    {
        builder.Property(c => c.GenreId)
            .IsRequired();
        builder.Property(c => c.UserId)
            .IsRequired();
        builder.Property(c => c.Amount)
            .IsRequired();
    }
}