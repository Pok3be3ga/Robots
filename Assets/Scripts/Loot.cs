using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    [SerializeField] Collider collider;
    public void Collect(Collector _collector)
    {
        collider.enabled = false;
        StartCoroutine(MoveToCollector(_collector)); 
    }

    private IEnumerator MoveToCollector(Collector _collector)
    {
        Vector3 a = transform.position;
        Vector3 b = a + Vector3.up * 3;

        for (float t = 0; t < 1f; t += Time.deltaTime / 0.5f)
        {

            Vector3 d = _collector.transform.position;
            Vector3 c = d + Vector3.up * 3;


            Vector3 _position = Bezier.GetPoint(a, b, c, d, t);
            transform.position = _position;

            yield return null;
        }
        Take(_collector);
    }

    public virtual void Take(Collector _collector)
    {
        Destroy(gameObject);
    }

    
}
