using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Sensibilidad = 100f;
    float Xrotation = 0f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")* Sensibilidad *Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")* Sensibilidad *Time.deltaTime;

        Xrotation -= MouseY;
        Xrotation = Math.Clamp(Xrotation,-90f,90f);
        
        transform.localRotation = Quaternion.Euler(Xrotation,0f,0f);
        player.Rotate(Vector3.up * MouseX);


    }
}
