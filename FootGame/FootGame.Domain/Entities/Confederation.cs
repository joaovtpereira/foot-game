namespace FootGame.Domain.Entities;

public class Confederation
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid ContinentId { get; private set; }

    public Confederation(string name, Guid continentId)
    {
        Name = name;
        ContinentId = continentId;
        Id = Guid.NewGuid();
    }

    public Confederation SetName(string name)
    {
        Name = name;
        return this;
    }

    public Confederation SetContinent(Guid continentId)
    {
        ContinentId = continentId;
        return this;
    }
}   