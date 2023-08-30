using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Animator animator;


    void Update()
    {
        if (rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity, Vector3.up);
            animator.SetBool("Run", true);
        }else
        {
            animator.SetBool("Run", false);
        }
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        rigidbody.velocity = new Vector3(inputVector.x, rigidbody.velocity.y, inputVector.z) * moveSpeed;

    }
}
