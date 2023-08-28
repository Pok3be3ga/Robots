using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpirienceManager : MonoBehaviour
{
    [SerializeField] float expirience = 0;
    [SerializeField] float nextLevelExpirience = 5;

    int level;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image expirienceScale;

    [SerializeField] EffectManager effectManager;

    [SerializeField] AnimationCurve expirienceCurve;
    private void Awake()
    {
         nextLevelExpirience = expirienceCurve.Evaluate(0);
    }
    public void AddExpirience(int value)
    {
        expirience += value;
        if(expirience >= nextLevelExpirience)
        {
            UpLevel();
        }
        DisplayExpirience();
    }

    public void UpLevel()
    {
        level++;
        effectManager.ShowCards();
        levelText.text = level.ToString();
        expirience = 0;
        nextLevelExpirience = expirienceCurve.Evaluate(level);

    }

    void DisplayExpirience()
    {
        expirienceScale.fillAmount = expirience / nextLevelExpirience;
    }
}
