using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string name;
    public int price;
    [HideInInspector]
    public bool blocked;
    public Button button;
    public Button PriceButton;
}

public class MarketManager : MonoBehaviour
{
    public Item[] items;
    CoinManager coinManager;
    MarketManager instance;

    private void Start()
    {
        LoadBuy();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    //aumentar moedas em 1000
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            coinManager.DecreaseCoins(-1000);
        }
    }

    


    void StartItems()
    {
        foreach (Item item in items)
        {
            if (PlayerPrefs.GetInt(item.name) == 1)
            {
                Debug.Log("Item " + item.name + " iniciou comprado");
                Destroy(item.PriceButton.gameObject);
                item.button.interactable = true;
                item.blocked = false;
            }
            else
            {
                Debug.Log("Item " + item.name + " iniciou não comprado");
            }
        }
    }

    void ButtonBuy(Item item)
    {
        Destroy(item.PriceButton.gameObject);
        item.button.interactable = true;
        item.blocked = false;
        Debug.Log("item " + item.name + " desbloqueado");
        SaveUniqueBuy(item);
        //SAVE 
    }

    void SaveUniqueBuy(Item item){
        PlayerPrefs.SetInt(item.name, 1);
    }

    public void Buy(string name)
    {
        foreach (Item item in items)
        {
            if(item.name == name)
            {
                if(coinManager.GetCoins() >= item.price)
                {
                    Debug.Log("Item " + item.name + " comprado com sucesso");
                    ButtonBuy(item);
                    coinManager.DecreaseCoins(item.price);
                } 
                else
                {
                    Debug.Log("Não há dinheiro para comprar o Item " + item.name);
                }
                
            }
        }
        //salva a compra
    }

    public void SaveBuy()
    {
        foreach (Item item in items)
        {
            if(item.blocked == true)
            {
                //se estiver bloqueado fica com a key 0
                PlayerPrefs.SetInt(item.name, 0);
            }
            else
            {
                //senão 1
                PlayerPrefs.SetInt(item.name, 1);
            }
        }
        
    }

    public void LoadBuy()
    {
        StartItems();
    }




}
