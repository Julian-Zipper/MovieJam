using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShoot : MonoBehaviour {
    //find all sentinels, put them in a list
    //select a sentinel from the list as target
    //fire at target
    //if target stops existing, repeat from step 1

    private GameObject[] sentinels;
    private int random;
    private GameObject target;

    public float fireDelay = 0.5f; // public for easy adjusting during testing
    private float delayInit;

    private Vector2 direction;

    public float bulletVeloc = 1; // public for easy adjusting during testing
    public GameObject shotPrefab; // this is assigned in the inspector of the unit prefab

	void Start () {
        delayInit = fireDelay;
	}
	
	void Update () {
		if(target != null && fireDelay <= 0)
        {
            Fire();
            fireDelay = delayInit;
        }

        if(target == null)
        {
            FindTarget();
        }

        if(fireDelay > 0)
        {
            fireDelay -= Time.deltaTime;
        }

        if(target != null)
        {
            //determine which way to shoot
            direction = transform.position - transform.position;
            direction.Normalize();
            Debug.DrawLine(transform.position, target.transform.position);
            Debug.Log("target is at " + target.transform.position);
        }
	}

    void FindTarget() // find all sentinels, put them in a list and pick a random one as a target
    {
        sentinels = GameObject.FindGameObjectsWithTag("Sentinel");
        if (sentinels.Length >= 1)
        {
            random = Random.Range(0, sentinels.Length - 1); // Random.Range is inclusive so an index starting with 0 won't like X.length unmodified
            target = sentinels[random];
        }
    }

	public void AcquireTarget(GameObject target)
	{

	}

    public void Fire()
    {

        //create a bullet and give it a velocity
        GameObject shot = (GameObject)Instantiate(shotPrefab, transform);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletVeloc);
        //Debug.DrawLine(transform.position, direction);
    }
}
