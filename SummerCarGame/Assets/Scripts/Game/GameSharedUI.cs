using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameSharedUI : MonoBehaviour
{
    /// <summary>
    /// Creates a Singleton of the GameSharedUI to be shared across the application
    /// </summary>
    #region Singleton class: GameSharedUI

    public static GameSharedUI Instance;
    private int initialCoins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    #endregion

    [SerializeField] TMP_Text[] coinsUIText;
    //[SerializeField] TMP_Text[] coinsUISingleGameText;

    void Start()
    {
        initialCoins = GetCoins();
        UpdateCoinsUIText();
    }

    /// <summary>
    /// Updates the coins' text to the current amount of coins
    /// </summary>
    public void UpdateCoinsUIText()
    {
        for (int i = 0; i < coinsUIText.Length; i++)
        {
            if (coinsUIText[i].name == "SingleGameCoins")
                SetCoinsText(coinsUIText[i], GetCoins() - initialCoins);


            else
                SetCoinsText(coinsUIText[i], GameDataManager.GetCoins());
        }

        //for (int i = 0; i < coinsUISingleGameText.Length; i++)
        //    SetCoinsText(coinsUISingleGameText[i], GetCoins() - initialCoins);

    }

    void SetCoinsText(TMP_Text textMesh, int value)
    {
        textMesh.text = value.ToString();
        PlayerPrefs.SetInt("coins", value);
        Debug.Log("Coins saved");
    }

    public void BuyCar(int price)
    {
        GameDataManager.SpendCoins(price);
    }

    public int GetCoins()
    {
        return GameDataManager.GetCoins();
    }
}
