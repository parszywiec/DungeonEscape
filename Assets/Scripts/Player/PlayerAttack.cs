using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool canHitAgain = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit: " + collision.name);

        IDamageable hit = collision.GetComponent<IDamageable>();
        if (hit != null && canHitAgain)
        {
            hit.Damage();
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
