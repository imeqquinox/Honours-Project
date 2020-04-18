using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController character_controller;

    private float speed = 6.0f;
    private float jump_speed = 8.0f;
    private float gravity = 20.0f;

    private Vector3 move_direction = Vector3.zero; 

    private void Start()
    {
        character_controller = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        if (character_controller.isGrounded)
        {
            move_direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move_direction *= speed;
            move_direction = Camera.main.transform.TransformDirection(move_direction); 

            if (Input.GetButton("Jump"))
            {
                move_direction.y = jump_speed; 
            }
        }

        move_direction.y -= gravity * Time.deltaTime;

        character_controller.Move(move_direction * Time.deltaTime); 
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}
