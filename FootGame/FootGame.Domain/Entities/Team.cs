using FootGame.Domain.Enums;

namespace FootGame.Domain.Entities;

public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public Guid ClubId { get; private set; }
    public Guid CityId { get; private set; }
    public TeamDepartmentType TeamDepartmentType { get; private set; }
    public Guid StadiumId { get; private set; }
    public Guid? CoachId { get; private set; }

    public Team(string name, string code, Guid clubId, Guid cityId, TeamDepartmentType teamDepartmentType, Guid stadiumId)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Name and code cannot be empty.");
        }

   
        if(clubId == Guid.Empty || clubId == Guid.Empty || stadiumId == Guid.Empty)
        {
            throw new ArgumentException("Club, city and stadium cannot be empty.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        ClubId = clubId;
        CityId = cityId;
        TeamDepartmentType = teamDepartmentType;

    }
    public Team SetName(string name)
    {
        Name = name;
        return this;
    }

    public Team SetCode(string code)
    {
        Code = code;
        return this;
    }

    public Team SetCityId(Guid cityId)
    {
        CityId = cityId;
        return this;
    }

    public Team SetTeamDepartmentType(TeamDepartmentType teamDepartmentType)
    {
        TeamDepartmentType = teamDepartmentType;
        return this;
    }

    public Team SetStadiumId(Guid stadiumId)
    {
        StadiumId = stadiumId;
        return this;
    }

    public Team SetCoachId(Guid coachId)
    {

        CoachId = coachId;
        return this;
    }
}   