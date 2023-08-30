using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform target;
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
