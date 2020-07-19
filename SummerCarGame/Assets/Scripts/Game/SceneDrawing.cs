using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneDrawing : MonoBehaviour
{
    public GameObject sun;
    public GameObject headlightL;
    public GameObject headlighR;
    public GameObject illuminateCar;
    public GameObject mainCamera;
    private GameObject road_block_obj;
    public GameObject health_bar_obj;
    public GameObject fuel_bar_obj;
    public GameObject replay_btn;
    public GameObject home_btn;
    public GameObject game_over_txt_fied;
    public GameObject roadBlock;
    public GameObject staticRoadBlock;
    public FuelBar fuelBar;
    public HealthBar healthBar;
    public GameObject finalDistanceField;
    public GameObject distanceField;
    private MoveCar carMove;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject coinsTextAndImgs;

    private Vehicle selectedCar;

    private void Start()
    {
        GetComponent<VehicleList>().SimulateStart();
        selectedCar = GetComponent<VehicleList>().GetSelectedVehicle();
        GameObject car = selectedCar.GetCarGameObject();
        //print("*" + selectedCar.GetName());
        car.GetComponent<RenderRoad>().road = roadBlock;
        carMove = car.GetComponent<MoveCar>();
        if (GetComponent<ButtonManager>().GetIsNightMode())
        {
            sun.SetActive(false);
            headlighR.SetActive(true);
            headlightL.SetActive(true);
            illuminateCar.SetActive(true);
            mainCamera.GetComponent<Camera>().backgroundColor = Color.black;
            RenderSettings.ambientIntensity = 0.15f;
            RenderSettings.reflectionIntensity = 0.1f;
            illuminateCar.transform.position = new Vector3(illuminateCar.transform.position.x, selectedCar.GetIlluminationHeight());
        }
        else
        {
            sun.SetActive(true);
            headlighR.SetActive(false);
            headlightL.SetActive(false);
            illuminateCar.SetActive(false);
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.23f, 0.588f, 0.301f);
            RenderSettings.ambientIntensity = 1;
            RenderSettings.reflectionIntensity = 1;
        }
        //DrawRoadBlock(roadBlock);
        //DrawStaticRoadBlock(staticRoadBlock);
        //DrawCar(car);
        ResetHealthBar(healthBar);
        ResetFuelBar(fuelBar);
        HideButton(replay_btn);
        HideButton(home_btn);
        HideButton(game_over_txt_fied);
        HideButton(finalDistanceField);
        ShowButton(distanceField);
        ShowButton(leftButton);
        ShowButton(rightButton);
        ShowButton(coinsTextAndImgs);
        car.GetComponent<Car>().SimulateStart();
        car.GetComponent<UpdateControls>().SimulateStart();
        car.GetComponent<ForestDamage>().SimulateStart();
        distanceField.GetComponent<DistanceText>().SimulateStart();
        rightButton.GetComponent<ButtonMoving>().SimulateStart();
        leftButton.GetComponent<ButtonMoving>().SimulateStart();
        headlightL.GetComponent<HeadlightFollow>().SimulateStart();
        headlighR.GetComponent<HeadlightFollow>().SimulateStart();
        illuminateCar.GetComponent<HeadlightFollow>().SimulateStart();
        Time.timeScale = 1;
    }

   
    public void DrawRoadBlock(GameObject road_block)
    {
        Instantiate(road_block, new Vector3(0f, 0f, 20f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(road_block, new Vector3(0f, 0f, 40f), Quaternion.Euler(0f, 0f, 0f));
        road_block_obj = road_block;
    }

    public void DrawStaticRoadBlock(GameObject static_road_block)
    {
        Instantiate(static_road_block, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
    }

    public void DrawCar(GameObject car)
    {
        car.GetComponent<RenderRoad>().road = road_block_obj;
        car.GetComponent<Car>().fuelBar = fuel_bar_obj.GetComponent<FuelBar>();
        car.GetComponent<Car>().healthBar = health_bar_obj.GetComponent<HealthBar>();
        car.GetComponent<CarDeerCollide>().health_bar = health_bar_obj;
        car.GetComponent<MoveCar>().car = car.GetComponent<CharacterController>();
        //car.GetComponent<MoveCar>().car_transform = car.GetComponent<Transform>();
        car.GetComponent<RenderRoad>().car = car.GetComponent<Transform>();
        //Instantiate(car, new Vector3(1.5f, 1.27f, 0f), Quaternion.Euler(0f, 0f, 0f));
    }

    public void ResetHealthBar(HealthBar h)
    {
        h.SetMaxHealth(100);
    }

    public void ResetFuelBar(FuelBar f)
    {
        f.SetMaxFuel(4f);
    }

    public void HideButton(GameObject btn)
    {
        btn.SetActive(false);
    }

    public void ShowButton(GameObject btn)
    {
        btn.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Car");
    }

    private void Update()
    {
        
        if(health_bar_obj.GetComponent<HealthBar>().GetValue() == 0)
        {
            game_over_txt_fied.GetComponent<UnityEngine.UI.Text>().text = "Damaged Beyond Repair";
            ShowButton(game_over_txt_fied);
            ShowButton(replay_btn);
            ShowButton(home_btn);
            ShowButton(finalDistanceField);
            HideButton(distanceField);
            HideButton(leftButton);
            HideButton(rightButton);
            HideButton(coinsTextAndImgs);
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("CoinsAdded"))
                Destroy(g);
            Time.timeScale = 0;
        }
        else if(fuel_bar_obj.GetComponent<FuelBar>().GetFuel() == 0)
        {
            game_over_txt_fied.GetComponent<UnityEngine.UI.Text>().text = "Out Of Fuel";
            ShowButton(game_over_txt_fied);
            ShowButton(replay_btn);
            ShowButton(home_btn);
            ShowButton(finalDistanceField);
            HideButton(distanceField);
            HideButton(leftButton);
            HideButton(rightButton);
            HideButton(coinsTextAndImgs);
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("CoinsAdded"))
                Destroy(g);
            Time.timeScale = 0;
        }
    }
}
