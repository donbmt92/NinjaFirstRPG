using UnityEngine;

public class PlayerExp: MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(300f);
        }
    }

    public void AddExp(float amout)
    {
        stats.TotalExp += amout;
        stats.CurrentExp += amout;
        while (stats.CurrentExp > stats.NextLevelExp)
        {
            stats.CurrentExp -= stats.NextLevelExp;
            NextLevel();
        }
    }
    public void NextLevel()
    {
        stats.level++;
        stats.AttributePoints++;
        float currentExpRequired = stats.NextLevelExp;
        float newNextLevelExp = Mathf.Round(currentExpRequired + stats.NextLevelExp * (stats.ExpMultiplier / 100f));
        stats.NextLevelExp = newNextLevelExp;
    }
}