using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static event Action OnEnemyDeadEvent;

    [Header("Config")]
    [SerializeField] private float health;

    private EnemyLoot enemyLoot;
    public float CurrentHealth { get; private set; }

    private Animator animator;
    private EnemyBrain enemyBrain;
    private EnemySelector enemySelector;
    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyBrain = GetComponent<EnemyBrain>();
        enemySelector = GetComponent<EnemySelector>();
        enemyLoot = GetComponent<EnemyLoot>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    public void takeDamage(float amout)
    {
        CurrentHealth -= amout;
        if (CurrentHealth <= 0f)
        {
            DisableEnemy();
            QuestManager.Instance.AddProgress("Kill5Enemy", 1);
            QuestManager.Instance.AddProgress("Kill2Enemy", 1);
        }
        else
        {
            DamageManager.Instance.ShowDamageText(amout, transform);
        }
    }

    private void DisableEnemy()
    {
        animator.SetTrigger("Dead");
        enemyBrain.enabled = false;
        enemySelector.NoSelectionCallback();
        /*gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");*/
        rb2D.bodyType = RigidbodyType2D.Static;
        OnEnemyDeadEvent?.Invoke();
        GameManager.Instance.AddPlayerExp(enemyLoot.ExpDrop);
    }
}

