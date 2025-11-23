namespace FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;

public class Player(string name, DateTime birthDate, Guid nationalityId, int height, int weight, PlayerSkill skills): Person(name, birthDate, nationalityId)
{
    public int Height { get; private set; } = height;
    public int Weight { get; private set; } = weight;
    public bool IsRetired { get; private set; } = false;
    public PlayerSkill Skills { get; private set; } = skills;

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