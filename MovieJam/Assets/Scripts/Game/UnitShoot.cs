using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShoot : MonoBehaviour {
    //find ll sentinels, put them in a list
    //select a sentinel from the list as target
    //fire at target
    //if target stops existing, repeat from step 1

    private GameObject[] sentinels;
    private GameObject target;
    private float fireDelay;
    private int random;

	void Start () {
        FindTarget();
	}
	
	void Update () {
		if(target != null && fireDelay <= 0)
        {
            Fire();
        }

        if(target == null)
        {
            FindTarget();
        }

        if(fireDelay > 0)
        {
            fireDelay -= Time.deltaTime;
        }
	}

    void FindTarget()
    {
        sentinels = GameObject.FindGameObjectsWithTag("Sentinel");
        random = Random.Range(0,sentinels.Length - 1); // Random.Range is inclusive so an index starting with 0 won't like X.length unmodified
        target = sentinels[random];
    }

    private void Fire()
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        transform.forward = targetDirection;
    }
}
