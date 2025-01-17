using System.Collections;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements.Experimental;

public class MonsterScriptTests
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator getID_ValidInt_ReturnsID() // Check if ID is set correctly on GenerateMonster
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        int monsterID = monsterScript.getID();

        // Assert
        Assert.AreEqual(0, monsterID);
    }

    [UnityTest]
    public IEnumerator GenerateMonster_NegativeInt_ThrowsError() // Check if monster can be generated with invalid ID
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();

        // Act
        try
        {
            monsterScript.GenerateMonster(stubRoom, -1, MonsterScript._monsterType.player);

        }
        // Assert
        catch
        {
            Assert.Pass();
        }
        yield return null;

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator getRoom_ValidParams_ReturnsRoom() // Check if room is set correctly
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject mockRoom = new GameObject();

        // Act
        monsterScript.GenerateMonster(mockRoom, 0, MonsterScript._monsterType.player);
        yield return null;
        GameObject monsterScriptRoom = monsterScript.getRoom();

        // Assert
        Assert.AreEqual(mockRoom, monsterScriptRoom);
    }

    [UnityTest]
    public IEnumerator getMonsterType_ValidParams_ReturnsMonsterType() // Check if monster type is set correctly
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        MonsterScript._monsterType monsterTypeMock = MonsterScript._monsterType.player;

        // Act
        monsterScript.GenerateMonster(stubRoom, 0, monsterTypeMock);
        yield return null;
        MonsterScript._monsterType monsterScriptType = monsterScript.getMonsterType();

        // Assert
        Assert.AreEqual(monsterTypeMock, monsterScriptType);
    }

    [UnityTest]
    public IEnumerator takeDamage_ZeroDamage_HealthUnaffected() // Check if health is unaffected when taking zero damage
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float healthBeforeDamage = monsterScript.getHealth();
        monsterScript.takeDamage(0);
        float healthAfterDamage = monsterScript.getHealth();

        // Assert
        Assert.AreEqual(healthBeforeDamage, healthAfterDamage);
    }

    [UnityTest]
    public IEnumerator takeDamage_NonZeroDamage_HealthDecreases() // Check if health is unaffected when taking zero damage
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float healthBeforeDamage = monsterScript.getHealth();
        monsterScript.takeDamage(1);
        float healthAfterDamage = monsterScript.getHealth();

        // Assert
        Assert.True(healthBeforeDamage > healthAfterDamage);
    }

    [UnityTest]
    public IEnumerator heal_ZeroAmount_HealthUnaffected() // Check if health is unaffected when healing by zero amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float healthBeforeHeal = monsterScript.getHealth();
        monsterScript.heal(0);
        float healthAfterHeal = monsterScript.getHealth();

        // Assert
        Assert.AreEqual(healthBeforeHeal, healthAfterHeal);
    }

    [UnityTest]
    public IEnumerator heal_OneAmount_HealthIncreases() // Check if health increases when healing by one amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        monsterScript.takeDamage(1);
        float healthBeforeHeal = monsterScript.getHealth();
        monsterScript.heal(1);
        float healthAfterHeal = monsterScript.getHealth();

        // Assert
        Assert.True(healthBeforeHeal < healthAfterHeal);
    }

    [UnityTest]
    public IEnumerator attackBuff_ZeroAmount_AttackDmgUnaffected() // Check if attack damage is unaffected when buffing by zero amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float atkDmgBeforeBuff = monsterScript.getAttackDamage();
        monsterScript.attackBuff(0);
        float atkDmgAfterBuff = monsterScript.getAttackDamage();

        // Assert
        Assert.AreEqual(atkDmgBeforeBuff, atkDmgAfterBuff);
    }

    [UnityTest]
    public IEnumerator attackBuff_NegativeAmount_ThrowsError() // Check if attack damage can be buffed by negative amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        try
        {
            monsterScript.attackBuff(-1);

        }
        // Assert
        catch
        {
            Assert.Pass();
        }
        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator attackBuff_PositiveAmount_AttackDmgIncreases() // Check if attack damage increases when buffed by positive amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float atkDmgBeforeBuff = monsterScript.getAttackDamage();
        monsterScript.attackBuff(1);
        float atkDmgAfterBuff = monsterScript.getAttackDamage();

        // Assert
        Assert.True(atkDmgBeforeBuff < atkDmgAfterBuff);
    }

    [UnityTest]
    public IEnumerator attackDebuff_ZeroAmount_AttackDmgUnaffected() // Check if attack damage is unaffected when debuffing by zero amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float atkDmgBeforeBuff = monsterScript.getAttackDamage();
        monsterScript.attackDebuff(0);
        float atkDmgAfterBuff = monsterScript.getAttackDamage();

        // Assert
        Assert.AreEqual(atkDmgBeforeBuff, atkDmgAfterBuff);
    }

    [UnityTest]
    public IEnumerator attackDebuff_NegativeAmount_ThrowsError() // Check if attack damage can be debuffed by negative amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        try
        {
            monsterScript.attackDebuff(-1);

        }
        // Assert
        catch
        {
            Assert.Pass();
        }
        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator attackDebuff_PositiveAmount_AttackDmgDecreases() // Check if attack damage decreases when debuffed by positive amount
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        float atkDmgBeforeBuff = monsterScript.getAttackDamage();
        monsterScript.attackDebuff(1);
        float atkDmgAfterBuff = monsterScript.getAttackDamage();

        // Assert
        Assert.True(atkDmgBeforeBuff > atkDmgAfterBuff);
    }

    [UnityTest]
    public IEnumerator attack_NonexistentTarget_ThrowsError() // Check if nonexistent target can be attacked
    {
        // Arrange
        GameObject stubObject = new GameObject();
        stubObject.AddComponent<MonsterScript>();
        MonsterScript monsterScript = stubObject.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScript.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        // Act
        try
        {
            monsterScript.attack(-1);
        }
        // Assert
        catch
        {
            Assert.Pass();
        }
        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator attack_ValidTarget_RunsSuccessfully() // Check if a valid target can be attacked
    {
        // Arrange
        GameObject stubObjectDamager = new GameObject();
        stubObjectDamager.AddComponent<MonsterScript>();
        MonsterScript monsterScriptDamager = stubObjectDamager.GetComponent<MonsterScript>();
        GameObject stubRoom = new GameObject();
        monsterScriptDamager.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;

        GameObject stubObjectVictim = new GameObject();
        stubObjectVictim.AddComponent<MonsterScript>();
        MonsterScript monsterScriptVictim = stubObjectVictim.GetComponent<MonsterScript>();
        monsterScriptVictim.GenerateMonster(stubRoom, 0, MonsterScript._monsterType.player);
        yield return null;
        int victimId = monsterScriptVictim.getID();

        // Act
        try
        {
            monsterScriptDamager.attack(victimId);
        }
        // Assert
        catch
        {
            Assert.Fail();
        }
        Assert.Pass();
    }
}
