using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Unit
{
	const float SENTINEL_SPAWN_MULTIPLIER = 1.35f;
    const float DEFAULT_BULLET_COOLDOWN = 1f;
    float bulletCooldown;
    float cooldownTime;

    const float BULLET_COOLDOWN_LEVEL_MULTIPLIER = 1.2f;

    bool firing;

    public override void Init()
    {
        type = Type.Infantry;
        base.Init();
        gameObject.SetActive(false);
		bulletCooldown = DEFAULT_BULLET_COOLDOWN;
		cooldownTime = 0;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        firing = true;
		GameManager.Instance.AddInfantry (this.gameObject);
		GameManager.Instance.IncreaseSentinelSpawnrate (SENTINEL_SPAWN_MULTIPLIER);
    }

    public override void Fire()
    {
        base.Fire();
    }
}
