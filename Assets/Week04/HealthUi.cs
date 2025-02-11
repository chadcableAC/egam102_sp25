using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    public Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        HealthPlayer hpPlayer = FindObjectOfType<HealthPlayer>();
        if (hpPlayer != null)
        {
            float healthInterp = (float) hpPlayer.currentHealth / hpPlayer.maxHealth;
            hpSlider.value = healthInterp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
