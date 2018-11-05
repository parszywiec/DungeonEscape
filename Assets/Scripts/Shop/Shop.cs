using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject shopPanel;
    public int itemSelected = -1;
    public float currentItemCost;
    public Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             player = other.GetComponent<Player>();

            if (player != other)
            {
                UIManager.Instance.OpenShop(player.amountOfDiamonds);
            }

            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("Selected "+item);

        switch (item)
        {
            case 0: // flame sword
                UIManager.Instance.UpdateShopSelection(80);
                itemSelected = 0;
                currentItemCost = 200;
                break;
            case 1: // boots of flight
                UIManager.Instance.UpdateShopSelection(-30);
                itemSelected = 1;
                currentItemCost = 400;
                break;
            case 2: // key to castle
                UIManager.Instance.UpdateShopSelection(-140);
                itemSelected = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (player == null) return;

        if(player.amountOfDiamonds >= currentItemCost)
        {
            if(itemSelected == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            // award item
            player.amountOfDiamonds -= currentItemCost;
            UIManager.Instance.OpenShop(player.amountOfDiamonds);
        } else
        {
            Debug.Log("not enough gems, closing shop");
            shopPanel.SetActive(false);
        }

        /*
        if (itemSelected == 0 && player.amountOfDiamonds >= 200)
        {
            // player awarded with sword
            player.amountOfDiamonds -= 200;
            shopPanel.SetActive(false);
        } else
        if (itemSelected == 1 && player.amountOfDiamonds >= 400)
        {
            // player awarded with boots
            player.amountOfDiamonds -= 400;
            shopPanel.SetActive(false);
        } else
        if (itemSelected == 2 && player.amountOfDiamonds >= 100)
        {
            // player awarded with key
            player.amountOfDiamonds -= 100;
            shopPanel.SetActive(false);
        } else shopPanel.SetActive(false);
        */
    }


}
