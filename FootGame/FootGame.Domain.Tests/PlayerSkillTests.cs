using FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;
namespace FootGame.Domain.Tests;
using System;
using Xunit;

public class PlayerSkillTests
{
    private PlayerSkill CreatePlayerSkill()
    {
        var playerSkill = new PlayerSkill(pace: 50, shooting: 50, passing: 50, dribbling: 50, defending: 50, physicality: 50, goalkeeping: 50);

        return playerSkill;
    }

    [Fact]
    public void Construct_PlayerSkill_WithValidValues_ShouldCreateInstance()
    {
        var playerSkill = CreatePlayerSkill();

        Assert.Equal(50, playerSkill.Pace);
        Assert.Equal(50, playerSkill.Shooting);
        Assert.Equal(50, playerSkill.Passing);
        Assert.Equal(50, playerSkill.Dribbling);
        Assert.Equal(50, playerSkill.Defending);
        Assert.Equal(50, playerSkill.Physicality);
        Assert.Equal(50, playerSkill.Goalkeeping);

        Assert.Equal(50, playerSkill.Overall);
    }
}