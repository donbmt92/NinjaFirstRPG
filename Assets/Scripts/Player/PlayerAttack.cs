using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlayerAttack: MonoBehaviour {

    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform[] attackPosition;


    [Header("Melee Config")]
    [SerializeField] private ParticleSystem slashFX;
    [SerializeField] private float minDistanceMeleeAttack;

    public Weapon CurrentWeapon { get; set; }
    
    private PlayerActions actions;
    private PlayerAnimations playerAnimations;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;
    private EnemyBrain enemyTarget;
    private Coroutine attackCoroutine;

    private Transform currentAttackPosition;
    private float currentAttackRotation;

    private void Awake()
    {
        actions = new PlayerActions();
        playerMovement = GetComponent<PlayerMovement>();
        playerMana = GetComponent<PlayerMana>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        WeaponManager.Instance.EquipWeapon(initialWeapon);
        actions.Attack.ClickAttack.performed += ctx => Attack();
    }

    private void Update()
    {
        CurrentWeapon = initialWeapon;
        GetFirePosition();
    }
    private void Attack()
    {
        if (enemyTarget == null) return;
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = StartCoroutine(IEAttack());
    }
    public void EquipWeapon(Weapon newWeapon)
    {
        CurrentWeapon = newWeapon;
        stats.TotalDamage = stats.BaseDamage + CurrentWeapon.Damage;
    }

    private float GetAttackDamage()
    {
        float damage = stats.BaseDamage;
        damage += CurrentWeapon.Damage;
        float randomPerc = Random.Range(0, 100);
        if (randomPerc <= stats.CriticalChange)
        {
            damage += damage * (stats.CriticalDamage / 100f);
        }
        return damage;
    }
    private void GetFirePosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;
        switch (moveDirection.x)
        {
            case > 0f:
                currentAttackPosition = attackPosition[1];
                currentAttackRotation = -90f;
                break;
            case < 0f:
                currentAttackPosition = attackPosition[3];
                currentAttackRotation = -270f;
                break;
        }
        switch (moveDirection.y)
        {
            case > 0f:
                currentAttackPosition = attackPosition[0];
                currentAttackRotation = 0f;
                break;
            case < 0f:
                currentAttackPosition = attackPosition[2];
                currentAttackRotation = -180f;
                break;
        }
    }

    private IEnumerator IEAttack()
    {
        if (currentAttackPosition == null) yield break;
        if (CurrentWeapon.WeaponType == WeaponType.Magic)
        {
            if (playerMana.CurrentMana < initialWeapon.RequiredMana)
            {
                yield break;
            }
            MagicAttack();
        }
        else
        {
            MeleeAttack();
        }
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttackAnimation(false);
    }
    private void MagicAttack()
    {
        Quaternion rotation =
                Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        Projectile projectile = Instantiate(initialWeapon.ProjectilePrefab,
            currentAttackPosition.position, rotation);
        projectile.Direction = Vector3.up;
        projectile.Damage = GetAttackDamage();
        playerMana.UseMana(initialWeapon.RequiredMana);
    }
    private void MeleeAttack()
    {
        slashFX.transform.position = currentAttackPosition.position;
        slashFX.Play();
        float currentDistanceToEnemy = 
            Vector3.Distance(enemyTarget.transform.position,transform.position);
        if (currentDistanceToEnemy <= minDistanceMeleeAttack)
        {
            enemyTarget.GetComponent<IDamageable>().takeDamage(GetAttackDamage());
        }

    }
    private void OnEnable()
    {
        actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectedEvent += NoEnemySelectedCallback;
        EnemyHealth.OnEnemyDeadEvent += NoEnemySelectedCallback;
    }

    private void NoEnemySelectedCallback()
    {
        enemyTarget = null;
    }

    private void EnemySelectedCallback(EnemyBrain enemySelected)
    {
        enemyTarget = enemySelected;
    }

    private void OnDisable()
    {
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNoSelectedEvent -= NoEnemySelectedCallback;
        EnemyHealth.OnEnemyDeadEvent -= NoEnemySelectedCallback;
    }
}
