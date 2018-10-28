using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator; //handle to animator

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>(); // InChildren - do zapamietania, obiekt w unity jest przypisany do Playera
	}
	
    public void Move(float move)
    {
        animator.SetFloat("Move", Mathf.Abs(move)); //przypisujemy wartosc do zmiennej Move, ktora instnieje w Unity w Animatorze
                                                    // Mathf.Abs() jak w bazach daje wartosci absolutne(dodatnie), gdyz logika w Animatorze jest
                                                    // Move<0.1 - Idle, >0 - Run, a wiec ruch w lewo (-1 itd) dalby Idle

        // !!! 'has exit time' - pole w Animation, jesli jest zaznaczone, animacja bedzie leciec do konca przed zmiana
        // w naszym wypadku Idle bedzie sie ciagnac do konca swoich klatek, mimo ze juz biegniemy (to samo na odwrot Run -> Idle)
        // 'transition duration' (settings) - kolejne pole ktore opoznia przejscie, ustawienie na 0 spowoduje jego natychmiastowa zmiane,
        // natomaiast moze pomoc w plynnym przejsciu miedzy animacjami (transition fade - jako opis przez prowadzacego kurs)
        // (przykladowo gdyby z Walk to Run to bysmy chcieli jakies opoznienie...)

        // SpriteRenderer Flip x (zaznacz/odznacz) zwraca postac w lewo lub prawo
    }

    public void SetJump(bool jump)
    {
        //Debug.Log(jump);
        // nalezy na animacji jump wylaczyc loop'a, zeby wykonala sie tylko raz w locie
        animator.SetBool("Jumping", jump);
    }

}
