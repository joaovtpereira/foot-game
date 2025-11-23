using FootGame.Domain.ValueObjects;
using FootGame.Domain.Enums;
namespace FootGame.Domain.Services;

public class PlayerOverallCalculator
{
    public int CalculateOverall(PlayerSkill skill)
    {
        double weightedRating = 0;

        switch (skill.Position)
        {
            case PlayerPosition.Goalkeeper:
                weightedRating = CalculateGoalkeeperOverall(skill);
                break;
            case PlayerPosition.CenterBack:
                weightedRating = CalculateCenterBackOverall(skill);
                break;
            case PlayerPosition.FullBack:
                weightedRating = CalculateFullBackOverall(skill);
                break;
            case PlayerPosition.DefensiveMidfielder:
                weightedRating = CalculateDefensiveMidfielder(skill);
                break;
            case PlayerPosition.CentralMidfielder:
                weightedRating = CalculateCentralMidfielder(skill);
                break;
            case PlayerPosition.Winger:
                weightedRating = CalculateWinger(skill);
                break;
            case PlayerPosition.SecondStriker:
                weightedRating = CalculateSecondStriker(skill);
                break;
            case PlayerPosition.Striker:
                weightedRating = CalculateStriker(skill);
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
        return (skill.Marking * 0.15) +
                   (skill.Tackling * 0.15) +
                   (skill.Interception * 0.15) +
                   (skill.DefensiveVision * 0.15) +
                   (skill.Strength * 0.10) +
                   (skill.Heading * 0.05) +
                   (skill.Jumping * 0.05) +
                   (skill.Aggressiveness * 0.10) +
                   (skill.Determination * 0.05) +
                   (skill.Passing * 0.05);
    }

    private double CalculateFullBackOverall(PlayerSkill skill)
    {
        return (skill.Pace * 0.15) +
                (skill.Stamina * 0.15) +
                (skill.Acceleration * 0.10) +
                (skill.Crossing * 0.20) +
                (skill.Tackling * 0.10) +
                (skill.Marking * 0.10) +
                (skill.Dribbling * 0.05) +
                (skill.Positioning * 0.05) +
                (skill.Passing * 0.05) +
                (skill.Agility * 0.05);
    }

    private double CalculateDefensiveMidfielder(PlayerSkill skill)
    {
        return (skill.Interception * 0.15) +
               (skill.Tackling * 0.15) +
               (skill.Stamina * 0.10) +
               (skill.Strength * 0.10) +
               (skill.Passing * 0.10) +
               (skill.LongPassing * 0.10) +
               (skill.DefensiveVision * 0.10) +
               (skill.Teamwork * 0.05) +
               (skill.Aggressiveness * 0.05) +
               (skill.Composure * 0.10);
    }

    private double CalculateCentralMidfielder(PlayerSkill skill)
    {
        return (skill.Passing * 0.15) +
               (skill.Vision * 0.15) +
               (skill.BallControl * 0.15) +
               (skill.Dribbling * 0.10) +
               (skill.LongPassing * 0.10) +
               (skill.Stamina * 0.10) +
               (skill.Composure * 0.05) +
               (skill.LongShots * 0.05) +
               (skill.Agility * 0.05) +
               (skill.Teamwork * 0.10);
    }

    private double CalculateWinger(PlayerSkill skill)
    {
        return (skill.Pace * 0.15) +
               (skill.Acceleration * 0.15) +
               (skill.Dribbling * 0.20) +
               (skill.Agility * 0.15) +
               (skill.Crossing * 0.15) +
               (skill.BallControl * 0.15) +
               (skill.Finishing * 0.05) +
               (skill.Stamina * 0.10) +
               (skill.Vision * 0.10) +
               (skill.Passing * 0.05);
    }

    private double CalculateSecondStriker(PlayerSkill skill)
    {
        return (skill.Dribbling * 0.20) +
               (skill.Finishing * 0.15) +
               (skill.BallControl * 0.20) +
               (skill.Vision * 0.15) +
               (skill.Agility * 0.10) +
               (skill.Acceleration * 0.10) +
               (skill.Passing * 0.10) +
               (skill.LongShots * 0.10) +
               (skill.Positioning * 0.10);
    }

    private double CalculateStriker(PlayerSkill skill)
    {
        return (skill.Finishing * 0.25) +
               (skill.Heading * 0.20) +
               (skill.Positioning * 0.20) +
               (skill.ShotPower * 0.15) +
               (skill.Strength * 0.15) +
               (skill.Jumping * 0.15) +
               (skill.Composure * 0.05) +
               (skill.BallControl * 0.05);
    }
}