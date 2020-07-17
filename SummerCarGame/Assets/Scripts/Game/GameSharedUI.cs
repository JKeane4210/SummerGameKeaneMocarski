using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSharedUI : MonoBehaviour
{
   #region Singleton class: GameSharedUI

    public static GameSharedUI Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


   #endregion

    [SerializeField] TMP_Text[] coinsUIText;

    void Start()
    {
        UpdateCoinsUIText();
    }

    public void UpdateCoinsUIText()
    {
        for (int i = 0; i < coinsUIText.Length; i++)
        {
            SetCoinsText(coinsUIText[i], GameDataManager.GetCoins());
        }
    }

    void SetCoinsText(TMP_Text textMesh, int value)
    {
        textMesh.text = value.ToString();
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
