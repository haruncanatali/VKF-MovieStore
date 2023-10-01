using Microsoft.AspNetCore.Identity;

namespace MovieStore.Domain.Entities;

public class UserRole : IdentityUserRole<long>
{
    public UserRole() : base()
    {
            
    }
}