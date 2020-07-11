using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopVehicles : MonoBehaviour
{
    private ArrayList vehicles = new ArrayList();
    public GameObject shopItem;

    // Start is called before the first frame update
    void Start()
    {
        float shopItemHeight = shopItem.GetComponent<RectTransform>().rect.height;
        for(int i = 0; i < 120; i++)
        {
            vehicles.Add(1);
        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(0 , vehicles.Count * (shopItemHeight + 10));
        float startingYPos = GetComponent<RectTransform>().rect.height / 2 - (shopItemHeight + 10) / 2;
        for(int i = 0; i < vehicles.Count; i++)
        {
            GameObject newShopItem = Instantiate(shopItem);
            newShopItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startingYPos - i * (shopItemHeight + 10));
            newShopItem.transform.SetParent(transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
