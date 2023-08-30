using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxhealth;
    float currenthealth;

    public event Action<float, float> OnHealthChange;
    public event Action OnDie;

    [SerializeField] GameStateManager gameStateManager;
    private void Start()
    {
        SetHealth(maxhealth);
    }
    public void TakeDamage(float value)
    {
        float newHealth = currenthealth - value;
        newHealth = Mathf.Max(newHealth, 0);
        SetHealth(newHealth);
        if(newHealth == 0)
        {
            Die();
        }
    }

    void SetHealth(float value)
    {
        currenthealth = value;
        OnHealthChange?.Invoke(currenthealth, maxhealth);
    }

    void Die()
    {
        OnDie?.Invoke();
        gameStateManager.SetLose();
    }
}
