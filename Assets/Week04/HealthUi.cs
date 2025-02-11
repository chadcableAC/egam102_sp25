using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    public Slider hpSlider;

    void Start()
    {
        HealthPlayer hpPlayer = FindObjectOfType<HealthPlayer>();
        if (hpPlayer != null)
        {
            // We're assuming the player's HP is set in Awake
            float healthInterp = (float) hpPlayer.currentHealth / hpPlayer.maxHealth;
            hpSlider.value = healthInterp;
        }
    }
}
