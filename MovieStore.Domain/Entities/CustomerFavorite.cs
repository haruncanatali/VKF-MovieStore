namespace MovieStore.Domain.Entities;

public class CustomerFavorite : BaseEntity
{
    public long GenreId { get; set; }
    public long UserId { get; set; }
    public int Amount { get; set; }

    public Genre Genre { get; set; }
    public User User { get; set; }
}