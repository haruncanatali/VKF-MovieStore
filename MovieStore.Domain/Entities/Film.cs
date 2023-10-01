namespace MovieStore.Domain.Entities;

public class Film : BaseEntity
{
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public long DirectorId { get; set; }
    public long GenreId { get; set; }

    public List<Artist> Artists { get; set; }
    public Director Director { get; set; }
    public Genre Genre { get; set; }
}