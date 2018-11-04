using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour {

    [SerializeField] float acidSpeed = 3f;
    [SerializeField] float destroyItselfAfter = 5f;
    //Spider spider;

    public void Start()
    {
        //spider = FindObjectOfType<Spider>();
        //transform.position = spider.transform.position;

        //StartCoroutine(DestroyItself());
        Destroy(this.gameObject, destroyItselfAfter);
    }


    public void Update()
    {
        transform.Translate(Vector3.right * acidSpeed * Time.deltaTime);

        /*
        float positX = (transform.position.x + acidSpeed); // * Time.deltaTime;
        //Debug.Log("positonX = " + positX);
        //Debug.Log("deltaTime = " + Time.deltaTime);
        transform.position = new Vector2(positX, transform.position.y);
        */

  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
        
    }



/*
    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(destroyItselfAfter);
        Destroy(gameObject);
    }
*/

}
