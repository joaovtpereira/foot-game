namespace FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;

public class Player
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public int Height { get; private set; }
    public int Weight { get; private set; }
    public bool IsRetired { get; private set; }
    public PlayerSkill Skills { get; private set; }
    public Player(string name, int age, int height, int weight, PlayerSkill skills)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        Height = height;
        Weight = weight;
        Skills = skills;
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