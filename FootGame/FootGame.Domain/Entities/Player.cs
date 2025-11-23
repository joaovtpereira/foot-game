namespace FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;

public class Player(string name, DateTime birthDate, Guid nationalityId, int height, int weight, PlayerSkill skills)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public DateTime BirthDate { get; private set; } = birthDate;
    public Guid NationalityId { get; private set; } = nationalityId;
    public int Height { get; private set; } = height;
    public int Weight { get; private set; } = weight;
    public bool IsRetired { get; private set; } = false;
    public PlayerSkill Skills { get; private set; } = skills;

    public Player SetName(string name)
    {
        Name = name;
        return this;
    }

    public Player SetHeight(int height)
    {
        Height = height;
        return this;
    }

    public Player SetWeight(int weight)
    {
        Weight = weight;
        return this;
    }
    
    public void Retire()
    {
        if (IsRetired)
        {
            throw new Exception("Player is already retired");
        }

        IsRetired = true;
    }
}