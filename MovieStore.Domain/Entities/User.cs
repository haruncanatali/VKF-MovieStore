using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities;

public class User : IdentityUser<long>
{
    public User()
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<PurchasedMovie> PurchasedMovies { get; set; }
    public List<CustomerFavorite> CustomerFavorites { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public EntityStatus Status { get; set; } = EntityStatus.Active;

    [IgnoreDataMember]
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }
}