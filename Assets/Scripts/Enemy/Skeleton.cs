using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

    public override void Init()
    {
        base.Init();
        speed = 1.5f;
        enemyIdle = "SkeletonIdle";
    }
}
