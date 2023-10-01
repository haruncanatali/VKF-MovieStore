namespace MovieStore.Domain.Entities;

public class Director : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Film> Films { get; set; }
}