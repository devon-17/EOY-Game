using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float money;
    public Text moneyText;

    GameObject ButtonRef;

    // Start is called before the first frame update
    void Start()
    {
        
        moneyText.text = "Money: " + money.ToString("f2");

        // id's
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        // price
        shopItems[2,1] = 5;
        shopItems[2,2] = 10;
        shopItems[2,3] = 15;
        shopItems[2,4] = 30;

        //quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        // if we have enough money
        if(money >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            // subtracting money
            money -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            // adding to the quantity
            money -= shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;

            // updating money text
            moneyText.text = "Money: " + money.ToString("f2");
            ButtonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString("f2");
        }
    }
}
