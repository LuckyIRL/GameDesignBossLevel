using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _bossHealthBarForegroundImage;
    public void UpdateHealthBar(BossHealth bossHealth)
    {
        _bossHealthBarForegroundImage.fillAmount = bossHealth.RemainingHealthPercentage;
    }
}
