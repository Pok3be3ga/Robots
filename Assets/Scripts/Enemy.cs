using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed;
    [SerializeField] float speedRotation;
    [SerializeField] Rigidbody rigidbody;


    float attackTimer;
    [SerializeField] float attackPeriod = 1f;
    [SerializeField] float dps;

    PlayerHealth playerHealth;
    [SerializeField] float health = 50f;
    [SerializeField] GameObject dieEffect;

    [SerializeField] GameObject LootPrefab;

    EnemyManager enemyManager;
    public void Init(Transform _playerTransform, EnemyManager _enemyManager)
    {
        playerTransform = _playerTransform;
        enemyManager = _enemyManager;
    }


    private void Update()
    {
        if (playerHealth)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer > attackPeriod)
            {
                playerHealth.TakeDamage(dps * attackPeriod);
                attackTimer = 0f;
            }
        }
    }
    private void FixedUpdate()
    {
        if (playerTransform)
        {
            Vector3 _toPlayer = playerTransform.position - transform.position;
            Quaternion _toPlayerRotation = Quaternion.LookRotation(_toPlayer, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, _toPlayerRotation, Time.deltaTime * speedRotation);
            rigidbody.velocity = transform.forward * speed;

            if(_toPlayer.magnitude > 50)
            {
                transform.position += _toPlayer * 1.95f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>() is PlayerHealth _playerHealth)
        {
            playerHealth = _playerHealth;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            playerHealth = null;
        }
    }

    public void SetDamage(float _value)
    {
        health -= _value;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        enemyManager.RemoveEnemy(this);
        Destroy(gameObject);
        Instantiate(LootPrefab, transform.position, Quaternion.identity);
    }
}
