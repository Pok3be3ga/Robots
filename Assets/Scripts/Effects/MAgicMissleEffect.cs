using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(MAgicMissleEffect), menuName = "Effects/ContinuousEffect/" + nameof(MAgicMissleEffect))]
public class MAgicMissleEffect : CountiniusEffect
{
    [SerializeField] MagicMissle magicMisslePrefab;
    [SerializeField] float bulletSpeed;

    protected override void Produce()
    {
        base.Produce();
        effectManager.StartCoroutine(Effectprocess());

    }

    private IEnumerator Effectprocess()
    {
        int _number = 4;
        Enemy[] nearestEnemies = enemyManager.GetNearest(player.transform.position, _number);
        if (nearestEnemies.Length > 0 )
        {
            for (int i = 0; i < nearestEnemies.Length; i++)
            {
                Vector3 position = player.transform.position;
                MagicMissle magicMissle = Instantiate(magicMisslePrefab, position, Quaternion.identity);
                magicMissle.Init(nearestEnemies[i], 20, bulletSpeed);
                yield return new WaitForSeconds(0.2f);

            }
        }
    }
}
