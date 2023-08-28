using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RootateFromEnemy : MonoBehaviour
{
    public string targetTag = "Enemy"; // ��� ��������, � ������� ����� �����������
    public float searchRadius = 10f; // ������ ������ ���������� �������
    public float rotationSpeed = 5f; // �������� �������� ������

    private Transform nearestTarget; // ��������� ������

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float colldown;//
    float timer;//

    void Update()
    {
        // ������� ��� ������� � �������� ����� � ������� searchRadius
        Collider[] targets = Physics.OverlapSphere(transform.position, searchRadius, LayerMask.GetMask(targetTag));

        if (targets.Length > 0)
        {
            // ������� ��������� ������
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

            // ������������ ������ � ������� ���������� �������
            Vector3 direction = nearestTarget.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            
        }

    }
}

