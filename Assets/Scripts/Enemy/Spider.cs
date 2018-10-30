using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// notatki w MossGiantcie
public class Spider : Enemy {

    public override void Init()
    {
        base.Init();
        speed -= 0.1f;
        enemyIdle = "SpiderIdle";
    }


}
