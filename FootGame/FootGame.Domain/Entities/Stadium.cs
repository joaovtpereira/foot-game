namespace FootGame.Domain.Entities;

public class Stadium(string name, Guid cityId, int capacity)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public Guid CityId { get; private set; } = cityId;
    public int Capacity { get; private set; } = capacity;

    public Stadium SetName(string name)
    {
        Name = name;
        return this;
    }

    public Stadium SetCityId(Guid cityId)
    {
        CityId = cityId;
        return this;
    }

    public Stadium SetCapacity(int capacity)
    {
        Capacity = capacity;
        return this;
    }
}