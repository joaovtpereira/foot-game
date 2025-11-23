using FootGame.Domain.Enums;

namespace FootGame.Domain.Entities;

public class Club(string name, string code, ClubType clubType, Guid countryId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Code { get; private set; } = code;
    public ClubType ClubType { get; private set; } = clubType;
    public Guid CountryId { get; private set; } = countryId;


    public Club SetName(string name)
    {
        Name = name;
        return this;
    }

    public Club SetCode(string code)
    {
        Code = code;
        return this;
    }

    public Club SetClubType(ClubType clubType)
    {
        ClubType = clubType;
        return this;
    }

    public Club SetCountryId(Guid countryId)
    {
        CountryId = countryId;
        return this;
    }
}   