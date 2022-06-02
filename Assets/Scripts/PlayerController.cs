using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 4f;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private float rotationSpeed = 720f;

    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {        
        Move();
    }

    private void Move()
    {
        // Handle Movement
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        controller.Move(direction * speed * Time.deltaTime);

        // Handle Rotation
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Handle Animation
        if (direction == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if (direction != Vector3.zero)
        {
            animator.SetFloat("Speed", 1);
        }
        
        //Carry Animation
    }


}
