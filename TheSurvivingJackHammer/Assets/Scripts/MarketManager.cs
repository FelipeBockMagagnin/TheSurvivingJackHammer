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

    private void Awake()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        StartItems();        
    }

    /// <summary>
    /// Starta os itens de acordo com sua disponibilidade
    /// </summary>
    public void StartItems()
    {
        foreach (Item item in items)
        {

            if (PlayerPrefs.HasKey(item.name))
            {

            }
            else
            {
                PlayerPrefs.SetInt(item.name, 0);
            }


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

    /// <summary>
    /// Compra um determinado estilo
    /// </summary>
    /// <param name="item"></param>
    void ButtonBuy(Item item)
    {
        Destroy(item.PriceButton.gameObject);
        item.button.interactable = true;
        item.blocked = false;
        Debug.Log("item " + item.name + " desbloqueado");
        SaveUniqueBuy(item);
        SaveBuy();
        //SAVE
    }

    /// <summary>
    /// Salva uma compra unica
    /// </summary>
    /// <param name="item"></param>
    void SaveUniqueBuy(Item item){
        PlayerPrefs.SetInt(item.name, 1);
    }

    /// <summary>
    /// Compra um novo estilo/musica
    /// </summary>
    /// <param name="name"></param>
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

    /// <summary>
    /// Salva as compras feitas
    /// </summary>
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

    
    }





