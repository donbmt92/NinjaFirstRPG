using System;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject selectorSprite;

    private EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    private void OnEnable()
    {
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectedEvent += NoSelectionCallback;
    }

    

    private void OnDisable()
    {
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNoSelectedEvent -= NoSelectionCallback;

    }

    private void EnemySelectedCallback(EnemyBrain enemySelected)
    {
        if (enemySelected == enemyBrain)
        {
            selectorSprite.SetActive(true);
        }
        else
        {
            selectorSprite.SetActive(false);
        }
    }
    public void NoSelectionCallback()
    {
        selectorSprite.SetActive(false);
    }
}


