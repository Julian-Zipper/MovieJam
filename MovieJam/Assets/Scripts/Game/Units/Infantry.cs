using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Unit
{

    const float DEFAULT_BULLET_COOLDOWN = 1;
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
		Debug.Log ("Called Show method");
		GameManager.Instance.AddInfantry (this.gameObject);
    }

    public override void Fire()
    {
        base.Fire();
    }
}
