namespace FootGame.Domain.Entities;

public class Skill
{
    public Guid Id { get; private set; }
    public Guid PlayerId { get; private set; }
    public int Pace { get; private set; }       
    public int Shooting { get; private set; }     
    public int Passing { get; private set; }      
    public int Dribbling { get; private set; }     
    public int Defending { get; private set; }     
    public int Physicality { get; private set; }   
    public int Goalkeeping { get; private set; }    
    public int Overall { get; private set; }

    public Skill(
        Guid playerId,
        int pace,
        int shooting,
        int passing,
        int dribbling,
        int defending,
        int physicality,
        int goalkeeping)
    {
        Id = Guid.NewGuid();
        PlayerId = playerId;
        SetPace(pace);
        SetShooting(shooting);
        SetPassing(passing);
        SetDribbling(dribbling);
        SetDefending(defending);
        SetPhysicality(physicality);
        SetGoalkeeping(goalkeeping);
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
    }

    public void SetShooting(int value)
    {
        ValidateSkillValue(value, nameof(Shooting));
        Shooting = value;
    }

    public void SetPassing(int value)
    {
        ValidateSkillValue(value, nameof(Passing));
        Passing = value;
    }

    public void SetDribbling(int value)
    {
        ValidateSkillValue(value, nameof(Dribbling));
        Dribbling = value;
    }

    public void SetDefending(int value)
    {
        ValidateSkillValue(value, nameof(Defending));
        Defending = value;
    }

    public void SetPhysicality(int value)
    {
        ValidateSkillValue(value, nameof(Physicality));
        Physicality = value;
    }

    public void SetGoalkeeping(int value)
    {
        ValidateSkillValue(value, nameof(Goalkeeping));
        Goalkeeping = value;
    }

    private void UpdateOverall()
    {
        var overall = (Pace + Shooting + Passing + Dribbling + Defending + Physicality + Goalkeeping) / 7;
        ValidateSkillValue(overall, nameof(Overall));
        Overall = overall;
    }
}

