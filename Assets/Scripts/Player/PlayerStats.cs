using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Strength,
    Dexterity,
    Intelligence
}

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    // Start is called before the first frame update
    [Header("Config")]
    public float level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("EXP")]
    public float CurrentExp;
    public float NextLevelExp;
    public float InitialNextLevelExp;
    [Range(1f,100f)] public float ExpMultiplier;

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalChange;
    public float CriticalDamage;

    [Header("Attribute")]
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int AttributePoints;

    [HideInInspector] public float TotalExp;
    [HideInInspector] public float TotalDamage;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        level = 1f;
        CurrentExp = 1f;
        NextLevelExp = InitialNextLevelExp;
        TotalExp = 0f;
        BaseDamage = 2;
        CriticalChange = 10;
        CriticalDamage = 50;
        Strength = 0;
        Dexterity = 0;
        Intelligence = 0;
        AttributePoints = 0;
    }
}
