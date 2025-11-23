using FootGame.Domain.Enums;

namespace FootGame.Domain.Entities;

public class Team(string name, string code, Guid clubId, Guid cityId, TeamDepartmentType teamDepartmentType, Guid stadiumId, Guid? coachId = null)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Code { get; private set; } = code;
    public Guid ClubId { get; private set; } = clubId;
    public Guid CityId { get; private set; } = cityId;
    public TeamDepartmentType TeamDepartmentType { get; private set; } = teamDepartmentType;
    public Guid StadiumId { get; private set; } = stadiumId;
    public Guid? CoachId { get; private set; } = coachId;
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