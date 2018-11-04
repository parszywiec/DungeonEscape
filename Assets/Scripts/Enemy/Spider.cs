using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// notatki w MossGiantcie
public class Spider : Enemy, IDamageable {

    public int Health { get; set; }
    //[SerializeField] GameObject spiderAcid;
    public GameObject acidEffect;
    // [SerializeField] public GameObject diamond;

    public override void Init()
    {
        base.Init();
        speed -= 0.1f;
        enemyIdle = "SpiderIdle";
        Health = base.health;

    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (isDead) return;

        Health--;
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

    public void Attack()
    {
        //GameObject acid = Instantiate(spiderAcid, transform.localPosition, Quaternion.identity);
        Instantiate(acidEffect, transform.position, Quaternion.identity);
    }
}
