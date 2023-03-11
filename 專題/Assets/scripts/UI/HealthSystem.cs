﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private int healthAmount;
    private int healthAmountMax;
    public HealthSystem(int healAmount)
    {
        healthAmount = healthAmountMax;
        this.healthAmount = healthAmount;
    }    
    public void Damage(int amount)
    {
        healthAmount -= amount;
        if(healthAmount<0)
        {
            healthAmount = 0;
        }
        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);
    }
    public void Heal(int amount)
    {
        healthAmount += amount;
        if(healthAmount>healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
        if (OnHealed != null) OnHealed(this, EventArgs.Empty);
    }    
    public float GetHealthNormalized()
    {
        return healthAmount / healthAmountMax;
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
