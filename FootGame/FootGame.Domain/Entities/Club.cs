using FootGame.Domain.Enums;

namespace FootGame.Domain.Entities;

public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public ClubType ClubType { get; private set; }
    public Guid CountryId { get; private set; }
    public DateTime FoundedDate { get; private set; }

    public Club(string name, string code, ClubType clubType, Guid countryId, DateTime foundedDate)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        if(string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Code cannot be empty.");
        }

        if(foundedDate > DateTime.Now || foundedDate < new DateTime(1857, 10, 24))
        {
            throw new ArgumentException("Founded date cannot be in the future or before the first club was founded.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        ClubType = clubType;
        CountryId = countryId;
        FoundedDate = DateTime.Now;

    }


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