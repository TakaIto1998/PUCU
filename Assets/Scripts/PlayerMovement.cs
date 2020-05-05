using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
      public CharacterController controller;

      public float moveSpeed = 8f;
      public float gravity = -9.81f * 3;
      public float jumpHeight = 2.5f;

      public Transform groundCheck;
      public float groundDistance = 0.4f;
      public LayerMask groundMask;

      Vector3 velocity;
      bool isGrounded;

      Vector3 jumpDirection;

      // Update is called once per frame
      void Update()
      {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if(isGrounded && velocity.y <= 0)
            {
                  velocity.y = -2f;
            }

            Vector3 move;
            if(!isGrounded)
            {
                  move = jumpDirection;
                  controller.Move(move * moveSpeed * Time.deltaTime);
            }
            else
            {
                  float x = Input.GetAxis("Horizontal");
                  float z = Input.GetAxis("Vertical");

                  move = transform.right * x + transform.forward * z;
                  controller.Move(move * moveSpeed * Time.deltaTime);

                  jumpDirection = move;
            }

            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
      }
}