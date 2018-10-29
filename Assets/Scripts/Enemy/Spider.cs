using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dziedziczenie poprzez nazwe rodzica po ':' - tutaj Enemy jest rodzicem
public class Spider : Enemy {

    // metoda dziedziczy z virtualnej, czyli mozna overridem nadac jej wlasne wlasnosci, ale moze tez zostac orginalna
    public override void Attack()
    {
        // wywolanie metody rodzica, a wiec mozemy dac wlasnosci tu, a nastepnie wywolac rodzica (mozemy... nie musimy)
        //base.Attack();
    }

    // roznica miedzy miedzy vitualna, a abstrakcyjna metoda, ze jedna moze miec implementacje u rodzica, a abstr. nie ma imp u rodzica, ale musi u dziecka
    // metoda abstrakcyjna, zainiciowana u rodzica (Enemy), musi byc zaimplementowana, inaczej podkreslona bedzie nazwa (Spider), tam mozemy ja wygenerowac (jakby cos...)
    public override void Update()
    {
        
    }

}
