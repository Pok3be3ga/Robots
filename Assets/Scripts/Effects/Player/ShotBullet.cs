using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField] MagicMissle magicMisslePrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] Player player;

    [SerializeField] float colldown;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > colldown)
        {
            StartCoroutine("Effectprocess");
            timer = 0;
        }
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
