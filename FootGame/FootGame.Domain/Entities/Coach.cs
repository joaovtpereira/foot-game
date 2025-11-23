namespace FootGame.Domain.Entities;

public class Coach(string name, DateTime birthDate, Guid nationalityId, Guid? teamId = null)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public DateTime BirthDate { get; private set; } = birthDate;
    public Guid NationalityId { get; private set; } = nationalityId;
    public Guid? TeamId { get; private set; } = teamId;

    public Coach SetName(string name)
    {
        Name = name;
        return this;
    }
    
    public Coach SetTeamId(Guid teamId)
    {
        TeamId = teamId;
        return this;
    }

    public int GetAge(DateTime currentDate)
    {
        int age = currentDate.Year - BirthDate.Year;

        if (currentDate < BirthDate.AddYears(age))
        {
            age--;
        }

        return age;
    }
}