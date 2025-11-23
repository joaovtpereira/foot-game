namespace FootGame.Domain.Entities;

public class State(string name, string code, Guid countryId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Code { get; private set; } = code;
    public Guid CountryId { get; private set; } = countryId;

    public State SetName(string name)
    {
        Name = name;
        return this;
    }

    public State SetCode(string code)
    {
        Code = code;
        return this;
    }
}