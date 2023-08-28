using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] List<CountiniusEffect> countiniusEffectsApplided = new List<CountiniusEffect>();
    [SerializeField] List<OneTimeEffect> oneTimeEffectsApplided = new List<OneTimeEffect>();

    [SerializeField] List<CountiniusEffect> countiniusEffect = new List<CountiniusEffect>();
    [SerializeField]List<OneTimeEffect> oneTimeEffects = new List<OneTimeEffect>();

    [SerializeField] CardMAnager cardMAnager;

    [SerializeField] EnemyManager enemyManager;
    [SerializeField] Player player;
    private void Awake()
    {
        for (int i = 0; i < countiniusEffect.Count; i++)
        {
            countiniusEffect[i] = Instantiate(countiniusEffect[i]);
            countiniusEffect[i].Initialize(this, enemyManager, player);
        }
        for (int i = 0; i < oneTimeEffects.Count; i++)
        {
            oneTimeEffects[i] = Instantiate(oneTimeEffects[i]);
            countiniusEffect[i].Initialize(this, enemyManager, player);
        }
    }
    private void Update()
    {
        foreach (var _effect in countiniusEffectsApplided)
        {
            _effect.ProccesFrame(Time.deltaTime);
        }
    }


    [ContextMenu("ShowCards")]
    public void ShowCards()
    {
        List<Effect> effectshow = new List<Effect>();

        for (int i = 0; i < countiniusEffectsApplided.Count; i++)
        {
            if (countiniusEffectsApplided[i].Level < 10)   
                effectshow.Add(countiniusEffectsApplided[i]);
        }
        for (int i = 0; i < oneTimeEffectsApplided.Count; i++)
        {
            if (oneTimeEffectsApplided[i].Level < 10)  
                effectshow.Add(oneTimeEffectsApplided[i]);
        }

           if (countiniusEffectsApplided.Count < 4)
            effectshow.AddRange(countiniusEffect);
            
           if (oneTimeEffectsApplided.Count < 4)
            effectshow.AddRange(oneTimeEffects);



        int numberOfCardToShow = Mathf.Min(effectshow.Count, 3);


        int[] randomIndex = RandomSort(effectshow.Count, numberOfCardToShow);

        List<Effect> effectsForCard = new List<Effect>();
        for (int i = 0; i < randomIndex.Length; i++)
        {
            int index = randomIndex[i];
            effectsForCard.Add(effectshow[index]);
        }
        cardMAnager.ShowCards(effectsForCard);



    }


    // Метод берет length чисел и возвращает number случайных из них
    int[] RandomSort(int length, int number)
    {
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        for (int i = 0; i < array.Length; i++)
        {
            int oldValue = array[i];
            int newIndex = UnityEngine.Random.Range(0, array.Length);
            array[i] = array[newIndex];
            array[newIndex] = oldValue;
        }
        int[] result = new int[number];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }
        return result;
    }

    public void AddEffect(Effect _effect)
    {
        if(_effect is CountiniusEffect c_effect)
        {
            if(!countiniusEffectsApplided.Contains(c_effect))
            {
                countiniusEffectsApplided.Add(c_effect);
                countiniusEffect.Remove(c_effect);
            }
        }
        else if (_effect is OneTimeEffect o_effect)
        {
            if(! oneTimeEffectsApplided.Contains(o_effect))
            {
                oneTimeEffectsApplided.Add(o_effect);
                oneTimeEffects.Remove(o_effect);
            }
        }
        _effect.Activate();
    }


}
