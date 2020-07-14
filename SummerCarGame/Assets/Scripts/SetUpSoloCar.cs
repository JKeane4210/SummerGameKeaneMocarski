using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpSoloCar : MonoBehaviour
{
    //public GameObject sceneController;

    public GameObject nameText;
    public GameObject descText;
    public GameObject healthText;
    public GameObject fuelText;
    public GameObject speedText;
    public Slider healthSlider;
    public Image healthImg;
    public Slider fuelSlider;
    public Image fuelImg;
    public Slider speedSlider;
    public Image speedImg;
    public Button selectButton;

    public Gradient sliderGradient;
    private Vehicle vehicle;

    void Start()
    {
        Time.timeScale = 1;
        vehicle = GetComponent<VehicleList>().GetInfoVehicle();
        nameText.GetComponent<Text>().text = vehicle.GetName();
        descText.GetComponent<Text>().text = vehicle.GetDescription();
        healthText.GetComponent<Text>().text = "Max Health: " + vehicle.GetMaxHealth().ToString();
        fuelText.GetComponent<Text>().text = "Max Fuel: " + vehicle.GetMaxFuel().ToString();
        speedText.GetComponent<Text>().text = "Speed: " + vehicle.GetVelocity().ToString();

        healthSlider.value = vehicle.GetMaxHealth();
        healthImg.color = sliderGradient.Evaluate(healthSlider.normalizedValue);
        fuelSlider.value = vehicle.GetMaxFuel();
        fuelImg.color = sliderGradient.Evaluate(fuelSlider.normalizedValue);
        speedSlider.value = vehicle.GetVelocity();
        speedImg.color = sliderGradient.Evaluate(speedSlider.normalizedValue);

        //GameObject car = vehicle.GetGameObjectNoComponents(vehicle.GetViewingLocation());
        GameObject car = vehicle.GetGameObjectNoComponents(vehicle.GetViewingLocation());
        if(car.GetComponent<RotateObject>() == null)
            car.AddComponent<RotateObject>();
        car.GetComponent<RotateObject>().direction = 'y';
        //car.transform.localScale = vehicle.GetViewingScale();
        car.transform.localScale = vehicle.GetViewingScale();

        selectButton.onClick.AddListener(delegate { GetComponent<VehicleList>().ChangeSelectedVehicleByName(GetComponent<VehicleList>().GetInfoVehicle().GetName()); });
    }
}
