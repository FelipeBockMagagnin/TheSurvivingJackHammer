using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coins;
    CoinManager instance;
    public static int coinMultiplicator;
    public static int earnedcoins;
    public GameObject CoinParticle;

    bool firstTime = true;

    private void Awake()
    {
        DontDestroyOnLoad();
        ResetCoinMultiplicator();
    }

    private void Start()
    {
        LoadCoins();
    }

    void ResetCoinMultiplicator()
    {
        coinMultiplicator = 1;
    }

    public void IncreseCoinMultiplicator()
    {
        coinMultiplicator *= 2;
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

    public void ChangeCoins()
    {
        if (!firstTime)
        {
            coins = coins + earnedcoins;
            SaveCoins();
            ResetCoinMultiplicator();
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

    public void InstantiateCoinParticle(Transform transform)
    {
        GameObject coin = Instantiate(CoinParticle, transform.position, Quaternion.identity);
        Destroy(coin, 5);
    }

    public static void IncreaseEarnedCoins()
    {
        earnedcoins += 1 * coinMultiplicator;
        print(1 * coinMultiplicator);
        
    }

    public static void ResetEarnedCoins()
    {
        earnedcoins = 0;
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }

    private void Update()
    {
        coinMultiplicator = (HighScoreManager.points / 10) + 1;    
    }

}
