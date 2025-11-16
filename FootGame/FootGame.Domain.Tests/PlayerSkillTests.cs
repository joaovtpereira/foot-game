using FootGame.Domain.Entities;
using FootGame.Domain.ValueObjects;
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

        Assert.Equal(50, playerSkill.Overall);
    }
}