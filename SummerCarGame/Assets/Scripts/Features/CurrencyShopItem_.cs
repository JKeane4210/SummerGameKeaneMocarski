using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyShopItem_ : MonoBehaviour
{
    public float cost;
    public Text costText;
    public Text costShadow;
    public int currencyAmount;
    public Text currencyAmountText;
    public Text currencyAmountShadow;
    public Button purchaseButton;

    // Start is called before the first frame update
    void Start()
    {
        SetTextFields();
        purchaseButton.onClick.AddListener(delegate { Buy(); });
    }

    public void Buy()
    {
        GameDataManager.AddCoins(currencyAmount);
        GameSharedUI.Instance.UpdateCoinsUIText();
    }

    public void SetTextFields()
    {
        costText.text = $"${cost}";
        costShadow.text = $"${cost}";
        currencyAmountText.text = $"${currencyAmount}";
        currencyAmountShadow.text = $"${currencyAmount}";
    }
}
