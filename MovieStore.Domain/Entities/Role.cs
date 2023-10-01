using Microsoft.AspNetCore.Identity;
using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities;

public class Role : IdentityRole<long>
{
    public Role() : base()
    {
    }

    public Role(string roleName) : base(roleName)
    {

    }

    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public EntityStatus Status { get; set; } = EntityStatus.Active;
}