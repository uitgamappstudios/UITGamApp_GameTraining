using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHealth(float current, float total)
    {
        healthBar.value = (float)current / total;
        healthText.text = current.ToString();
    }
}
