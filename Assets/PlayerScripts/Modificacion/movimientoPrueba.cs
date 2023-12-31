using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPrueba : MonoBehaviour
{
    //creamos la variable charactercontroller
    private CharacterController characterController;
    public float speed = 4f;
    public float gravity = -9.8f;

    private Animator animator;

    public new Transform camera;
    void Start()
    {
        //inicializamos la variable charactercontroller
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;

        if( hor != 0 || ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            //Hacemos el movimiento hacia a delante
            movement = direction * speed * Time.deltaTime;

           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),0.1f);

        }
        movement.y += gravity * Time.deltaTime;
        characterController.Move(movement);
        animator.SetFloat("Speed", movementSpeed);
        

    }
}
