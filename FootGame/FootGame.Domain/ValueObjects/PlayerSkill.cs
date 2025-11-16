namespace FootGame.Domain.ValueObjects;

public class PlayerSkill
{
    // Mentality
    public int Composure {get; private set;}
    public int Positioning {get; private set;}
    public int Aggressiveness {get; private set;}
    public int Determination {get; private set;}
    public int Leadership {get; private set;}
    public int Teamwork {get; private set;}

    // Physical
    public int Pace { get; private set; }       
    public int Acceleration {get; private set;}
    public int Stamina {get; private set;}
    public int Strength {get; private set;}
    public int Jumping {get; private set;}

    // Technical Attack
    public int Finishing { get; private set; }   
    public int LongShots { get; private set; }   
    public int ShotPower { get; private set; }   
    public int Heading { get; private set; }

    // Technical General

    public int Passing { get; private set; }      
    public int Vision {get; private set;}
    public int Crossing { get; private set; }
    public int LongPassing { get; private set; }
    public int Dribbling { get; private set; }     
    public int Agility {get; private set;}
    public int BallControl {get; private set;}

    // Technical Defense
    public int Defending { get; private set; }     
    public int Tackling { get; private set; }
    public int Marking { get; private set; }
    public int Interception { get; private set; }
    public int DefensiveVision { get; private set; }

    // Goalkeeping
    public int Reflexes { get; private set; }
    public int GoalkeepingPositioning { get; private set; }
    public int Handling { get; private set; }
    public int Diving { get; private set; }

    public int Overall { get; private set; }
    
    public PlayerSkill(
        int Composure,
        int Positioning,
        int Aggressiveness,
        int Determination,
        int Leadership,
        int Teamwork,
        int Pace,
        int Acceleration,
        int Stamina,
        int Strength,
        int Jumping,
        int Finishing,
        int LongShots,
        int ShotPower,
        int Heading,
        int Passing,
        int Vision,
        int Crossing,
        int LongPassing,
        int Dribbling,
        int Agility,
        int BallControl,
        int Defending,
        int Tackling,
        int Marking,
        int Interception,
        int DefensiveVision,
        int Reflexes,
        int Handling,
        int Diving,
        int GoalkeepingPositioning)
    {
        SetComposure(Composure);
        SetPositioning(Positioning);
        SetAggressiveness(Aggressiveness);
        SetDetermination(Determination);
        SetLeadership(Leadership);
        SetTeamwork(Teamwork);
        SetPace(Pace);
        SetAcceleration(Acceleration);
        SetStamina(Stamina);
        SetStrength(Strength);
        SetJumping(Jumping);
        SetFinishing(Finishing);
        SetLongShots(LongShots);
        SetShotPower(ShotPower);
        SetHeading(Heading);
        SetPassing(Passing);
        SetVision(Vision);
        SetCrossing(Crossing);
        SetLongPassing(LongPassing);
        SetDribbling(Dribbling);
        SetAgility(Agility);
        SetBallControl(BallControl);
        SetDefending(Defending);
        SetTackling(Tackling);
        SetMarking(Marking);
        SetInterception(Interception);
        SetDefensiveVision(DefensiveVision);
        SetReflexes(Reflexes);
        SetHandling(Handling);
        SetDiving(Diving);
        SetGoalkeepingPositioning(GoalkeepingPositioning);
        UpdateOverall();
    }

    public static PlayerSkill CreateDefaultPlayerSkill()
    {
        return new PlayerSkill(
            Composure: 50,
            Positioning: 50,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: 50,
            Pace: 50,
            Acceleration: 50,
            Stamina: 50,
            Strength: 50,
            Jumping: 50,
            Finishing: 50,
            LongShots: 50,
            ShotPower: 50,
            Heading: 50,
            Passing: 50,
            Vision: 50,
            Crossing: 50,
            LongPassing: 50,
            Dribbling: 50,
            Agility: 50,
            BallControl: 50,
            Defending: 50,
            Tackling: 50,
            Marking: 50,
            Interception: 50,
            DefensiveVision: 50,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50
        );
    }

    private void ValidateSkillValue(int value, string skillName)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentException($"{skillName} value must be between 0 and 100", nameof(value));
        }
    }
    public void SetComposure(int composure)
    {
        ValidateSkillValue(composure, nameof(Composure));
        this.Composure = composure;
        UpdateOverall();
    }

    public void SetPositioning(int positioning)
    {
        ValidateSkillValue(positioning, nameof(Positioning));
        this.Positioning = positioning;
        UpdateOverall();
    }

    public void SetAggressiveness(int aggressiveness)
    {
        ValidateSkillValue(aggressiveness, nameof(Aggressiveness));
        this.Aggressiveness = aggressiveness;
        UpdateOverall();
    }
    public void SetDetermination(int determination)
    {
        ValidateSkillValue(determination, nameof(Determination));
        this.Determination = determination;
        UpdateOverall();
    }
    public void SetLeadership(int leadership)
    {
        ValidateSkillValue(leadership, nameof(Leadership));
        this.Leadership = leadership;
        UpdateOverall();
    }
    public void SetTeamwork(int teamwork)
    {
        ValidateSkillValue(teamwork, nameof(Teamwork));
        this.Teamwork = teamwork;
        UpdateOverall();
    }
    public void SetPace(int pace)
    {
        ValidateSkillValue(pace, nameof(Pace));
        this.Pace = pace;
        UpdateOverall();
    }
    public void SetAcceleration(int acceleration)
    {
        ValidateSkillValue(acceleration, nameof(Acceleration));
        this.Acceleration = acceleration;
        UpdateOverall();
    }
    public void SetStamina(int stamina)
    {
        ValidateSkillValue(stamina, nameof(Stamina));
        this.Stamina = stamina;
        UpdateOverall();
    }
    public void SetStrength(int strength)
    {
        ValidateSkillValue(strength, nameof(Strength));
        this.Strength = strength;
        UpdateOverall();
    }
    public void SetJumping(int jumping)
    {
        ValidateSkillValue(jumping, nameof(Jumping));
        this.Jumping = jumping;
        UpdateOverall();
    }
    public void SetFinishing(int finishing)
    {
        ValidateSkillValue(finishing, nameof(Finishing));
        this.Finishing = finishing;
        UpdateOverall();
    }
    public void SetLongShots(int longShots)
    {
        ValidateSkillValue(longShots, nameof(LongShots));
        this.LongShots = longShots;
        UpdateOverall();
    }
    public void SetShotPower(int shotPower)
    {
        ValidateSkillValue(shotPower, nameof(ShotPower));
        this.ShotPower = shotPower;
        UpdateOverall();
    }
    public void SetHeading(int heading)
    {
        ValidateSkillValue(heading, nameof(Heading));
        this.Heading = heading;
        UpdateOverall();
    }
    public void SetPassing(int passing)
    {
        ValidateSkillValue(passing, nameof(Passing));
        this.Passing = passing;
        UpdateOverall();
    }
    public void SetVision(int vision)
    {
        ValidateSkillValue(vision, nameof(Vision));
        this.Vision = vision;
        UpdateOverall();
    }
    public void SetCrossing(int crossing)
    {
        ValidateSkillValue(crossing, nameof(Crossing));
        this.Crossing = crossing;
        UpdateOverall();
    }
    public void SetLongPassing(int longPassing)
    {
        ValidateSkillValue(longPassing, nameof(LongPassing));
        this.LongPassing = longPassing;
        UpdateOverall();
    }
    public void SetDribbling(int dribbling)
    {
        ValidateSkillValue(dribbling, nameof(Dribbling));
        this.Dribbling = dribbling;
        UpdateOverall();
    }
    public void SetAgility(int agility)
    {
        ValidateSkillValue(agility, nameof(Agility));
        this.Agility = agility;
        UpdateOverall();
    }
    public void SetBallControl(int ballControl)
    {
        ValidateSkillValue(ballControl, nameof(BallControl));
        this.BallControl = ballControl;
        UpdateOverall();
    }
    public void SetDefending(int defending)
    {
        ValidateSkillValue(defending, nameof(Defending));
        this.Defending = defending;
        UpdateOverall();
    }
    public void SetTackling(int tackling)
    {
        ValidateSkillValue(tackling, nameof(Tackling));
        this.Tackling = tackling;
        UpdateOverall();
    }
    public void SetMarking(int marking)
    {
        ValidateSkillValue(marking, nameof(Marking));
        this.Marking = marking;
        UpdateOverall();
    }
    public void SetInterception(int interception)
    {
        ValidateSkillValue(interception, nameof(Interception));
        this.Interception = interception;
        UpdateOverall();
    }
    public void SetDefensiveVision(int defensiveVision)
    {
        ValidateSkillValue(defensiveVision, nameof(DefensiveVision));
        this.DefensiveVision = defensiveVision;
        UpdateOverall();
    }
    public void SetGoalkeepingPositioning(int goalkeepingPositioning)
    {
        ValidateSkillValue(goalkeepingPositioning, nameof(GoalkeepingPositioning));
        this.GoalkeepingPositioning = goalkeepingPositioning;
        UpdateOverall();
    }
    public void SetReflexes(int reflexes)
    {
        ValidateSkillValue(reflexes, nameof(Reflexes));
        this.Reflexes = reflexes;
        UpdateOverall();
    }
    public void SetHandling(int handling)
    {
        ValidateSkillValue(handling, nameof(Handling));
        this.Handling = handling;
        UpdateOverall();
    }
    public void SetDiving(int diving)
    {
        ValidateSkillValue(diving, nameof(Diving));
        this.Diving = diving;
        UpdateOverall();
    }
    public void UpdateOverall()
    {
        var sum = Composure + Positioning + Aggressiveness + Determination + Leadership + Teamwork +
                   Pace + Acceleration + Stamina + Strength + Jumping +
                   Finishing + LongShots + ShotPower + Heading +
                   Passing + Vision + Crossing + LongPassing + Dribbling + Agility + BallControl +
                   Defending + Tackling + Marking + Interception + DefensiveVision +
                   Reflexes + Handling + Diving + GoalkeepingPositioning;
        
        this.Overall = sum / 31;
    }
}

