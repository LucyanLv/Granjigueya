using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSlot : MonoBehaviour
{

    public bool available;
    public bool is_filled;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (available && !is_filled)
        {
            if (collision.gameObject.tag.Equals("Seed"))
            {
                Destroy(collision);
                // cambio a sprite de raices
                // respawn semilla
            }
        }
    }
}
