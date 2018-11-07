using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return instance;
        }
    }

    public bool HasKeyToCastle { get; set; }

    // wedle prowadzacego kurs, gameManager jako jedyny manager moze miec dostep do class nie managerskich, w tym wypadku do playera
    public Player Player { get; private set; }

    private void Awake()
    {
        instance = this;
        // przypisanie playera
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
