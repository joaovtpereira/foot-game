using System.Security.Cryptography;

namespace FootGame.Domain.Entities;

public class Coach: Person
{
    public Guid? TeamId { get; private set; }

    public Coach(string name, DateTime birthDate, Guid nationalityId, Guid? teamId = null): base(name, birthDate, nationalityId)
    {
        int age = GetAge(DateTime.Now);
        
        if (age < 18)
        {
            throw new ArgumentException("Coach must be at least 18 years old.");
        }

        TeamId = teamId;
    }
    
    public Coach AssignToTeam(Guid teamId)
    {
        if(TeamId.HasValue)
        {
            throw new Exception("Coach is already assigned to a team. Unassign the coach from the current team first.");
        }

        TeamId = teamId;
        return this;
    }

    public Coach UnassignFromTeam()
    {
        if(!TeamId.HasValue)
        {
            throw new Exception("Coach is not assigned to any team.");
        }

        TeamId = null;
        return this;
    }
}