using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public float CurrentMana { get; private set; }

    private void Start()
    {
        ResetMana();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            UseMana(1f);
        }
    }
    public void UseMana(float amount)
    {
        stats.Mana = Mathf.Max(stats.Mana -= amount, 0f);
        CurrentMana = stats.Mana;
    }

    public void RecoverMana(float amount)
    {
        stats.Mana += amount;
        stats.Mana = Mathf.Min(stats.Mana, stats.MaxMana);
        CurrentMana = stats.Mana;
    }

    public bool CanRecoverMana()
    {
        return stats.Mana > 0 && stats.Mana < stats.MaxMana;
    }

    public void ResetMana()
    {
        CurrentMana = stats.MaxMana;
    }
}