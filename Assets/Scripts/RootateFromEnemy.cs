using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RootateFromEnemy : MonoBehaviour
{
    public string targetTag = "Enemy"; // Тег объектов, к которым нужно повернуться
    public float searchRadius = 10f; // Радиус поиска ближайшего объекта
    public float rotationSpeed = 5f; // Скорость поворота игрока

    private Transform nearestTarget; // Ближайший объект

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float colldown;//
    float timer;//

    void Update()
    {
        // Находим все объекты с заданным тегом в радиусе searchRadius
        Collider[] targets = Physics.OverlapSphere(transform.position, searchRadius, LayerMask.GetMask(targetTag));

        if (targets.Length > 0)
        {
            // Находим ближайший объект
            float nearestDistance = Mathf.Infinity;
            foreach (Collider target in targets)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < nearestDistance)
                {
                    nearestTarget = target.transform;
                    nearestDistance = distance;
                }
            }

            // Поворачиваем игрока в сторону ближайшего объекта
            Vector3 direction = nearestTarget.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            
        }

    }
}

