namespace FootGame.Domain.Entities;

public class Coach(string name, DateTime birthDate, Guid nationalityId, Guid? teamId = null): Person(name, birthDate, nationalityId)
{
    public Guid? TeamId { get; private set; } = teamId;
    
    public Coach SetTeamId(Guid teamId)
    {
        TeamId = teamId;
        return this;
    }
}