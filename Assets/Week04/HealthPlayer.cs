using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }
}
