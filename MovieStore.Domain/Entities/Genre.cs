namespace MovieStore.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    public List<Film> Films { get; set; }
    public List<CustomerFavorite> CustomerFavorites { get; set; }
}