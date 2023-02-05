using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicionController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Damage;

     void Update()
    {
        transform.Translate((Vector3.right * Speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().recibeDamage(1);
        }

        else if (other.tag == "Limit")
        {
            Destroy(this.gameObject);
        }
    }
}
