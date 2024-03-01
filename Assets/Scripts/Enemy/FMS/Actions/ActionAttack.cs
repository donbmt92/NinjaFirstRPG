using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwAttack;

    private EnemyBrain EnemyBrain;
    private float timer;

    private void Awake()
    {
        EnemyBrain = GetComponent<EnemyBrain>();
    }
    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (EnemyBrain.Player == null) return;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            IDamageable player = EnemyBrain.Player.GetComponent<IDamageable>();
            PlayerHeath heath = EnemyBrain.Player.GetComponent<PlayerHeath>();
            player.takeDamage(damage);
            timer = timeBtwAttack;
        }
    }
}
