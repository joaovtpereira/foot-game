namespace FootGame.Domain.ValueObjects;

public class PlayerSkill
{
    public int Pace { get; private set; }       
    public int Shooting { get; private set; }     
    public int Passing { get; private set; }      
    public int Dribbling { get; private set; }     
    public int Defending { get; private set; }     
    public int Physicality { get; private set; }   
    public int Goalkeeping { get; private set; }    
    public int Overall { get; private set; }

    public PlayerSkill(
        int pace,
        int shooting,
        int passing,
        int dribbling,
        int defending,
        int physicality,
        int goalkeeping)
    {
        SetPace(pace);
        SetShooting(shooting);
        SetPassing(passing);
        SetDribbling(dribbling);
        SetDefending(defending);
        SetPhysicality(physicality);
        SetGoalkeeping(goalkeeping);
        UpdateOverall();
    }

    private void ValidateSkillValue(int value, string skillName)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentException($"{skillName} value must be between 0 and 100", nameof(value));
        }
    }

    public void SetPace(int value)
    {
        ValidateSkillValue(value, nameof(Pace));
        Pace = value;
        UpdateOverall();
    }

    public void SetShooting(int value)
    {
        ValidateSkillValue(value, nameof(Shooting));
        Shooting = value;
        UpdateOverall();
    }

    public void SetPassing(int value)
    {
        ValidateSkillValue(value, nameof(Passing));
        Passing = value;
        UpdateOverall();
    }

    public void SetDribbling(int value)
    {
        ValidateSkillValue(value, nameof(Dribbling));
        Dribbling = value;
        UpdateOverall();
    }

    public void SetDefending(int value)
    {
        ValidateSkillValue(value, nameof(Defending));
        Defending = value;
        UpdateOverall();
    }

    public void SetPhysicality(int value)
    {
        ValidateSkillValue(value, nameof(Physicality));
        Physicality = value;
        UpdateOverall();
    }

    public void SetGoalkeeping(int value)
    {
        ValidateSkillValue(value, nameof(Goalkeeping));
        Goalkeeping = value;
        UpdateOverall();
    }

    private void UpdateOverall()
    {
        var overall = (Pace + Shooting + Passing + Dribbling + Defending + Physicality + Goalkeeping) / 7;
        ValidateSkillValue(overall, nameof(Overall));
        Overall = overall;
    }
}

