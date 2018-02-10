using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neo : Unit {
    public override void Init()
    {
        type = Type.Neo;
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
