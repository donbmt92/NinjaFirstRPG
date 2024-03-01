using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestCard : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI questNameTMP;
    [SerializeField] private TextMeshProUGUI questDesTMP;

    public Quest QuestToComplete { get; set; }

    public virtual void ConfigQuestUI(Quest quest)
    {
        QuestToComplete = quest;
        questNameTMP.text = quest.Name;
        questDesTMP.text = quest.Description;
    }
}
