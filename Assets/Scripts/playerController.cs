using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float horizontal;
    public float speed;
    public float jumpForce;
    public Color col;

    bool Right = true;

    public Transform grabPosition;
    public Transform rayPoint;
    public float rayDistance;
    private GameObject grabbedObject;

    private Rigidbody2D myRigidBody;
    [SerializeField] private float totalColectables;

    

    private bool camina;

    public float TotalColectables { get => totalColectables; set => totalColectables = value; }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = col;
        UnityEditor.Handles.DrawSolidDisc(transform.position, transform.transform.forward, 2);
        UnityEditor.Handles.color = Color.cyan;
        UnityEditor.Handles.DrawSolidDisc(rayPoint.transform.position, rayPoint.transform.forward, rayDistance);

    }
#endif

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //  animationManager = GetComponent<Animator>();
    }

    void Update()
    {
        Flip(horizontal);

        horizontal = Input.GetAxis("Horizontal");
        myRigidBody.velocity = new Vector2(horizontal * speed, this.myRigidBody.velocity.y);

        camina = horizontal != 0;

        if (Input.GetButtonDown("Jump"))
        {
            myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        // Alzar cajas
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.tag == "Seed")
        {
            if (Input.GetKeyDown(KeyCode.X) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPosition.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }

        }

    }

    void Flip(float xVelocity)
    {
        bool needFlip = false;

        if (xVelocity > 0 && !Right)
        {
            needFlip = true;
            Right = true;
        }

        else if (xVelocity < 0 && Right)
        {
            needFlip = true;
            Right = false;
        }

        if (needFlip)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, Right ? 0 : 180, transform.rotation.z);
        }
    }
    public void recibeCollectable(float valorColectable)
    {
        TotalColectables += valorColectable;
    }

    internal void recibeDamage(int v)
    {
        Debug.Log("se murioooo");
    }

}