using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCurrencies : MonoBehaviour
{
    public GameObject currencyShopItem;
    public AudioClip purchaseSound;
    public GameObject sceneController;
    public GameObject mainCamera;

    private const float PADDING = 5;

    /// <summary>
    /// The list of currencies available to buy in the shop
    /// </summary>
    readonly private CurrencyCost[] currencyCosts = new CurrencyCost[]
        {
            new CurrencyCost(0.99f, 1000),
            new CurrencyCost(1.99f, 2500),
            new CurrencyCost(4.99f, 7500),
            new CurrencyCost(9.99f, 15000)
        };

    // Initializes coin shop page
    void Start()
    {
        float shopItemWidth = currencyShopItem.GetComponent<RectTransform>().rect.width;
        GetComponent<RectTransform>().sizeDelta = new Vector2(currencyCosts.Length * (shopItemWidth + PADDING), GetComponent<RectTransform>().sizeDelta.y);
        float startingXPos = GetComponent<RectTransform>().rect.width / 2 - (shopItemWidth + PADDING) / 2;
        int i = 0;
        foreach (CurrencyCost currencyCost in currencyCosts)
        {
            GameObject newShopItem = Instantiate(currencyShopItem);
            newShopItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(startingXPos - i * (shopItemWidth + PADDING), 0);
            newShopItem.transform.SetParent(transform, false);
            CurrencyShopItem_ currencyShopItem_ = newShopItem.GetComponent<CurrencyShopItem_>();
            if (GameDataManager.SoundEffectsEnabled())
                currencyShopItem_.purchaseButton.onClick.AddListener(delegate {AudioSource.PlayClipAtPoint(purchaseSound, mainCamera.transform.position, 10);});
            currencyShopItem_.cost = currencyCost.cost;
            currencyShopItem_.currencyAmount = currencyCost.currencyRewarded;
            currencyShopItem_.SetTextFields();
            i++;
        }
    }
}

public class CurrencyCost
{
    public float cost;
    public int currencyRewarded;

    public CurrencyCost(float cost, int currencyRewarded)
    {
        this.cost = cost;
        this.currencyRewarded = currencyRewarded;
    }
}
