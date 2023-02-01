using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool facingRight = true;
    public Transform spriteTransform;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, vertical, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);

        //Flip en el eje X
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = spriteTransform.localScale;
            theScale.x *= -1;
            spriteTransform.localScale = theScale;
        }
    }
}
