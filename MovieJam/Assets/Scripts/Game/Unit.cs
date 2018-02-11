using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    const float BULLET_SPEED_LEVEL_MULTIPLIER = 1.5f;
    const float DEFAULT_BULLET_SPEED = 1000f;
	const string BULLET_PREFAB_LOCATION = "Units/Bullet";

	private GameObject target;
	private int level;
    

    [HideInInspector]
    public Type type;

    float bulletSpeed;


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

    virtual public void Init() {
		shotPrefab = Resources.Load<GameObject> (BULLET_PREFAB_LOCATION);
        level = ShopManager.Instance.GetUnitLevel(type);
        bulletSpeed = DEFAULT_BULLET_SPEED;
        Upgrade(level);
    }

    virtual public void Upgrade(int currentLevel)
	{
        bulletSpeed = bulletSpeed * (currentLevel * BULLET_SPEED_LEVEL_MULTIPLIER);
		//Set values according to currentlevel to strenghten unit
	}

    virtual public void AcquireTarget(GameObject newTarget)
	{
		target = newTarget;
	}

    virtual public void Fire()
	{
		if (target != null)
		{
			//determine which way to shoot
			Transform sentinelHead = target.transform.GetChild(0);
			Vector3 direction = sentinelHead.position - transform.position;
			direction.Normalize ();

			GameObject shot = Instantiate (shotPrefab, transform);
			Rigidbody2D rb = shot.GetComponent<Rigidbody2D> ();
			rb.AddForce (direction * bulletSpeed);
		}
	}
}
