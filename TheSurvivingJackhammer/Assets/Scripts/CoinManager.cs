using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coins;
    CoinManager instance;

    bool firstTime = true;

    private void Awake()
    {
        DontDestroyOnLoad();           
    }

    private void Start()
    {
        LoadCoins();
    }

    private void DontDestroyOnLoad()
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

    public void ChangeCoins(int value)
    {
        if (!firstTime)
        {
            coins = coins + value;
            SaveCoins();
            print("aaa");
        }
        firstTime = false;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
}
