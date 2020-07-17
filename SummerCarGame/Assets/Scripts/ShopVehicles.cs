using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopVehicles : MonoBehaviour
{
    public GameObject sceneController;
    private Vehicle[] vehicles;
    public GameObject shopItem;
    private GameObject gameSharedUI;
    //private GameObject coinText;
    
    void Start()
    {
        gameSharedUI = GameObject.FindGameObjectWithTag("GameSharedUI");
        //coinText = GameObject.FindGameObjectWithTag("CoinText");
        vehicles = sceneController.GetComponent<VehicleList>().GetVehicles();
        UpdateSelectedVehicleField();
        float shopItemHeight = shopItem.GetComponent<RectTransform>().rect.height;
        GetComponent<RectTransform>().sizeDelta = new Vector2(0 , vehicles.Length * (shopItemHeight + 10));
        float startingYPos = GetComponent<RectTransform>().rect.height / 2 - (shopItemHeight + 10) / 2;
        int i = 0;
        
        foreach(Vehicle vehicle in vehicles)
        {
            GameObject newShopItem = Instantiate(shopItem);
            newShopItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startingYPos - i * (shopItemHeight + 10));
            newShopItem.transform.SetParent(transform, false);
            newShopItem.name = vehicle.GetName();
            AutoShopItem_ autoShopItem = newShopItem.GetComponent<AutoShopItem_>();

            //Price
            int carPrice = vehicle.GetPrice();
            autoShopItem.price.GetComponent<TextMeshProUGUI>().text = carPrice.ToString();

            //SLIDERS
            autoShopItem.characterName.GetComponent<TextMeshProUGUI>().text = vehicle.GetName();
            autoShopItem.speedBar.GetComponent<Image>().fillAmount = vehicle.GetVelocity() / 40f;
            autoShopItem.fuelBar.GetComponent<Image>().fillAmount = vehicle.GetMaxFuel()/150f;
            autoShopItem.healthBar.GetComponent<Image>().fillAmount = (float)(1.0f*vehicle.GetMaxHealth()/150f);

            //BUTTONS
            Button selectBuyButton = autoShopItem.selectButton.GetComponent<Button>();
            Button infoButton = autoShopItem.infoButton.GetComponent<Button>();
            infoButton.onClick.AddListener(delegate { sceneController.GetComponent<VehicleList>().ChangeInfoVehicleByName(vehicle.GetName()); });
            infoButton.onClick.AddListener(delegate { sceneController.GetComponent<ButtonManager>().ButtonChangeScene("SoloVehicle"); });
            if (sceneController.GetComponent<VehicleList>().GetPurchasedCars().Contains(vehicle.GetName()))
            {
                infoButton.interactable = true;
                ColorBlock cb = selectBuyButton.colors;
                cb.normalColor = new Color32(255, 247, 1, 255);
                autoShopItem.selectBuyText.GetComponent<TextMeshProUGUI>().text = "SELECT";
                selectBuyButton.colors = cb;
                selectBuyButton.onClick.AddListener(delegate { sceneController.GetComponent<VehicleList>().ChangeSelectedVehicleByName(vehicle.GetName()); });
                selectBuyButton.onClick.AddListener(delegate { UpdateSelectedVehicleField(); });
                autoShopItem.priceBox.SetActive(false);
            }
            else
            {
                if (vehicle.GetPrice() > gameSharedUI.GetComponent<GameSharedUI>().GetCoins())
                    selectBuyButton.interactable = false;
                infoButton.interactable = false;
                ColorBlock cb = selectBuyButton.colors;
                cb.normalColor = new Color32(14, 255, 0, 255);
                autoShopItem.selectBuyText.GetComponent<TextMeshProUGUI>().text = "BUY";
                selectBuyButton.colors = cb;
                selectBuyButton.onClick.AddListener(delegate { BuyCar(newShopItem, vehicle); });
                //gameSharedUI.GetComponent<GameSharedUI>().BuyCar(vehicle.GetPrice());
            }
            i++;
        }
    }

    public void BuyCar(GameObject autoShopItem, Vehicle vehicle)
    {
        AutoShopItem_ shopItemProperties = autoShopItem.GetComponent<AutoShopItem_>();
        Button selectBuyButton = shopItemProperties.selectButton.GetComponent<Button>();
        Button infoButton = shopItemProperties.infoButton.GetComponent<Button>();
        infoButton.interactable = true;
        ColorBlock cb = selectBuyButton.colors;
        cb.normalColor = new Color32(255, 247, 1, 255);
        shopItemProperties.selectBuyText.GetComponent<TextMeshProUGUI>().text = "SELECT";
        selectBuyButton.colors = cb;
        selectBuyButton.onClick.AddListener(delegate { sceneController.GetComponent<VehicleList>().ChangeSelectedVehicleByName(autoShopItem.name); });
        selectBuyButton.onClick.AddListener(delegate { UpdateSelectedVehicleField(); });
        sceneController.GetComponent<VehicleList>().PurchaseCar(autoShopItem.name);
        gameSharedUI.GetComponent<GameSharedUI>().BuyCar(vehicle.GetPrice());
        gameSharedUI.GetComponent<GameSharedUI>().UpdateCoinsUIText();
        shopItemProperties.priceBox.SetActive(false);
    }

    public void UpdateSelectedVehicleField()
    {
        GetComponent<CarSelect>().selectedCarText.GetComponent<TextMeshProUGUI>().text = "Selected Vehicle: " + sceneController.GetComponent<VehicleList>().GetSelectedVehicle().GetName();
    }
}
