using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	const float BULLET_SPEED = 1000f;
	const string BULLET_PREFAB_LOCATION = "Units/Bullet";

	private GameObject target;
	private int level;

	GameObject shotPrefab;

    public enum Type
    {
        Infantry,
        APU,
        Morpheus,
        Trinity,
        Oracle,
        Neo
    }

    void Start() {
		level = 0;
		shotPrefab = Resources.Load<GameObject> (BULLET_PREFAB_LOCATION);
	}

	public void Levelup()
	{
		level += 1;
	}

	public void AcquireTarget(GameObject newTarget)
	{
		target = newTarget;
	}

	public void Fire()
	{
		if (target != null)
		{
			//determine which way to shoot
			Transform sentinelHead = target.transform.GetChild(0);
			Vector3 direction = sentinelHead.position - transform.position;
			direction.Normalize ();

			GameObject shot = Instantiate (shotPrefab, transform);
			Rigidbody2D rb = shot.GetComponent<Rigidbody2D> ();
			rb.AddForce (direction * BULLET_SPEED);
		}
	}
}
