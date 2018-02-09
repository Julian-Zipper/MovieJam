using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShoot : MonoBehaviour {
    //find ll sentinels, put them in a list
    //select a sentinel from the list as target
    //fire at target
    //if target stops existing, repeat from step 1

    private GameObject[] sentinels;
    private int random;
    private GameObject target;

    private float fireDelay = 0.5f;
    private float delayInit;

    private Vector2 direction;

    public float bulletVeloc = 1;
    public GameObject shotPrefab;

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
        }
	}

    void FindTarget() // find all sentinels, put them in a list and pick a random one as a target
    {
        sentinels = GameObject.FindGameObjectsWithTag("Sentinel");
        random = Random.Range(0,sentinels.Length - 1); // Random.Range is inclusive so an index starting with 0 won't like X.length unmodified
        target = sentinels[random];
    }

    private void Fire()
    {

        //create a bullet and give it a velocity
        GameObject shot = (GameObject)Instantiate(shotPrefab, transform);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletVeloc);
        //Debug.DrawLine(transform.position, direction);
    }
}
