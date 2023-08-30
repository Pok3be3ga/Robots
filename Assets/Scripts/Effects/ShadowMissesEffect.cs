using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(ShadowMissesEffect), menuName = "Effects/ContinuousEffect/" + nameof(ShadowMissesEffect))]
public class ShadowMissesEffect : CountiniusEffect
{


    [Space (10)]
    [SerializeField] ShadowMissile shadowMissilePrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float damage;
    protected override void Produce()
    {
        base.Produce();

        Transform playertransform = player.transform;
        int number = 5;
        

        for (int i = 0; i < number; i++)
        {
            float angle = (360 / number) * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * playertransform.forward;
            ShadowMissile newBullet = Instantiate(shadowMissilePrefab, playertransform.position, Quaternion.identity);
            newBullet.Setup(direction * bulletSpeed, damage, 2);
        }
        
    }
}
