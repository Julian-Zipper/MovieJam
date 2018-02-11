using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APU : Unit {

	const float SENTINEL_SPAWN_MULTIPLIER = 1.4f;
    const float DEFAULT_BULLET_COOLDOWN = 6f;
    float bulletCooldown;
    float cooldownTime;

	int lastLevel = 0;

    const float BULLET_COOLDOWN_LEVEL_MULTIPLIER = 1.2f;

    bool firing;

    public override void Init()
    {     
        type = Type.APU;
        base.Init();
		bulletCooldown = DEFAULT_BULLET_COOLDOWN;
		cooldownTime = 0;
    }

    public override void Upgrade(int currentLevel)
    {
        base.Upgrade(currentLevel);
        if (currentLevel == 0)
        {
            gameObject.SetActive(false);
            firing = false;
        }
		else if (!gameObject.activeInHierarchy)
		{
			GameManager.Instance.IncreaseSentinelSpawnrate (SENTINEL_SPAWN_MULTIPLIER);
			gameObject.SetActive (true);
			firing = true;
        }
        bulletCooldown = DEFAULT_BULLET_COOLDOWN / (currentLevel * BULLET_COOLDOWN_LEVEL_MULTIPLIER);
    }

    public override void Fire()
    {
        base.Fire();
    }

    void Update()
    {
       if(firing)
        {
            cooldownTime += Time.deltaTime;
            if(cooldownTime >= bulletCooldown)
            {
                Fire();
                cooldownTime = 0f;
            }
        }
    }
}
