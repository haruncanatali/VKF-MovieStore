using Microsoft.EntityFrameworkCore;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<User> Users{ get; set; }
    public DbSet<Role> Roles{ get; set; }
    public DbSet<UserRole> UserRoles{ get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<CustomerFavorite> CustomerFavorites { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PurchasedMovie> PurchasedMovies { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}