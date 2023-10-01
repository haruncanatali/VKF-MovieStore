namespace MovieStore.Domain.Entities;

public class PurchasedMovie : BaseEntity
{
    public long FilmId { get; set; }
    public long UserId { get; set; }
    public int Amount { get; set; }

    public Film Film { get; set; }
    public User User { get; set; }
}