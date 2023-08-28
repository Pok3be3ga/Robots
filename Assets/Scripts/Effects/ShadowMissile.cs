using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMissile : MonoBehaviour
{
    float damage;
    int passCount;

    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Collider collider;
    [SerializeField] ParticleSystem particleSystem;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Setup(Vector3 _velocity, float _damage, int _passCount)
    {
        transform.rotation = Quaternion.LookRotation(_velocity);
        damage = _damage;
        passCount = _passCount;
        rigidbody.velocity = _velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>() is Enemy _enemy)
        {
            _enemy.SetDamage(damage);
            passCount--;
            if(passCount == 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        rigidbody.velocity = Vector3.zero;
        collider.enabled = false;
        particleSystem.Stop();
        Destroy(gameObject);
    }

}
