using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMAnager : MonoBehaviour
{
    [SerializeField] GameObject cardManagerParent;
    [SerializeField] Card[] effectCards;
    [SerializeField] EffectManager effectManager;

    [SerializeField] GameStateManager gameStateManager;
    private void Awake()
    {
        for (int i = 0; i < effectCards.Length; i++)
        {
            effectCards[i].Init(effectManager, this);
        }
    }
    public void ShowCards(List<Effect> effects)
    {
        cardManagerParent.SetActive(true);
        for (int i = 0; i < effects.Count; i++)
        {
            effectCards[i].Show(effects[i]);
        }
        gameStateManager.SetCardState();
    }

    public void Hide()
    {
        cardManagerParent.SetActive(false);
        gameStateManager.SetAction();
    }




}
