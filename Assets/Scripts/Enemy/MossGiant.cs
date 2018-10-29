using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// notatki w Spider.cs i ofc Enemy jako rodzica
public class MossGiant : Enemy {

    // mojPath
    [SerializeField] private Transform targetPosition; // mozna jako Vector zrobic kursPath2
    private bool bolDupy; // aby nie wykonywal animacji GiantIdle 2 razy, za pierwszym razem po spawnie
    // kursPath -- kursowa
    //private bool _switch;
    private Vector3 currentTarget;     // kursPath2
    private Animator animator;
    private SpriteRenderer spriteRendererChild;

    public bool aaa;

    public void Start()
    {
        
        // mojPath
        speed = 1;
        bolDupy = false;
        // nie jest niezbedne, ale gdybysmy nie startowali z wayPointa, to raczej bezpieczniejsze
        //targetPosition = pointB;

        animator = GetComponentInChildren<Animator>();
        spriteRendererChild = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        

        // dno
        //KursPath();

        // sprawdza nazwe animacji - jesli prawda, wroc do poczatku -- w nawiasie 0 - to layer animacji(zakladka layer, w unity, w animatorze - okno z ukladanka kiedy/co- Layers, Parameters - gdzie obecnie ukladamy schematy) 
        // 0 czyli podstawowy, w kursie nie tworzymy ich, wiec pozostaje domyslny. Dopiero po kropce przechodzimy do poszukiwania animacji.
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GiantIdle"))
        {
            return;
            // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("GiantIdle"));
        }
        //MojPath();
        KursPath2();
    }

    private void KursPath2()
    {
        // kursPath
        if (currentTarget == pointA.position)
        {
            spriteRendererChild.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            spriteRendererChild.flipX = false;
        }
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            animator.SetTrigger("GoIdle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("GoIdle");
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }


/*    private void KursPath()
    {
        // kursPath
        if (transform.position == pointA.position)
        {
            _switch = false;
        }
        else if (transform.position == pointB.position)
        {
            _switch = true;
        }

        if (!_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        else if (_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
    }
*/

/*
    private void MojPath()
    {
        // mojPath  --  na podstawie LaserDefendera, dziala 
        // dziala pointA.position, oraz pointA.transform.position (poprawka wzgledem tego co ja w challenge'u zrobilem) 
        if (transform.position == pointA.position)
        {
            targetPosition = pointB;
            if (bolDupy) animator.SetTrigger("GoIdle");
            StartCoroutine(FlipAfterIdle(false));
        }
        else if (transform.position == pointB.position)
        {
            targetPosition = pointA;
            animator.SetTrigger("GoIdle");
            StartCoroutine(FlipAfterIdle(true));
            bolDupy = true;
        }
        // jest oczywiscie tez Vector3.MoveTowards() - metoda popycha o 1 pkt w lini prostej w kierunku punktu docelowego
        // unity docs pokazuja fajnie jak zainicjowac metode (Transform target; -> target.position;)
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
    }

    private IEnumerator FlipAfterIdle(bool flipX)
    {
        yield return new WaitForSeconds(2.7f);
        spriteRendererChild.flipX = flipX;
    }
*/

}
