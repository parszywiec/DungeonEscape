using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    Player player;
    [SerializeField] public float amountItGives = 1f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        player = FindObjectOfType<Player>();

        // if (collision.tag == "Player")  // alternatywne rozwiazanie
        if (collision.name == player.name)
        {
            player.AddGems(amountItGives);
            //player.amountOfDiamonds += amountItGives;
            Destroy(this.gameObject);
        }

    }
}
