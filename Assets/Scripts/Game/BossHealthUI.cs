using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _bossHealthBarForegroundImage;
    private BossHealth bossHealth;

    private void Start()
    {
        _bossHealthBarForegroundImage.fillAmount = bossHealth.RemainingHealthPercentage;
    }
    public void UpdateHealthBar(BossHealth bossHealth)
    {
        _bossHealthBarForegroundImage.fillAmount = bossHealth.RemainingHealthPercentage;
    }
}
