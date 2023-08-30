using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] float distanceToCollect = 2f;
    [SerializeField] LayerMask layerMask;

    [SerializeField] ExpirienceManager expirienceManager;


    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceToCollect, layerMask, QueryTriggerInteraction.Ignore);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<Loot>() is Loot loot)
            {
                loot.Collect(this);
            }
        }
    }

    public void TakeExpirience(int value)
    {
        expirienceManager.AddExpirience(value);
    }

}
