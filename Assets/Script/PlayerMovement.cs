using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector3 moveDirection;

        public float speed;

        public float rotSpeed;

        public float jumpSpeed;
        private float ySpeed;
        private bool isGrounded = false;

        private CharacterController characterController;

        // Start is called before the first frame update
        void Start()
        {
        characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);
            moveDirection.Normalize();
            float magnitude = moveDirection.magnitude;
            magnitude = Mathf.Clamp01(magnitude);

            characterController.SimpleMove(moveDirection * magnitude * speed);

            ySpeed += Physics.gravity.y * Time.deltaTime;

            if(Input.GetButtonDown("Jump"))
            {
                ySpeed = -0.5f;
                isGrounded = false;
            }

            Vector3 vel = moveDirection * magnitude;
            vel.y = ySpeed;
            characterController.Move(vel * Time.deltaTime);

            if (characterController.isGrounded)
            {
                ySpeed = -1.5f;
                isGrounded = true;
                if(Input.GetButtonDown("Jump"))
                {
                    ySpeed = jumpSpeed;
                    isGrounded = false;
                }
            }
            

            Camera.main.transform.position = transform.position + new Vector3(0, 1, -8);


            if(moveDirection != Vector3.zero)
            {
                Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotSpeed * Time.deltaTime);
            }
        }
    }
}
