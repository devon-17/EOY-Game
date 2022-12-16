using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public float price;
    public Text priceText;
    public Text quantityText;
    private GameObject shopManager;

    void Awake(){
        shopManager = GameObject.Find("ShopManager");
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = "Price: $" + shopManager.GetComponent<ShopManager>().shopItems[2,ItemID].ToString();
        quantityText.text = "Quantity: $" + shopManager.GetComponent<ShopManager>().shopItems[3,ItemID].ToString();
    }
}
