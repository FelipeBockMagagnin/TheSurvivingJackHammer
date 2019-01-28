using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coins;
    CoinManager instance;

    private void Awake()
    {
        DontDestroyOnLoad();    
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
        coins = coins + value;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SaveCoins()
    {

    }

    private void LoadCoins()
    {

    }
}
