using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI damageTMP;

    public void setDamageText(float damage)
    {
        damageTMP.text = damage.ToString();
    }

    public void destroyText()
    {
        Destroy(gameObject);
    }
}
