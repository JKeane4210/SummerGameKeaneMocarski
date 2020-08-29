using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopVehicles : MonoBehaviour
{
    public GameObject sceneController;
    public GameObject shopItem;
    public AudioClip purchaseSound;
    public GameObject mainCamera;

    private Vehicle[] vehicles;
    private GameObject gameSharedUI;
    private GameObject unlockedCarPanel;
    private GameObject showPurchasedCars;
    private GameObject autoShopPanel;

    void Start()
    {
        Time.timeScale = 1;
        autoShopPanel = GameObject.FindGameObjectWithTag("AutoShopPanel");
        gameSharedUI = GameObject.FindGameObjectWithTag("GameSharedUI");
        unlockedCarPanel = GameObject.FindGameObjectWithTag("UnlockedPage");
        showPurchasedCars = GameObject.FindGameObjectWithTag("CheckBox");
        vehicles = sceneController.GetComponent<VehicleList>().GetVehicles();
        UpdateSelectedVehicleField();
        float shopItemHeight = shopItem.GetComponent<RectTransform>().rect.height;
        if(showPurchasedCars.GetComponent<CheckBox>().IsChecked())
            GetComponent<RectTransform>().sizeDelta = new Vector2(0, GameDataManager.GetOwnedCars().Count * (shopItemHeight + 10));
        else
            GetComponent<RectTransform>().sizeDelta = new Vector2(0 , vehicles.Length * (shopItemHeight + 10));
        float startingYPos = GetComponent<RectTransform>().rect.height / 2 - (shopItemHeight + 10) / 2;
        int i = 0;
        showPurchasedCars.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("AutoShop"); });

        foreach(Vehicle vehicle in vehicles)
        {
            if (!showPurchasedCars.GetComponent<CheckBox>().IsChecked() || (showPurchasedCars.GetComponent<CheckBox>().IsChecked() && GameDataManager.GetOwnedCars().Contains(vehicle.GetName())))
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
                autoShopItem.fuelBar.GetComponent<Image>().fillAmount = vehicle.GetMaxFuel() / 150f;
                autoShopItem.healthBar.GetComponent<Image>().fillAmount = (float)(1.0f * vehicle.GetMaxHealth() / 150f);
                //BUTTONS
                Button selectBuyButton = autoShopItem.selectButton.GetComponent<Button>();
                Button infoButton = autoShopItem.infoButton.GetComponent<Button>();
                infoButton.onClick.AddListener(delegate { sceneController.GetComponent<VehicleList>().ChangeInfoVehicleByName(vehicle.GetName()); });
                infoButton.onClick.AddListener(delegate { sceneController.GetComponent<ButtonManager>().ButtonChangeScene("SoloVehicle"); });
                if (GameDataManager.GetOwnedCars().Contains(vehicle.GetName()))
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
                    if (vehicle.GetPrizeDistance() == -1)
                    {
                        if (vehicle.GetPrice() > gameSharedUI.GetComponent<GameSharedUI>().GetCoins())
                            selectBuyButton.interactable = false;
                        infoButton.interactable = false;
                        ColorBlock cb = selectBuyButton.colors;
                        cb.normalColor = new Color32(14, 255, 0, 255);
                        autoShopItem.selectBuyText.GetComponent<TextMeshProUGUI>().text = "BUY";
                        selectBuyButton.colors = cb;
                        selectBuyButton.onClick.AddListener(delegate { BuyCar(newShopItem, vehicle); });
                        selectBuyButton.onClick.AddListener(delegate { autoShopPanel.SetActive(false); });
                    }
                    else
                    {
                        autoShopItem.priceBox.SetActive(false);
                        infoButton.interactable = false;
                        if (GameDataManager.GetTotalDistance() >= vehicle.GetPrizeDistance())
                        {
                            selectBuyButton.interactable = true;
                            ColorBlock cb = selectBuyButton.colors;
                            cb.normalColor = new Color32(14, 255, 0, 255);
                            autoShopItem.selectBuyText.GetComponent<TextMeshProUGUI>().text = "CLAIM";
                            selectBuyButton.colors = cb;
                            selectBuyButton.onClick.AddListener(delegate { GameDataManager.AddPrize(vehicle.GetPrizeDistance()); });
                            selectBuyButton.onClick.AddListener(delegate { BuyCar(newShopItem, vehicle); });
                            selectBuyButton.onClick.AddListener(delegate { autoShopPanel.SetActive(false); });
                        }
                        else
                        {
                            selectBuyButton.interactable = false;
                            float milesTwoDecimals = (float)((int)(GameDataManager.GetTotalDistance() * 100));
                            autoShopItem.selectBuyText.GetComponent<TextMeshProUGUI>().text = $"{(float)(milesTwoDecimals / 100)}/{vehicle.GetPrizeDistance()} mi.";
                        }
                    }
                }
                i++;
            }
        }
    }

    public void RedrawShopItems() => Start();

    public void BuyCar(GameObject autoShopItem, Vehicle vehicle)
    {
        AudioSource.PlayClipAtPoint(purchaseSound, mainCamera.transform.position, 10);
        AutoShopItem_ shopItemProperties = autoShopItem.GetComponent<AutoShopItem_>();
        Button selectBuyButton = shopItemProperties.selectButton.GetComponent<Button>();
        Button infoButton = shopItemProperties.infoButton.GetComponent<Button>();
        infoButton.interactable = true;
        ColorBlock cb = selectBuyButton.colors;
        cb.normalColor = new Color32(255, 247, 1, 255);
        shopItemProperties.selectBuyText.GetComponent<TextMeshProUGUI>().text = "SELECT";
        selectBuyButton.colors = cb;
        selectBuyButton.onClick.RemoveAllListeners();
        selectBuyButton.onClick.AddListener(delegate { sceneController.GetComponent<VehicleList>().ChangeSelectedVehicleByName(autoShopItem.name); });
        selectBuyButton.onClick.AddListener(delegate { UpdateSelectedVehicleField(); });
        GameDataManager.AddCar(autoShopItem.name);
        gameSharedUI.GetComponent<GameSharedUI>().BuyCar(vehicle.GetPrice());
        gameSharedUI.GetComponent<GameSharedUI>().UpdateCoinsUIText();
        shopItemProperties.priceBox.SetActive(false);
        float scale_fact = 0.7f;
        GameObject newCar = vehicle.GetGameObjectNoComponents(new Vector3(0, -3 + vehicle.GetUnlockedAddOn(), 100), new Vector3(vehicle.GetViewingScale().x * scale_fact, vehicle.GetViewingScale().y * scale_fact, vehicle.GetViewingScale().z * scale_fact));
        RotateObject r = newCar.AddComponent<RotateObject>();
        r.direction = 'y';
        unlockedCarPanel.SetActive(true);
        unlockedCarPanel.GetComponent<UnlockedPage_>().nameText.GetComponent<TextMeshProUGUI>().text = vehicle.GetName();
        unlockedCarPanel.GetComponent<UnlockedPage_>().nameDescrText.GetComponent<TextMeshProUGUI>().text = vehicle.GetDescription();
        unlockedCarPanel.GetComponent<UnlockedPage_>().useButton.onClick.AddListener(delegate { sceneController.GetComponent<VehicleList>().ChangeSelectedVehicleByName(vehicle.GetName()); });
        unlockedCarPanel.GetComponent<UnlockedPage_>().useButton.onClick.AddListener(delegate { UpdateSelectedVehicleField(); });
        autoShopItem.GetComponent<AutoShopItem_>().priceBox.SetActive(false);
    }

    public void UpdateSelectedVehicleField() => GetComponent<CarSelect>().selectedCarText.GetComponent<TextMeshProUGUI>().text = $"Selected Vehicle: {sceneController.GetComponent<VehicleList>().GetSelectedVehicle().GetName()}";
}
