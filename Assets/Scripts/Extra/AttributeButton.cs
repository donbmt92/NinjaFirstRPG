using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class AttributeButton : MonoBehaviour
{
 /*   public static event Action<Attribute> OnAttributeSelectedEvent;
    [Header("Config")]
    [SerializeField] private Attribute attribute;

    private void SelectAttribute()
    {
        OnAttributeSelectedEvent?.Invoke(attribute);
    }*/
    public static event Action<AttributeType> OnAttributeSelectedEvent;

    [Header("Config")]
    [SerializeField] private AttributeType attribute;

    public void SelectAttribute()
    {
        UnityEngine.Debug.Log(attribute);
        OnAttributeSelectedEvent?.Invoke(attribute);
    }
}
