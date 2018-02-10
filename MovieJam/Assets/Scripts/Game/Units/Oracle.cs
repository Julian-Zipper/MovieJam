using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oracle : Unit {
    public override void Init()
    {
        type = Type.Oracle;
        base.Init();
    }

    public override void Upgrade(int currentLevel)
    {
        base.Upgrade(currentLevel);
    }

    public override void Fire()
    {
        base.Fire();
    }
}
