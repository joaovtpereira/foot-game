using FootGame.Domain.ValueObjects;
using FootGame.Domain.Enums;
namespace FootGame.Domain.Services;

public class PlayerOverallCalculator
{
    public int CalculateOverall(PlayerSkill skill, PlayerPosition position)
    {
        double weightedRating = 0;

        switch (position)
        {
            case PlayerPosition.Goalkeeper:
                weightedRating = CalculateGoalkeeperOverall(skill);
                break;
            case PlayerPosition.CenterBack:
                weightedRating = CalculateCenterBackOverall(skill);
                break;
        }

        int finalOverall = (int)Math.Round(weightedRating);
        return Math.Clamp(finalOverall, 1, 99);
    }

    private double CalculateGoalkeeperOverall(PlayerSkill skill)
    {
        return (skill.Reflexes * 0.25) +
                (skill.Diving * 0.20) +
                (skill.Handling * 0.20) +
                (skill.GoalkeepingPositioning * 0.20) +
                (skill.Composure * 0.05) +       
                (skill.LongPassing * 0.05) +  
                (skill.Jumping * 0.05);
    }

    private double CalculateCenterBackOverall(PlayerSkill skill)
    {
        return (skill.Marking * 0.20) +
                   (skill.Tackling * 0.20) +
                   (skill.Interception * 0.20) +
                   (skill.DefensiveVision * 0.25) + 
                   (skill.Strength * 0.15) +
                   (skill.Heading * 0.10) +
                   (skill.Jumping * 0.10) +
                   (skill.Aggressiveness * 0.10) +
                   (skill.Determination * 0.05) +
                   (skill.Passing * 0.10);   
    }
}