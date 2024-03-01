using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteracrtionType
{
    Quest,
    Shop
}

[CreateAssetMenu(menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public Sprite Icon;

    [Header("Interaction")]
    public bool HasInteraction;
    public InteracrtionType InteracrtionType;

    [Header("Dialog")]
    public string Greeting;
    [TextArea] public string[] Dialogue;
}
