using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public int Health { get; set; }

    private bool canHitAgain;

    public override void Init()
    {
        base.Init();
        speed = 1.5f;
        health = 3;
        enemyIdle = "SkeletonIdle";

        Health = base.health;
        canHitAgain = true;
    }

    public void Damage() {
        //Debug.Log("Damage!");
        Health--;
        animator.SetTrigger("WasHit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health < 1 && canHitAgain)
        {
            Destroy(gameObject);
            canHitAgain = false;
            StartCoroutine(HitReset());
        }

    }

    IEnumerator HitReset()
    {
        yield return new WaitForSeconds(0.5f);
        canHitAgain = true;
    }
}
