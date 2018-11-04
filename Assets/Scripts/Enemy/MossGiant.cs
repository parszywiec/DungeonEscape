using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dziedziczenie poprzez nazwe rodzica po ':' - tutaj Enemy jest rodzicem
// jak w javie jedno dziedziczenie, ile chcesz interfacow, jak widac interface po przecinku, implementacja instrukcji z interf jest obowiazkowa
public class MossGiant : Enemy, IDamageable {
    
    public int Health { get; set; }
    // [SerializeField] public GameObject diamond;

    // nadpisanie metody initializacyjnej, wywolanie jej przez base. (jest virtualna) i uzupelnienie o indywidualne wlasnosci giganta
    public override void Init()
    {
        base.Init();
        speed += 0.1f;
        health = 5;
        enemyIdle = "GiantIdle";

        Health = health; // mozna tez base.health , przypisze wartosc ze zmiennej dziedziczonej, do interfaceowej
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

            /*
            // wersja spawnujaca kilka diamentow, w zakeznosci od ustawionej ilosci zmiennej gems
            for (int i = 0; gems > i; i++)
            {
                float x = (i * 0.5f);
                Instantiate(diamond, new Vector2(transform.position.x + x, transform.position.y - 0.4f), Quaternion.identity);
            }
            */
            // alternatywnie, jeded diamnet, a zmienna gems podnosi jego wartosc, a wiec w obu wersjach otrzymamy ta sama liczbe punktow
            GameObject thisDiamond = Instantiate(diamond, transform.position, Quaternion.identity) as GameObject;
            thisDiamond.GetComponent<Diamond>().amountItGives *= base.gems;



        }

    }







    // TROCHE NOTATEK
    /*
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
            speed = 1f;
            bolDupy = false;
            // nie jest niezbedne, ale gdybysmy nie startowali z wayPointa, to raczej bezpieczniejsze
            //targetPosition = pointB;

            animator = GetComponentInChildren<Animator>();
            spriteRendererChild = GetComponentInChildren<SpriteRenderer>();
        }

        // roznica miedzy miedzy vitualna, a abstrakcyjna metoda, ze jedna moze miec implementacje u rodzica, a abstr. nie ma imp u rodzica, ale musi u dziecka
        // metoda abstrakcyjna, zainiciowana u rodzica (Enemy), musi byc zaimplementowana, inaczej podkreslona bedzie nazwa (Spider), tam mozemy ja wygenerowac (jakby cos...)
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
    */

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

    /*
    // metoda dziedziczy z virtualnej, czyli mozna overridem nadac jej wlasne wlasnosci, ale moze tez zostac orginalna
    public override void Attack()
        {
            // wywolanie metody rodzica, a wiec mozemy dac wlasnosci tu, a nastepnie wywolac rodzica (mozemy... nie musimy)
            //base.Attack();
        }
    */
}
