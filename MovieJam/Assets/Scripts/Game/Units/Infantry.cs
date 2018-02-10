using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Unit {
    public override void Init()
    {       
        type = Type.Infantry;
        base.Init();
    }

    //Does not have a levelUp function, as infantry works differently

    public override void Fire()
    {
        base.Fire();
    }
}
