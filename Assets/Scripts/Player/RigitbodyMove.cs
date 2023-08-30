using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitbodyMove : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float speed;
    [SerializeField] Joystick joystick;
    [SerializeField] Animator animator;

    Vector2 moveInput;

    void Update()
    {
        moveInput = joystick.Value;
        animator.SetBool("Run", joystick.IsPressed);
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(moveInput.x, 0 , moveInput.y) * speed;
        if(rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity, Vector3.up);
        }
    }
}
