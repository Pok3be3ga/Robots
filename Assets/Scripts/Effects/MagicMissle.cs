using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissle : MonoBehaviour
{

    Enemy targetEnemy;
    float Speed;
    float damage;


    public void Init(Enemy _targetEnemy, float _damage, float _speed)
    {
        damage = _damage;
        targetEnemy = _targetEnemy;
        Speed = _speed;
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        if (targetEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, Speed * Time.deltaTime);
            if(transform.position == targetEnemy.transform.position)
            {
                AffectEnemy();
                Destroy(gameObject);    
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void AffectEnemy()
    {
        targetEnemy.SetDamage(damage);
    }
}
