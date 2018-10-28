using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // zmienne miedzy innymi do v1 Movement
    // rozwiazanie do opcji pierwszej - skakania
    // [SerializeField] private bool grounded = false;
    // druga opcja zaminna bitshifta
    // [SerializeField] private LayerMask groundLayer;

    [SerializeField]
    private float jumpForce = 5f;  //variable for jumpForce
    private Rigidbody2D rigid;     //get handle to rigidbody
    // zmienna sprawdzajaca, czy potrzebne jest opoznienie w zmianie grounded, aby nie dalo sie robic podwojnych skokow
    private bool resetJumpNeeded = false;
    [SerializeField] private float moveSpeed = 2.5f;     // szybkosc ruchu gracza
    private PlayerAnimation playerAnimation; //handle to playerAnimation
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody2D>();        //assign handl of rigidbody
        playerAnimation = GetComponent<PlayerAnimation>(); //assign handl to playerAnimation
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // InChildren !!!
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 2 opcje - pierwsza zmienna grounded - bool
        // Movement(); // v2 jest czystsza i bardziej praktyczna - ale obie dzialaja
        // CheckGrounded();

        //druga opcja to pominiecie boola przez 'return type function'
        Movement_v2();

    }

    void Movement_v2()
    {
        IsGrounded();

        // horizontal input for left/right
        // GetAxis z dopiskiem Raw zmienia wartosci inputa na -1, 0, 1 , zwiekszy to plynnosc ruchu
        float horizontalInput = Input.GetAxisRaw("Horizontal");// * Time.deltaTime * moveSpeed;

        Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //spelnienie drugiej czesci if'a jesli true, krotszy zapis
        {
            // wiecej commentow w v1
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            StartCoroutine(ResetJumpBool());
            playerAnimation.SetJump(true);
        }
        
        //current velocity = new velocity (x(horizontal input), current.velocity.y);
        rigid.velocity = new Vector2(horizontalInput * moveSpeed, rigid.velocity.y);
        // obiekt sie przewraca -> nalzey na obiekcie w rigidbody2d - constraints - freezing rotation z -> ptaszek

        playerAnimation.Move(horizontalInput); // wywolanie metody zmieniajacej run na idle i odwrotnie
        // !!! has exit time - pole w Animation, jesli jest zaznaczone, animacja bedzie leciec do konca przed zmiana
        // w naszym wypadku Idle bedzie sie ciagnac do konca swoich klatek, mimo ze juz biegniemy (to samo na odwrot Run -> Idle)
    }

    private void Flip(float horizontalInput)
    {
        // SpriteRenderer Flip x (zaznacz/odznacz) zwraca postac w lewo lub prawo (FLIP da... -- jest tez flipY)
        if (horizontalInput < 0) spriteRenderer.flipX = true; // zaznacza ptaka
        else if (horizontalInput > 0) spriteRenderer.flipX = false; // odznacza
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        // 1<<8 "bit shift", przekazanie layeru, ktory nadalismy jako nr 8
        // cd. celem tego aby Player odbijal sie tylko "od ziemi", a nie np od siebie, lub przeciwnikow(co akurat mogloby byc ciekawe)

        // linia w dol od playera
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null)
        {
            if (resetJumpNeeded == false)
            {
                playerAnimation.SetJump(false);
                return true;
            }
        }
        return false;
    }

/*    private void CheckGrounded()
    {
        //2 opcje - pierwsza zmienna grounded - bool, 2d raycast to the ground // google physics2d.raycast (api)
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f //1f (jednak zmiana, bo wiazka za dluga 
                                                                                        //i po pierwszym skoku wciaz trafiala w 'ground' jaka ma miec dlugosc (w unitach - kwadracikach...)
            , 1 << 8 // << - bitshift? znajdz layer 8 - w naszym wypadku ground, czyli zignorujemy 'playera'
            //alternatywnie mozemy skorzystac ze zmiennej groundLayer.value
            );

        // (do debuga) atm. raycast uderza w playera, metoda pokazuje wiazke, ktora jest wywyslana
        Debug.DrawRay(transform.position, Vector2.down * 0.6f // jednak zmieniamy wartosc dlugosci raya, wiec dodanie mnoznika (0.6) 
            // -- razy o ile, u nas 1f wiec nie trzeba, odnosi sie do hitInfo = ...Raycast 
            //    i 3 wartosci w nawiasie -- nie widac w grze, tylko na scenie :)
                , Color.green);
        // if hitInfo != null grounded = true, po "spacji" dodajemy linijke grounded = false, aby spamowanie spacji nie powodowalo latania
        // jesli nasz raycast w cos trafil i nie jest nullem
        if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.name);


            if (resetJumpNeeded == false)
                grounded = true;
            // potrzebne jeszcze opoznienie, dodane w next episode!, bo za wolno zmienna sie updateuje i mozna robic dual jumpy wciaz tbc.
        }

        //(do poprzedniej linij - wprowadzic kiedys mode na sanjego i jego loop jumpy :o)
    }
*/

/*    private void Movement()
    {
        // horizontal input for left/right
        // GetAxis z dopiskiem Raw zmienia wartosci inputa na -1, 0, 1 , zwiekszy to plynnosc ruchu
        float horizontalInput = Input.GetAxisRaw("Horizontal");// * Time.deltaTime * moveSpeed;

        //if space key && grounded(czyli stykamy sie z innym obiektem, ktory ma collider) == true to current velocity = new velocity(current x, jumpForce);
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            // ustawia nowa wartosc kierunkowa, rigid.velocity.x pobierze aktualna wartosc, czyli bedziemy mogli skoczyc kiernunkowo
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            grounded = false; // zabroni nam podwojnych skokow

            // coroutina dla zmiennej, opozniajaca jej zmiane, poniewaz wykonanie Upadate zachodzi na kazdym frameie, opoznienie o 0.1, ma spowodowac
            // blokade podwojnych skokow
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpBool());
        }

        //current velocity = new velocity (x(horizontal input), current.velocity.y);
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);
        // obiekt sie przewraca -> nalzey na obiekcie w rigidbody2d - constraints - freezing rotation z -> ptaszek
    }
*/

    IEnumerator ResetJumpBool()
    {
        resetJumpNeeded = true; //dodane dla v2 Movement, v1 dzialalo poprawnie bez tego, wciaz bedzie dzialac, ale podwajamy kod(tyle)
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }

}
