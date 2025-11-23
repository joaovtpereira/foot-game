namespace FootGame.Domain.Entities;

public class Continent
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Continent(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public Continent SetName(string name)
    {
        Name = name;
        return this;
    }
}