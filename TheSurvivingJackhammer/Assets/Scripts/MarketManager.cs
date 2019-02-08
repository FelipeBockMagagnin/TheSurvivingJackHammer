using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string name;
    public int price;
    public bool blocked;
    public Button button;
    public Button PriceButton;
    public int buyIndex;
}

public class MarketManager : MonoBehaviour
{
    public Item[] items;
    CoinManager coinManager;
    MarketManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        LoadBuy();
    }

    void StartItems()
    {
        foreach (Item item in items)
        {
            if (item.blocked == false)
            {
                Debug.Log("Item " + item.name + " iniciou comprado");
                Destroy(item.PriceButton.gameObject);
                item.button.interactable = true;
                item.blocked = false;
            }
            else
            {
                item.button.interactable = false;
                Debug.Log("Item " + item.name + " iniciou não comprado");
            }

        }
    }

    void ButtonBuy(Item item)
    {
        Destroy(item.PriceButton.gameObject);
        item.button.interactable = true;
        item.blocked = false;
        //SAVE 
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
        
    }

    public void LoadBuy()
    {

    }




}
