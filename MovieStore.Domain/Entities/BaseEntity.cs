using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EntityStatus Status { get; set; }
}