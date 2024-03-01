
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    [Header("test")]
    public ItemHealthPotion HealthPotion;
    public ItemManaPotion ManaPotion;

    public PlayerStats Stats => stats;
    public PlayerMana PlayerMana { get; private set; }
    public PlayerHeath PlayerHeath { get; private set; }

    public PlayerAttack PlayerAttack { get; set; }

    private PlayerAnimations animations;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (HealthPotion.UseItem())
            {
                Debug.Log("Using Health Potion");
            }
            if (ManaPotion.UseItem())
            {
                Debug.Log("Using Mana Potion");
            }
        }
    }

    private void Awake()
    {
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHeath = GetComponent<PlayerHeath>();
        animations = GetComponent<PlayerAnimations>();
        PlayerAttack = GetComponent<PlayerAttack>();
    }
    public void ResetPlayer()
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
        PlayerMana.ResetMana();
    }
}
