using UnityEngine;

public class DamageManager: Singleton<DamageManager>
{
    [Header("Config")]
    [SerializeField] private DamageText damageTextPrefab;

    public void ShowDamageText(float damageAmout, Transform parent)
    {
        DamageText text =  Instantiate(damageTextPrefab, parent);
        text.transform.position += Vector3.right * 0.5f;
        text.setDamageText(damageAmout);
    }
}
