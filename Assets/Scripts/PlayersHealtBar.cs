using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersHealtBar : MonoBehaviour
{
    [SerializeField] Image scale;
    [SerializeField] PlayerHealth playerHealth;


    private void Awake()
    {
        playerHealth.OnHealthChange += SetScale;
    }
    public void SetScale(float _currentHealth, float _maxHealth)
    {
        scale.fillAmount = _currentHealth / _maxHealth;
    }
}
