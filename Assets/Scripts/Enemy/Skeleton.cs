using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public int Health { get; set; }



    public override void Init()
    {
        base.Init();
        speed = 1.5f;
        health = 3;
        enemyIdle = "SkeletonIdle";

        Health = base.health;
    }

    public void Damage() {
        Health--;
        Debug.Log("Health = " + Health);

        animator.SetTrigger("WasHit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject);
        }

    }


}
