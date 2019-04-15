using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int coins;
    CoinManager instance;
    public static int coinMultiplicator;
    public int earnedcoins;
    public GameObject CoinParticle;
    MarketManager marketManager;

    bool firstTime = true;

    private void Awake()
    {
        HighScoreManager.points = 0;
        marketManager = GameObject.Find("MarketManager").GetComponent<MarketManager>();
        DontDestroyOnLoad();
        ResetCoinMultiplicator();
    }

    private void Start()
    {
        LoadCoins();
    }

    private void Update()
    {
        coinMultiplicator = (HighScoreManager.points / 10) + 1;     
    }

    /// <summary>
    /// Reseta os atributos de pontos, dinheiro ganho e multiplicador de dinheiro
    /// </summary>
    public void ResetCoinMultiplicator()
    {
        coinMultiplicator = 1;
        earnedcoins = 0;
        HighScoreManager.points = 0;
    }

    /// <summary>
    /// Metodo não mais utilizado, Aumenta o multiplicador de coins
    /// </summary>
    public void IncreseCoinMultiplicator()
    {
        coinMultiplicator += 2;
    }

    /// <summary>
    /// Não destroy o Objeto no carregamento
    /// </summary>
    private void DontDestroyOnLoad()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CoinManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Diminui o numero de coins
    /// </summary>
    /// <param name="amount"></param>
    public void DecreaseCoins(int amount)
    {
        coins -= amount;
        Debug.Log("Coins gastos: " + amount + " restando " + coins + " coins");
        SaveCoins();
    }

    /// <summary>
    /// Da save nos coins se não for o jogo recem aberto
    /// </summary>
    public void ChangeCoins()
    {
        if (!firstTime)
        {
            SaveCoins();
        }
        firstTime = false;
    }

    /// <summary>
    /// Retorna o numero de coins
    /// </summary>
    /// <returns> Retorna o numero de coins </returns>
    public int GetCoins()
    {
        return coins;
    }

    /// <summary>
    /// Salva os coins, somando eles com os coins ganhos
    /// </summary>
    public void SaveCoins()
    {
        marketManager.SaveBuy();
        coins += earnedcoins;
        earnedcoins = 0;
        PlayerPrefs.SetInt("Coins", coins);
        HighScoreManager.CheckScore();
    }

    /// <summary>
    /// Instancia a particula de coin
    /// </summary>
    /// <param name="transform"></param>
    public void InstantiateCoinParticle(Transform transform)
    {
        GameObject coin = Instantiate(CoinParticle, transform.position, Quaternion.identity);
        Destroy(coin, 5);
    }

    /// <summary>
    /// Aumenta os coins ganhos multiplicando eles com o multiplicador de coins
    /// </summary>
    public void IncreaseEarnedCoins()
    {
        earnedcoins += 1 * coinMultiplicator;
        print("coinmanager earned coins: " + earnedcoins);
    }

    /// <summary>
    /// Carrega os coins da memoria ao iniciar o jogo
    /// </summary>
    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
}
