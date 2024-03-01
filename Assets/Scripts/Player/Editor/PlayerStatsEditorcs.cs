using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditorcs : Editor
{
    private PlayerStats StatsTaget => target as PlayerStats;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset Player"))
        {
            StatsTaget.ResetPlayer();
        }
    }
}