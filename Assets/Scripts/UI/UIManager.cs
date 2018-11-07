using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager instance;
    [SerializeField] List<Image> lifeUnits;
    // public Image[] lifeUnits; // alternatywnie do listy

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UI Manager is Null");
            }
            return instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImage;
    public Text gemCountText;


    // dwie ponizsze metody sa do polaczenia, pewnie skopiowac z pierwszej do drugiej i zmienic wszystkie wywolania na druga
    public void OpenShop(float gemCount)
    {
        playerGemCountText.text = ""+gemCount+"G";
    }
    public void UpdateGemCount(float count)
    {
        gemCountText.text = ""+count;
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateLives(int livesRemaining)
    {
        if (livesRemaining >=0)
            lifeUnits[livesRemaining].enabled = false;

        /*
        // kursowe rozwiazanie
        for (int i=0; i < livesRemaining; i++)
        {
            // do nothing till we hit max
            if (i == livesRemaining)
            {
                // hide this one
                lifeUnits[i].enabled = false;
            }
        }
        */
    }

    private void Awake()
    {
        instance = this;
    }

}
