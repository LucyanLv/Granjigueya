using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSlot : MonoBehaviour
{

    public bool available;
    public bool is_filled;
    public Sprite root;
    public Sprite sleepingSeed;
    public GameObject dispenser;
    public Transform pos;
    [SerializeField] public GameObject Seed;



    // Start is called before the first frame update
    void Start()
    {
        dispenser = GameObject.Find("seedDispenser");
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
                //Destroy(collision.gameObject);
                this.GetComponent<SpriteRenderer>().sprite = root;
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = sleepingSeed;
                Instantiate(Seed, pos.position, pos.rotation);
                this.is_filled = true;
            }
        }
        else if (!available)
        {
            if (collision.gameObject.tag.Equals("Seed"))
            {
                Destroy(collision.gameObject);
                Instantiate(Seed, pos.position, pos.rotation);
            }
        }
        

    }
}
