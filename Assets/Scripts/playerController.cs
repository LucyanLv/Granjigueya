using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float horizontal;
    public float speed;
    public float jumpForce;
    public float timeHolding;

    //    public Transform pos;
    //    public float radio;
    //  public bool in_ground;
    //public bool in_water;
    //public bool can_dive;
    public bool _jump;
    // public LayerMask is_ground;
    // public LayerMask is_water;
    public Color col;

    bool Right = true;

    bool jump;

    //Agarre de la caja
    public Transform grabPosition;
    public Transform rayPoint;
    public float rayDistance;
    private GameObject grabbedObject;

    // Fin agarre de la caja

    [SerializeField] bool camina = false;

    //Animator animationManager;

    private Rigidbody2D myRigidBody;
    [SerializeField] private float totalColectables;

    public float TotalColectables { get => totalColectables; set => totalColectables = value; }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = col;
        //   UnityEditor.Handles.DrawSolidDisc(pos.position, pos.transform.forward, radio);
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
        // vertical = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector2(horizontal * speed, this.myRigidBody.velocity.y);

        camina = horizontal != 0;

        //in_ground = Physics2D.OverlapCircle(pos.position, radio, is_ground);
        //in_water = Physics2D.OverlapCircle(pos.position, radio, is_water);

        if (Input.GetButtonDown("Jump"))//&& in_ground && !in_water)
        {
            myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        // Alzar cajas
        //       RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        /*       if (hitInfo.collider != null && hitInfo.collider.gameObject.tag == "Water")
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
               //Animaci�n
               //animationManager.SetBool("Camina", camina);
               //animationManager.SetBool("Salta", in_ground);

               //Nadar animacion
               //animationManager.SetBool("Nada", in_water);
        */

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

    //Salto
    //   if (Input.GetKeyDown(KeyCode.Space) && canJump)
    //       {
    //          canJump = false;
    //         RB2D.AddForce(new Vector2(0, 250));
    //    }

    public void recibeCollectable(float valorColectable)
    {
        TotalColectables += valorColectable;
    }



}