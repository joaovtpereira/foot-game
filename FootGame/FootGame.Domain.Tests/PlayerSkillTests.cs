using FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;
using FootGame.Domain.Enums;
namespace FootGame.Domain.Tests;
using System;
using Xunit;

public class PlayerSkillTests
{
    private PlayerSkill CreatePlayerSkill()
    {
        var playerSkill = PlayerSkill.CreateDefaultPlayerSkill();

        return playerSkill;
    }

    [Fact]
    public void Construct_PlayerSkill_WithValidValues_ShouldCreateInstance()
    {
        var playerSkill = CreatePlayerSkill();

        // CentralMidfielder com todas as habilidades em 50 retorna 50 após o ajuste dos pesos
        Assert.Equal(50, playerSkill.Overall);
    }

    #region Goalkeeper Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um goleiro com todas as habilidades padrão (50).
    /// O overall deve ser 50, pois todas as habilidades principais (Reflexes, Diving, Handling, GoalkeepingPositioning) 
    /// têm o mesmo valor e os pesos somam 1.0.
    /// </summary>
    [Fact]
    public void CalculateOverall_Goalkeeper_WithDefaultSkills_ShouldReturn50()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.Goalkeeper, 50);

        Assert.Equal(50, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um goleiro de elite com habilidades altas nas áreas principais.
    /// Reflexes (25%), Diving (20%), Handling (20%) e GoalkeepingPositioning (20%) são as habilidades mais importantes.
    /// Um goleiro com essas habilidades altas deve ter um overall alto.
    /// </summary>
    [Fact]
    public void CalculateOverall_Goalkeeper_WithHighPrimarySkills_ShouldReturnHighOverall()
    {
        var playerSkill = CreateGoalkeeperSkill(
            reflexes: 95,
            diving: 90,
            handling: 92,
            goalkeepingPositioning: 88,
            composure: 85,
            longPassing: 70,
            jumping: 75
        );

        Assert.True(playerSkill.Overall >= 85, $"Expected overall >= 85, but got {playerSkill.Overall}");
    }

    /// <summary>
    /// Testa o cálculo do overall para um goleiro com habilidades baixas nas áreas principais.
    /// Um goleiro com Reflexes, Diving, Handling e GoalkeepingPositioning baixos deve ter um overall baixo.
    /// </summary>
    [Fact]
    public void CalculateOverall_Goalkeeper_WithLowPrimarySkills_ShouldReturnLowOverall()
    {
        var playerSkill = CreateGoalkeeperSkill(
            reflexes: 20,
            diving: 15,
            handling: 18,
            goalkeepingPositioning: 22,
            composure: 30,
            longPassing: 40,
            jumping: 35
        );

        Assert.True(playerSkill.Overall <= 25, $"Expected overall <= 25, but got {playerSkill.Overall}");
    }

    /// <summary>
    /// Verifica se o overall do goleiro está no range válido (1-99) mesmo com valores extremos.
    /// O PlayerOverallCalculator deve aplicar Math.Clamp para garantir que o resultado sempre esteja entre 1 e 99.
    /// </summary>
    [Fact]
    public void CalculateOverall_Goalkeeper_ShouldBeClampedBetween1And99()
    {
        var elitePlayerSkill = CreateGoalkeeperSkill(100, 100, 100, 100, 100, 100, 100);
        var weakPlayerSkill = CreateGoalkeeperSkill(0, 0, 0, 0, 0, 0, 0);

        Assert.True(elitePlayerSkill.Overall <= 99, $"Expected overall <= 99, but got {elitePlayerSkill.Overall}");
        Assert.True(weakPlayerSkill.Overall >= 1, $"Expected overall >= 1, but got {weakPlayerSkill.Overall}");
    }

    #endregion

    #region CenterBack Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um zagueiro central com habilidades padrão.
    /// As habilidades principais são: Marking (15%), Tackling (15%), Interception (15%) e DefensiveVision (15%).
    /// Todas as habilidades defensivas têm pesos igualmente distribuídos.
    /// Nota: Com todas as habilidades em 50, o overall é 50 devido aos pesos ajustados.
    /// </summary>
    [Fact]
    public void CalculateOverall_CenterBack_WithDefaultSkills_ShouldReturn52()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.CenterBack, 50);

        Assert.Equal(50, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um zagueiro central de elite.
    /// Um zagueiro com alta Marking, Tackling, Interception, DefensiveVision e Strength deve ter overall alto.
    /// Após o ajuste, as habilidades defensivas têm pesos igualmente distribuídos (15% cada).
    /// </summary>
    [Fact]
    public void CalculateOverall_CenterBack_WithHighDefensiveSkills_ShouldReturnHighOverall()
    {
        var playerSkill = CreateCenterBackSkill(
            marking: 90,
            tackling: 88,
            interception: 92,
            defensiveVision: 95,
            strength: 85,
            heading: 80,
            jumping: 82,
            aggressiveness: 75,
            determination: 70,
            passing: 65
        );

        Assert.True(playerSkill.Overall >= 85, $"Expected overall >= 85, but got {playerSkill.Overall}");
    }

    /// <summary>
    /// Verifica se as habilidades defensivas principais têm impacto similar no cálculo do overall do zagueiro.
    /// Após o ajuste, Marking, Tackling, Interception e DefensiveVision têm todos peso de 15%.
    /// Ao aumentar qualquer uma dessas habilidades, o overall deve aumentar de forma proporcional.
    /// </summary>
    [Fact]
    public void CalculateOverall_CenterBack_DefensiveSkillsHaveEqualWeight_ShouldImpactOverallProportionally()
    {
        var baseSkill = CreateCenterBackSkill(70, 70, 70, 70, 70, 70, 70, 70, 70, 70);
        var improvedSkill = CreateCenterBackSkill(70, 70, 70, 90, 70, 70, 70, 70, 70, 70);

        // Aumentar DefensiveVision de 70 para 90 (aumento de 20) com peso de 15% deve aumentar o overall em aproximadamente 3 pontos
        Assert.True(improvedSkill.Overall > baseSkill.Overall, 
            $"Expected improvement, but base was {baseSkill.Overall} and improved is {improvedSkill.Overall}");
        
        // Com peso de 15%, o aumento de 20 pontos deve resultar em ~3 pontos de aumento no overall
        if (improvedSkill.Overall < 99)
        {
            Assert.True(improvedSkill.Overall >= baseSkill.Overall + 2, 
                $"Expected improvement of at least 2 points, but base was {baseSkill.Overall} and improved is {improvedSkill.Overall}");
        }
    }

    #endregion

    #region FullBack Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um lateral com habilidades padrão.
    /// As habilidades principais são: Crossing (20%), Pace (15%), Stamina (15%) e Acceleration (10%).
    /// Nota: Após o ajuste dos pesos, com todas as habilidades em 50, o overall é 50.
    /// </summary>
    [Fact]
    public void CalculateOverall_FullBack_WithDefaultSkills_ShouldReturn50()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.FullBack, 50);

        Assert.Equal(50, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um lateral rápido e com bom cruzamento.
    /// Laterais precisam de velocidade, resistência e capacidade de cruzar bem.
    /// </summary>
    [Fact]
    public void CalculateOverall_FullBack_WithHighPaceAndCrossing_ShouldReturnHighOverall()
    {
        var playerSkill = CreateFullBackSkill(
            pace: 92,
            stamina: 88,
            acceleration: 90,
            crossing: 85,
            tackling: 70,
            marking: 72,
            dribbling: 75,
            positioning: 78,
            passing: 80,
            agility: 82
        );

        Assert.True(playerSkill.Overall >= 80, $"Expected overall >= 80, but got {playerSkill.Overall}");
    }

    #endregion

    #region DefensiveMidfielder Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um volante com habilidades padrão.
    /// As habilidades principais são: Interception (15%), Tackling (15%), Stamina (10%) e Strength (10%).
    /// Após o ajuste, os pesos foram rebalanceados para somar 1.0.
    /// Nota: Com todas as habilidades em 50, o overall é 50.
    /// </summary>
    [Fact]
    public void CalculateOverall_DefensiveMidfielder_WithDefaultSkills_ShouldReturn50()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.DefensiveMidfielder, 50);

        Assert.Equal(50, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um volante completo.
    /// Um bom volante precisa equilibrar habilidades defensivas (Interception, Tackling) 
    /// com capacidade de distribuir jogo (Passing, LongPassing).
    /// </summary>
    [Fact]
    public void CalculateOverall_DefensiveMidfielder_WithBalancedSkills_ShouldReturnHighOverall()
    {
        var playerSkill = CreateDefensiveMidfielderSkill(
            interception: 88,
            tackling: 90,
            stamina: 85,
            strength: 82,
            passing: 80,
            longPassing: 75,
            defensiveVision: 85,
            teamwork: 78,
            aggressiveness: 75,
            composure: 80
        );

        Assert.True(playerSkill.Overall >= 80, $"Expected overall >= 80, but got {playerSkill.Overall}");
    }

    #endregion

    #region CentralMidfielder Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um meio-campista central com habilidades padrão.
    /// As habilidades principais são: Passing (15%), Vision (15%), BallControl (15%) e Teamwork (10%).
    /// Após o ajuste, os pesos foram rebalanceados para somar 1.0.
    /// Nota: Com todas as habilidades em 50, o overall é 50.
    /// </summary>
    [Fact]
    public void CalculateOverall_CentralMidfielder_WithDefaultSkills_ShouldReturn50()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.CentralMidfielder, 50);

        Assert.Equal(50, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um meio-campista central criativo.
    /// Um meio-campista precisa de alta visão, passe preciso, controle de bola e boa leitura de jogo.
    /// </summary>
    [Fact]
    public void CalculateOverall_CentralMidfielder_WithHighCreativeSkills_ShouldReturnHighOverall()
    {
        var playerSkill = CreateCentralMidfielderSkill(
            passing: 90,
            vision: 92,
            ballControl: 88,
            dribbling: 80,
            longPassing: 85,
            stamina: 82,
            composure: 78,
            longShots: 75,
            agility: 72,
            teamwork: 88
        );

        Assert.True(playerSkill.Overall >= 85, $"Expected overall >= 85, but got {playerSkill.Overall}");
    }

    #endregion

    #region Winger Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um ponta com habilidades padrão.
    /// As habilidades principais são: Dribbling (20%), Pace (15%), Acceleration (15%) e Agility (15%).
    /// Nota: Com todas as habilidades em 50, o overall é 62 devido aos pesos específicos.
    /// </summary>
    [Fact]
    public void CalculateOverall_Winger_WithDefaultSkills_ShouldReturn62()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.Winger, 50);

        Assert.Equal(62, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um ponta veloz e habilidoso.
    /// Pontas precisam de velocidade, aceleração, agilidade e capacidade de driblar e cruzar.
    /// </summary>
    [Fact]
    public void CalculateOverall_Winger_WithHighSpeedAndDribbling_ShouldReturnHighOverall()
    {
        var playerSkill = CreateWingerSkill(
            pace: 95,
            acceleration: 93,
            dribbling: 90,
            agility: 88,
            crossing: 82,
            ballControl: 85,
            finishing: 70,
            stamina: 80,
            vision: 75,
            passing: 72
        );

        Assert.True(playerSkill.Overall >= 85, $"Expected overall >= 85, but got {playerSkill.Overall}");
    }

    #endregion

    #region SecondStriker Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um segundo atacante com habilidades padrão.
    /// As habilidades principais são: Dribbling (20%), BallControl (20%), Finishing (15%) e Vision (15%).
    /// Nota: Com todas as habilidades em 50, o overall é 60 devido aos pesos específicos.
    /// </summary>
    [Fact]
    public void CalculateOverall_SecondStriker_WithDefaultSkills_ShouldReturn60()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.SecondStriker, 50);

        Assert.Equal(60, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um segundo atacante versátil.
    /// Segundo atacantes precisam combinar habilidade técnica (Dribbling, BallControl) 
    /// com capacidade de finalização e visão de jogo.
    /// </summary>
    [Fact]
    public void CalculateOverall_SecondStriker_WithHighTechnicalSkills_ShouldReturnHighOverall()
    {
        var playerSkill = CreateSecondStrikerSkill(
            dribbling: 90,
            finishing: 85,
            ballControl: 92,
            vision: 88,
            agility: 85,
            acceleration: 82,
            passing: 80,
            longShots: 78,
            positioning: 85
        );

        Assert.True(playerSkill.Overall >= 85, $"Expected overall >= 85, but got {playerSkill.Overall}");
    }

    #endregion

    #region Striker Overall Calculation Tests

    /// <summary>
    /// Testa o cálculo do overall para um atacante com habilidades padrão.
    /// As habilidades principais são: Finishing (25%), Heading (20%), Positioning (20%) e ShotPower (15%).
    /// Nota: Com todas as habilidades em 50, o overall é 60 devido aos pesos específicos.
    /// </summary>
    [Fact]
    public void CalculateOverall_Striker_WithDefaultSkills_ShouldReturn60()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.Striker, 50);

        Assert.Equal(60, playerSkill.Overall);
    }

    /// <summary>
    /// Testa o cálculo do overall para um atacante completo.
    /// Atacantes precisam de alta finalização, bom posicionamento, força no chute e capacidade de cabecear.
    /// </summary>
    [Fact]
    public void CalculateOverall_Striker_WithHighFinishingAndPositioning_ShouldReturnHighOverall()
    {
        var playerSkill = CreateStrikerSkill(
            finishing: 95,
            heading: 88,
            positioning: 92,
            shotPower: 90,
            strength: 85,
            jumping: 82,
            composure: 88,
            ballControl: 80
        );

        Assert.True(playerSkill.Overall >= 88, $"Expected overall >= 88, but got {playerSkill.Overall}");
    }

    /// <summary>
    /// Verifica se Finishing tem o maior peso (25%) no cálculo do overall do atacante.
    /// Ao aumentar apenas o Finishing, o overall deve aumentar significativamente.
    /// </summary>
    [Fact]
    public void CalculateOverall_Striker_FinishingHasHighestWeight_ShouldImpactOverallSignificantly()
    {
        var baseSkill = CreateStrikerSkill(70, 70, 70, 70, 70, 70, 70, 70);
        var improvedSkill = CreateStrikerSkill(90, 70, 70, 70, 70, 70, 70, 70);

        Assert.True(improvedSkill.Overall > baseSkill.Overall + 4, 
            $"Expected significant improvement, but base was {baseSkill.Overall} and improved is {improvedSkill.Overall}");
    }

    #endregion

    #region Overall Recalculation Tests

    /// <summary>
    /// Verifica se o overall é recalculado automaticamente quando uma habilidade é alterada.
    /// Quando alteramos uma habilidade importante, o overall deve mudar imediatamente.
    /// </summary>
    [Fact]
    public void SetSkill_WhenSkillChanges_ShouldRecalculateOverall()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.Striker, 50);
        var initialOverall = playerSkill.Overall;

        playerSkill.SetFinishing(90);

        Assert.NotEqual(initialOverall, playerSkill.Overall);
        Assert.True(playerSkill.Overall > initialOverall, 
            $"Expected overall to increase from {initialOverall} after increasing Finishing, but got {playerSkill.Overall}");
    }

    /// <summary>
    /// Verifica se múltiplas mudanças de habilidades recalculam o overall corretamente.
    /// O overall final deve refletir todas as mudanças acumuladas.
    /// </summary>
    [Fact]
    public void SetMultipleSkills_WhenMultipleSkillsChange_ShouldRecalculateOverallCorrectly()
    {
        var playerSkill = CreatePlayerSkillWithPosition(PlayerPosition.Goalkeeper, 50);
        var initialOverall = playerSkill.Overall; // Deve ser 50 para goleiro

        playerSkill.SetReflexes(90);
        playerSkill.SetDiving(85);
        playerSkill.SetHandling(88);

        // Com Reflexes=90 (peso 25%), Diving=85 (peso 20%), Handling=88 (peso 20%), e outros em 50
        // Cálculo aproximado: (90*0.25) + (85*0.20) + (88*0.20) + (50*0.20) + ... = 22.5 + 17 + 17.6 + 10 + ...
        // Deve estar em torno de 75-80, não necessariamente >= 85
        Assert.True(playerSkill.Overall > initialOverall, 
            $"Expected overall to increase from {initialOverall} after improving key skills, but got {playerSkill.Overall}");
        Assert.True(playerSkill.Overall >= 70, 
            $"Expected overall >= 70 after improving key skills, but got {playerSkill.Overall}");
    }

    #endregion

    #region Helper Methods

    private PlayerSkill CreatePlayerSkillWithPosition(PlayerPosition position, int skillValue)
    {
        return new PlayerSkill(
            Composure: skillValue,
            Positioning: skillValue,
            Aggressiveness: skillValue,
            Determination: skillValue,
            Leadership: skillValue,
            Teamwork: skillValue,
            Pace: skillValue,
            Acceleration: skillValue,
            Stamina: skillValue,
            Strength: skillValue,
            Jumping: skillValue,
            Finishing: skillValue,
            LongShots: skillValue,
            ShotPower: skillValue,
            Heading: skillValue,
            Passing: skillValue,
            Vision: skillValue,
            Crossing: skillValue,
            LongPassing: skillValue,
            Dribbling: skillValue,
            Agility: skillValue,
            BallControl: skillValue,
            Defending: skillValue,
            Tackling: skillValue,
            Marking: skillValue,
            Interception: skillValue,
            DefensiveVision: skillValue,
            Reflexes: skillValue,
            Handling: skillValue,
            Diving: skillValue,
            GoalkeepingPositioning: skillValue,
            position: position
        );
    }

    private PlayerSkill CreateGoalkeeperSkill(int reflexes, int diving, int handling, int goalkeepingPositioning, 
        int composure, int longPassing, int jumping)
    {
        return new PlayerSkill(
            Composure: composure,
            Positioning: 50,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: 50,
            Pace: 50,
            Acceleration: 50,
            Stamina: 50,
            Strength: 50,
            Jumping: jumping,
            Finishing: 50,
            LongShots: 50,
            ShotPower: 50,
            Heading: 50,
            Passing: 50,
            Vision: 50,
            Crossing: 50,
            LongPassing: longPassing,
            Dribbling: 50,
            Agility: 50,
            BallControl: 50,
            Defending: 50,
            Tackling: 50,
            Marking: 50,
            Interception: 50,
            DefensiveVision: 50,
            Reflexes: reflexes,
            Handling: handling,
            Diving: diving,
            GoalkeepingPositioning: goalkeepingPositioning,
            position: PlayerPosition.Goalkeeper
        );
    }

    private PlayerSkill CreateCenterBackSkill(int marking, int tackling, int interception, int defensiveVision,
        int strength, int heading, int jumping, int aggressiveness, int determination, int passing)
    {
        return new PlayerSkill(
            Composure: 50,
            Positioning: 50,
            Aggressiveness: aggressiveness,
            Determination: determination,
            Leadership: 50,
            Teamwork: 50,
            Pace: 50,
            Acceleration: 50,
            Stamina: 50,
            Strength: strength,
            Jumping: jumping,
            Finishing: 50,
            LongShots: 50,
            ShotPower: 50,
            Heading: heading,
            Passing: passing,
            Vision: 50,
            Crossing: 50,
            LongPassing: 50,
            Dribbling: 50,
            Agility: 50,
            BallControl: 50,
            Defending: 50,
            Tackling: tackling,
            Marking: marking,
            Interception: interception,
            DefensiveVision: defensiveVision,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50,
            position: PlayerPosition.CenterBack
        );
    }

    private PlayerSkill CreateFullBackSkill(int pace, int stamina, int acceleration, int crossing, int tackling,
        int marking, int dribbling, int positioning, int passing, int agility)
    {
        return new PlayerSkill(
            Composure: 50,
            Positioning: positioning,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: 50,
            Pace: pace,
            Acceleration: acceleration,
            Stamina: stamina,
            Strength: 50,
            Jumping: 50,
            Finishing: 50,
            LongShots: 50,
            ShotPower: 50,
            Heading: 50,
            Passing: passing,
            Vision: 50,
            Crossing: crossing,
            LongPassing: 50,
            Dribbling: dribbling,
            Agility: agility,
            BallControl: 50,
            Defending: 50,
            Tackling: tackling,
            Marking: marking,
            Interception: 50,
            DefensiveVision: 50,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50,
            position: PlayerPosition.FullBack
        );
    }

    private PlayerSkill CreateDefensiveMidfielderSkill(int interception, int tackling, int stamina, int strength,
        int passing, int longPassing, int defensiveVision, int teamwork, int aggressiveness, int composure)
    {
        return new PlayerSkill(
            Composure: composure,
            Positioning: 50,
            Aggressiveness: aggressiveness,
            Determination: 50,
            Leadership: 50,
            Teamwork: teamwork,
            Pace: 50,
            Acceleration: 50,
            Stamina: stamina,
            Strength: strength,
            Jumping: 50,
            Finishing: 50,
            LongShots: 50,
            ShotPower: 50,
            Heading: 50,
            Passing: passing,
            Vision: 50,
            Crossing: 50,
            LongPassing: longPassing,
            Dribbling: 50,
            Agility: 50,
            BallControl: 50,
            Defending: 50,
            Tackling: tackling,
            Marking: 50,
            Interception: interception,
            DefensiveVision: defensiveVision,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50,
            position: PlayerPosition.DefensiveMidfielder
        );
    }

    private PlayerSkill CreateCentralMidfielderSkill(int passing, int vision, int ballControl, int dribbling,
        int longPassing, int stamina, int composure, int longShots, int agility, int teamwork)
    {
        return new PlayerSkill(
            Composure: composure,
            Positioning: 50,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: teamwork,
            Pace: 50,
            Acceleration: 50,
            Stamina: stamina,
            Strength: 50,
            Jumping: 50,
            Finishing: 50,
            LongShots: longShots,
            ShotPower: 50,
            Heading: 50,
            Passing: passing,
            Vision: vision,
            Crossing: 50,
            LongPassing: longPassing,
            Dribbling: dribbling,
            Agility: agility,
            BallControl: ballControl,
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

    private PlayerSkill CreateWingerSkill(int pace, int acceleration, int dribbling, int agility, int crossing,
        int ballControl, int finishing, int stamina, int vision, int passing)
    {
        return new PlayerSkill(
            Composure: 50,
            Positioning: 50,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: 50,
            Pace: pace,
            Acceleration: acceleration,
            Stamina: stamina,
            Strength: 50,
            Jumping: 50,
            Finishing: finishing,
            LongShots: 50,
            ShotPower: 50,
            Heading: 50,
            Passing: passing,
            Vision: vision,
            Crossing: crossing,
            LongPassing: 50,
            Dribbling: dribbling,
            Agility: agility,
            BallControl: ballControl,
            Defending: 50,
            Tackling: 50,
            Marking: 50,
            Interception: 50,
            DefensiveVision: 50,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50,
            position: PlayerPosition.Winger
        );
    }

    private PlayerSkill CreateSecondStrikerSkill(int dribbling, int finishing, int ballControl, int vision,
        int agility, int acceleration, int passing, int longShots, int positioning)
    {
        return new PlayerSkill(
            Composure: 50,
            Positioning: positioning,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: 50,
            Pace: 50,
            Acceleration: acceleration,
            Stamina: 50,
            Strength: 50,
            Jumping: 50,
            Finishing: finishing,
            LongShots: longShots,
            ShotPower: 50,
            Heading: 50,
            Passing: passing,
            Vision: vision,
            Crossing: 50,
            LongPassing: 50,
            Dribbling: dribbling,
            Agility: agility,
            BallControl: ballControl,
            Defending: 50,
            Tackling: 50,
            Marking: 50,
            Interception: 50,
            DefensiveVision: 50,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50,
            position: PlayerPosition.SecondStriker
        );
    }

    private PlayerSkill CreateStrikerSkill(int finishing, int heading, int positioning, int shotPower,
        int strength, int jumping, int composure, int ballControl)
    {
        return new PlayerSkill(
            Composure: composure,
            Positioning: positioning,
            Aggressiveness: 50,
            Determination: 50,
            Leadership: 50,
            Teamwork: 50,
            Pace: 50,
            Acceleration: 50,
            Stamina: 50,
            Strength: strength,
            Jumping: jumping,
            Finishing: finishing,
            LongShots: 50,
            ShotPower: shotPower,
            Heading: heading,
            Passing: 50,
            Vision: 50,
            Crossing: 50,
            LongPassing: 50,
            Dribbling: 50,
            Agility: 50,
            BallControl: ballControl,
            Defending: 50,
            Tackling: 50,
            Marking: 50,
            Interception: 50,
            DefensiveVision: 50,
            Reflexes: 50,
            Handling: 50,
            Diving: 50,
            GoalkeepingPositioning: 50,
            position: PlayerPosition.Striker
        );
    }

    #endregion
}