using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (stats.Health <= 0)
        {
            playDead();
        }
        
    }

    public void RestoreHealth(float amount)
    {
        stats.Health += amount;
        if(stats.Health > stats.MaxHealth)
        {
            stats.Health = stats.MaxHealth;
        }
    }
    public void takeDamage(float amout)
    {
        if (stats.Health <= 0) return;
            stats.Health -= amout;
        DamageManager.Instance.ShowDamageText(amout, transform);
        if (stats.Health <= 0)
        {
            stats.Health = 0f;
            playDead();
        }
    }
    public bool CanRestoreHealth()
    {
        return stats.Health > 0 && stats.Health < stats.MaxHealth;
    }
    private void playDead()
    {
        playerAnimations.SetDeadAnimation();
    }
   
}
