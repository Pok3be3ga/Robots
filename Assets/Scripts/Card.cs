using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Image iconBackGround;
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Button button;

    [SerializeField] Sprite continuousEffectSprite;
    [SerializeField] Sprite oneTimeEffectSprite;



    EffectManager effectManager;
    CardMAnager cardMAnager;
    Effect effect;

    public void Init(EffectManager _effectManager, CardMAnager _cardMAnager)
    {
        effectManager = _effectManager;
        cardMAnager = _cardMAnager;
        button.onClick.AddListener(Click);
    }
    public void Show(Effect _effect)
    {
        effect = _effect;

        nameText.text =_effect.Name; 
        descriptionText.text =_effect.Description;
        levelText.text = _effect.Level.ToString();
        iconImage.sprite =_effect.Sprite;

        if (_effect is CountiniusEffect)
        {
            iconBackGround.sprite = continuousEffectSprite;
        }else if (_effect is OneTimeEffect)
         {
            iconBackGround.sprite = oneTimeEffectSprite;
        }

    }

    public void Click()
    {
        effectManager.AddEffect(effect);
        cardMAnager.Hide();
    }
}
