using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public int Health { get; set; }
    // [SerializeField] public GameObject diamond;



    public override void Init()
    {
        base.Init();
        speed = 1.5f;
        health = 3;
        enemyIdle = "SkeletonIdle";

        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();

    }

    public void Damage()
    {
        if (isDead) return;

        Health--;
        Debug.Log("Health = " + Health);

        animator.SetTrigger("WasHit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            //Destroy(gameObject);
            isDead = true;
            animator.SetTrigger("Death");

            for (int i = 0; gems > i; i++)
            {
                float x = (i * 0.5f);
                Instantiate(diamond, new Vector2(transform.position.x + x, transform.position.y), Quaternion.identity);
            }
        }

    }


}
