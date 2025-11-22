namespace FootGame.Domain.ValueObjects;
using FootGame.Domain.Enums;
using FootGame.Domain.Services;
public class PlayerSkill
{
    // Mentality

    /// <summary>
    /// Habilidade do jogador manter a calma e o controle sob pressão.
    /// </summary>
    public int Composure { get; private set; }

    /// <summary>
    /// Habilidade do jogador se posicionar corretamente em campo.
    /// </summary>
    public int Positioning { get; private set; }

    /// <summary>
    /// Habilidade do jogador ser agressivo em disputas e jogadas.
    /// </summary>
    public int Aggressiveness { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter determinação e vontade de vencer e não desistir.
    /// </summary>
    public int Determination { get; private set; }

    /// <summary>
    /// Habilidade do jogador ser líder dentro e fora de campo.
    /// </summary>
    public int Leadership { get; private set; }

    /// <summary>
    /// Habilidade do jogador trabalhar em equipe e colaborar com os companheiros.
    /// </summary>
    public int Teamwork { get; private set; }

    // Physical

    /// <summary>
    /// Habilidade do jogador ter velocidade máxima.
    /// </summary>
    public int Pace { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter aceleração rápida.
    /// </summary>
    public int Acceleration { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter resistência física.
    /// </summary>
    public int Stamina { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter força física.
    /// </summary>
    public int Strength { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de saltar alto.
    /// </summary>
    public int Jumping { get; private set; }

    // Technical Attack

    /// <summary>
    /// Habilidade do jogador ter capacidade de finalizar e marcar gols.
    /// </summary>
    public int Finishing { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de chutar de longa distância.
    /// </summary>
    public int LongShots { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de chutar com força.
    /// </summary>
    public int ShotPower { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de cabecear a bola.
    /// </summary>
    public int Heading { get; private set; }

    // Technical General

    /// <summary>
    /// Habilidade do jogador ter capacidade de passar a bola.
    /// </summary>
    public int Passing { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de enxergar jogadas e oportunidades.
    /// </summary>
    public int Vision { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de cruzar a bola.
    /// </summary>
    public int Crossing { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de passar de longa distância.
    /// </summary>
    public int LongPassing { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de driblar adversários.
    /// </summary>
    public int Dribbling { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de ser ágil e flexível.
    /// Determina a capacidade de executar movimentos rápidos e precisos, afetando a capacidade de driblar.
    /// </summary>
    public int Agility { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de controlar a bola.
    /// </summary>
    public int BallControl { get; private set; }

    // Technical Defense

    /// <summary>
    /// Habilidade do jogador ter capacidade de defender, principalmente a inteligência defensiva.
    /// </summary>
    public int Defending { get; private set; }

    /// <summary>
    /// Habilidade do jogador de roubar a bola de adversários.
    /// </summary>
    public int Tackling { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de marcar adversários.
    /// </summary>
    public int Marking { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de interceptar a bola de adversários.
    /// </summary>
    public int Interception { get; private set; }

    /// <summary>
    /// Habilidade do jogador ter capacidade de analisar a situação do jogo e tomar decisões defensivas.
    /// </summary>
    public int DefensiveVision { get; private set; }

    // Goalkeeping

    /// <summary>
    /// Habilidade do goleiro ter capacidade de reagir rapidamente a jogadas e chutes.
    /// </summary>
    public int Reflexes { get; private set; }

    /// <summary>
    /// Habilidade do goleiro ter capacidade de se posicionar corretamente para defender.
    /// </summary>
    public int GoalkeepingPositioning { get; private set; }

    /// <summary>
    /// Habilidade do goleiro ter capacidade de manipular a bola com precisão.
    /// </summary>
    public int Handling { get; private set; }

    /// <summary>
    /// Habilidade do goleiro ter capacidade de defender chutes de longa distância.
    /// </summary>
    public int Diving { get; private set; }

    public int Overall { get; private set; }
    public PlayerPosition Position { get; private set; }

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
        int GoalkeepingPositioning,
        PlayerPosition position)
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
        this.Position = position;
        CalculateOverall(); ;
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
            GoalkeepingPositioning: 50,
            position: PlayerPosition.CentralMidfielder
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
        CalculateOverall();
    }

    public void SetPositioning(int positioning)
    {
        ValidateSkillValue(positioning, nameof(Positioning));
        this.Positioning = positioning;
        CalculateOverall();
    }

    public void SetAggressiveness(int aggressiveness)
    {
        ValidateSkillValue(aggressiveness, nameof(Aggressiveness));
        this.Aggressiveness = aggressiveness;
        CalculateOverall();
    }
    public void SetDetermination(int determination)
    {
        ValidateSkillValue(determination, nameof(Determination));
        this.Determination = determination;
        CalculateOverall();
    }
    public void SetLeadership(int leadership)
    {
        ValidateSkillValue(leadership, nameof(Leadership));
        this.Leadership = leadership;
        CalculateOverall();
    }
    public void SetTeamwork(int teamwork)
    {
        ValidateSkillValue(teamwork, nameof(Teamwork));
        this.Teamwork = teamwork;
        CalculateOverall();
    }
    public void SetPace(int pace)
    {
        ValidateSkillValue(pace, nameof(Pace));
        this.Pace = pace;
        CalculateOverall();
    }
    public void SetAcceleration(int acceleration)
    {
        ValidateSkillValue(acceleration, nameof(Acceleration));
        this.Acceleration = acceleration;
        CalculateOverall();
    }
    public void SetStamina(int stamina)
    {
        ValidateSkillValue(stamina, nameof(Stamina));
        this.Stamina = stamina;
        CalculateOverall();
    }
    public void SetStrength(int strength)
    {
        ValidateSkillValue(strength, nameof(Strength));
        this.Strength = strength;
        CalculateOverall();
    }
    public void SetJumping(int jumping)
    {
        ValidateSkillValue(jumping, nameof(Jumping));
        this.Jumping = jumping;
        CalculateOverall();
    }
    public void SetFinishing(int finishing)
    {
        ValidateSkillValue(finishing, nameof(Finishing));
        this.Finishing = finishing;
        CalculateOverall();
    }
    public void SetLongShots(int longShots)
    {
        ValidateSkillValue(longShots, nameof(LongShots));
        this.LongShots = longShots;
        CalculateOverall();
    }
    public void SetShotPower(int shotPower)
    {
        ValidateSkillValue(shotPower, nameof(ShotPower));
        this.ShotPower = shotPower;
        CalculateOverall();
    }
    public void SetHeading(int heading)
    {
        ValidateSkillValue(heading, nameof(Heading));
        this.Heading = heading;
        CalculateOverall();
    }
    public void SetPassing(int passing)
    {
        ValidateSkillValue(passing, nameof(Passing));
        this.Passing = passing;
        CalculateOverall();
    }
    public void SetVision(int vision)
    {
        ValidateSkillValue(vision, nameof(Vision));
        this.Vision = vision;
        CalculateOverall();
    }
    public void SetCrossing(int crossing)
    {
        ValidateSkillValue(crossing, nameof(Crossing));
        this.Crossing = crossing;
        CalculateOverall();
    }
    public void SetLongPassing(int longPassing)
    {
        ValidateSkillValue(longPassing, nameof(LongPassing));
        this.LongPassing = longPassing;
        CalculateOverall();
    }
    public void SetDribbling(int dribbling)
    {
        ValidateSkillValue(dribbling, nameof(Dribbling));
        this.Dribbling = dribbling;
        CalculateOverall();
    }
    public void SetAgility(int agility)
    {
        ValidateSkillValue(agility, nameof(Agility));
        this.Agility = agility;
        CalculateOverall();
    }
    public void SetBallControl(int ballControl)
    {
        ValidateSkillValue(ballControl, nameof(BallControl));
        this.BallControl = ballControl;
        CalculateOverall();
    }
    public void SetDefending(int defending)
    {
        ValidateSkillValue(defending, nameof(Defending));
        this.Defending = defending;
        CalculateOverall();
    }
    public void SetTackling(int tackling)
    {
        ValidateSkillValue(tackling, nameof(Tackling));
        this.Tackling = tackling;
        CalculateOverall();
    }
    public void SetMarking(int marking)
    {
        ValidateSkillValue(marking, nameof(Marking));
        this.Marking = marking;
        CalculateOverall();
    }
    public void SetInterception(int interception)
    {
        ValidateSkillValue(interception, nameof(Interception));
        this.Interception = interception;
        CalculateOverall();
    }
    public void SetDefensiveVision(int defensiveVision)
    {
        ValidateSkillValue(defensiveVision, nameof(DefensiveVision));
        this.DefensiveVision = defensiveVision;
        CalculateOverall();
    }
    public void SetGoalkeepingPositioning(int goalkeepingPositioning)
    {
        ValidateSkillValue(goalkeepingPositioning, nameof(GoalkeepingPositioning));
        this.GoalkeepingPositioning = goalkeepingPositioning;
        CalculateOverall();
    }
    public void SetReflexes(int reflexes)
    {
        ValidateSkillValue(reflexes, nameof(Reflexes));
        this.Reflexes = reflexes;
        CalculateOverall();
    }
    public void SetHandling(int handling)
    {
        ValidateSkillValue(handling, nameof(Handling));
        this.Handling = handling;
        CalculateOverall();
    }
    public void SetDiving(int diving)
    {
        ValidateSkillValue(diving, nameof(Diving));
        this.Diving = diving;
        CalculateOverall();
    }
    private void CalculateOverall()
    {
        var calculator = new PlayerOverallCalculator();
        var overall = calculator.CalculateOverall(this);
        this.Overall = overall;
    }
}

