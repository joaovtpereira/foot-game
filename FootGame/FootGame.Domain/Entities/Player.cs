namespace FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;
using FootGame.Domain.Enums;

public class Player(string name, DateTime birthDate, Guid nationalityId, int height, int weight, PlayerSkill skills, PlayerCareerStatus careerStatus, PlayerContractStatus? contractStatus = PlayerContractStatus.FreeAgent): Person(name, birthDate, nationalityId)
{
    public int Height { get; private set; } = height;
    public int Weight { get; private set; } = weight;
    public PlayerCareerStatus CareerStatus { get; private set; } = careerStatus;
    public PlayerSkill Skills { get; private set; } = skills;
    public PlayerContractStatus? ContractStatus { get; private set; } = contractStatus;

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
        if (CareerStatus == PlayerCareerStatus.Retired)
        {
            throw new Exception("Player is already retired");
        }

        CareerStatus = PlayerCareerStatus.Retired;
    }
}