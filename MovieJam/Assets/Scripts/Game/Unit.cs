using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	const float BULLET_SPEED = 1f;

	private GameObject target;
	private int level;

	GameObject shotPrefab;

	void Start() {
		level = 0;
		shotPrefab = Resources.Load<GameObject> ("Units/Bullet");
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
			Vector3 direction = target.transform.position - transform.position;
			direction.Normalize ();

			GameObject shot = Instantiate (shotPrefab, transform);
			Rigidbody2D rb = shot.GetComponent<Rigidbody2D> ();
			rb.AddForce (direction * BULLET_SPEED);
		}
	}
}
