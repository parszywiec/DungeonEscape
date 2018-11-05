using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager instance;

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

    public void OpenShop(float gemCount)
    {
        playerGemCountText.text = ""+gemCount+"G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }


    private void Awake()
    {
        instance = this;
    }

}
