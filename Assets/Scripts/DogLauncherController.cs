using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLauncherController : MonoBehaviour
{
    [SerializeField] GameObject Municion;
    [SerializeField] int segs;
    [SerializeField] bool isShooting;
    [SerializeField] int timeShooting;
    [SerializeField] int waitToShoot;

    public DogLauncherController(GameObject municion)
    {
        Municion = municion;

    }


    // Start is called before the first frame update
    void Start()
    {
        isShooting = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isShooting == true)
        {
            StartCoroutine(go());
        }
    }

    void Shot()
    {
        Instantiate(Municion, transform.position, transform.rotation);

    }

    IEnumerator go()
    {
        isShooting = false;
        yield return new WaitForSeconds(segs);
        Shot();
        isShooting = true;


    }
}
