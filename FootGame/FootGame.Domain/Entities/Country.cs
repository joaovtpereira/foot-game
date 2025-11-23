namespace FootGame.Domain.Entities;
public class Country
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public string Flag { get; private set; }
    public Guid ContinentId { get; private set; }
    public Guid ConfederationId { get; private set; }    


    public Country(string name, string code, string flag, Guid continentId, Guid confederationId)
    {
        Name = name;
        Code = code;
        Flag = flag;
        ContinentId = continentId;
        ConfederationId = confederationId;
        Id = Guid.NewGuid();
    }

    private Country SetName(string name)
    {
        Name = name;
        return this;
    }

    private Country SetCode(string code)
    {
        Code = code;
        return this;
    }

    private Country SetFlag(string flag)
    {
        Flag = flag;
        return this;
    }

    private Country SetContinent(Guid continentId)
    {
        ContinentId = continentId;
        return this;
    }

    private Country SetConfederation(Guid confederationId)
    {
        ConfederationId = confederationId;
        return this;
    }
}