using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// klasa abstrakcyjna przez dodanie nazwy w naglowku
public abstract class Enemy : MonoBehaviour {

    // protected wiadomo, moga uzywac dzieci
    [SerializeField] protected int health;
    // ciekawostka - public - pojawiaja sie w unity jak SerializeF..., priv/prot nie, ale jesli dodamy im Sera..., to pojawia sie ponwnie
    [SerializeField]
    protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRendererChild;
    protected string goIdle, enemyIdle;

    protected Player player; 
    protected bool isHit = false;



    public virtual void Init()
    {
        speed = 1f;
        currentTarget = pointB.position;
        goIdle = "GoIdle";
        enemyIdle = "EnemyIdle";

        // beda inicjowane przez dzieci, wiec komponent odniesie sie do dziecka dziecka
        animator = GetComponentInChildren<Animator>();
        spriteRendererChild = GetComponentInChildren<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        
    }

    // bez virtuala, a wiec dzieci nei beda mogly jej przeciazac
    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        Combat();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(enemyIdle)) return;
        Movement();
    }

    public virtual void Movement()
    {

        if (pointA.position == currentTarget)
        {
            spriteRendererChild.flipX = true;
        }
        else
        {
            spriteRendererChild.flipX = false;
        }
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            animator.SetTrigger(goIdle);
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            animator.SetTrigger(goIdle);
        }
        if (!isHit)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

    }

    private void Combat()
    {
        Debug.Log(transform.position.x - player.transform.position.x);
        //Debug.Log(transform.position - player.transform.position);
        if (transform.position.x - player.transform.position.x > 2 || transform.position.x - player.transform.position.x < -2)
        {
            isHit = false;
            //Debug.Log(animator.name);
            Debug.Log(isHit);
            animator.SetBool("InCombat", false);
        }
    }




    // vritual attack moze implementowany przez dzieci, badz zmieniony przez zmienienie u nich virtual na override
    // public virtual void Attack() { }

    // MUSI! byc zaimplementowana, ale cialo tworza dzieci, z wlasnymi wlasnosciami
    // public abstract void Update();

}
