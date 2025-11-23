namespace FootGame.Domain.Entities;

public class City(string name, string code, Guid stateId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Code { get; private set; } = code;
    public Guid StateId { get; private set; } = stateId;

    public City SetName(string name)
    {
        Name = name;
        return this;
    }

    public City SetCode(string code)
    {
        Code = code;
        return this;
    }
}