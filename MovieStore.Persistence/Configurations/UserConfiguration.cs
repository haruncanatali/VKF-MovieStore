using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(50);
    }
}