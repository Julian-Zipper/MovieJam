using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APU : Unit {

    public override void Init()
    {     
        type = Type.APU;
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
