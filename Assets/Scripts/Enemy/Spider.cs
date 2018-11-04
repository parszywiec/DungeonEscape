using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// notatki w MossGiantcie
public class Spider : Enemy, IDamageable {

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        speed -= 0.1f;
        enemyIdle = "SpiderIdle";
    }

    public override void Movement()
    {
        
    }

    public void Damage() { }
}
