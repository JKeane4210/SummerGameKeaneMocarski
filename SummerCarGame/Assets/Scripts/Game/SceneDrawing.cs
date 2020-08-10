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
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject coinsTextAndImgs;
    public GameObject roadColorPlane;
    public GameObject roadSelectButton;
    public GameObject boostButton;

    private Vehicle selectedCar;
    private WorldTerrain selectedWorld;

    private void Start()
    {
        GetComponent<WorldTerrainList>().SimulateStart();
        selectedWorld = GetComponent<WorldTerrainList>().GetSelectedTerrain();
        GameObject staticRoad = Instantiate(selectedWorld.GetNormalRoad(), new Vector3(0, 1.25f, 0), Quaternion.identity);
        staticRoad.name = "StaticRoad";
        for (int i = 1; i <= 4; i++)
        {
            GameObject newRoad = Instantiate(selectedWorld.GetNormalRoad(), new Vector3(0, 1.25f, 24.5f * (float)i), Quaternion.identity);
            newRoad.name = $"BaseRoad{i}";
            try
            {
                Component c = newRoad.GetComponent<RandomDeerInstantiation>();
                Destroy(c);
            }
            catch
            {
                print("Already has no RandomDeerInstantion");
            }
        }
        GetComponent<VehicleList>().SimulateStart();
        roadColorPlane.GetComponent<Renderer>().material = selectedWorld.GetNormalRoadMat();
        selectedCar = GetComponent<VehicleList>().GetSelectedVehicle();
        GameObject car = selectedCar.GetCarGameObject();
        car.GetComponent<RenderRoad>().road = selectedWorld.GetNormalRoad();
        car.GetComponent<RenderRoad>().gasStationRoad = selectedWorld.GetGasRoad();
        if (GetComponent<ButtonManager>().GetIsNightMode())
        {
            sun.SetActive(false);
            headlighR.SetActive(true);
            headlightL.SetActive(true);
            illuminateCar.SetActive(true);
            mainCamera.GetComponent<Camera>().backgroundColor = Color.black;
            RenderSettings.ambientIntensity = 0.15f;
            RenderSettings.reflectionIntensity = 0.1f;
            //illuminateCar.transform.position = new Vector3(illuminateCar.transform.position.x, selectedCar.GetIlluminationHeight());
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
        ResetHealthBar(healthBar);
        ResetFuelBar(fuelBar);
        HideButton(replay_btn);
        HideButton(home_btn);
        HideButton(game_over_txt_fied);
        HideButton(finalDistanceField);
        HideButton(roadSelectButton);
        ShowButton(distanceField);
        ShowButton(leftButton);
        ShowButton(rightButton);
        ShowButton(coinsTextAndImgs);
        ShowButton(boostButton);
        car.GetComponent<RenderRoad>().SimulateStart();
        car.GetComponent<Car>().SimulateStart();
        car.GetComponent<UpdateControls>().SimulateStart();
        car.GetComponent<ForestDamage>().SimulateStart();
        distanceField.GetComponent<DistanceText>().SimulateStart();
        rightButton.GetComponent<ButtonMoving>().SimulateStart();
        leftButton.GetComponent<ButtonMoving>().SimulateStart();
        headlightL.GetComponent<HeadlightFollow>().SimulateStart();
        headlighR.GetComponent<HeadlightFollow>().SimulateStart();
        illuminateCar.GetComponent<HeadlightFollow>().SimulateStart();
        mainCamera.GetComponent<BackgroundColorScan>().SimulateStart();
        boostButton.GetComponent<BoostButton>().SimulateStart();
        Time.timeScale = 1;
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

    void Update()
    {   
        if(health_bar_obj.GetComponent<HealthBar>().GetValue() == 0)
        {
            game_over_txt_fied.GetComponent<UnityEngine.UI.Text>().text = "Damaged Beyond Repair";
            ShowButton(game_over_txt_fied);
            ShowButton(replay_btn);
            ShowButton(home_btn);
            ShowButton(finalDistanceField);
            ShowButton(roadSelectButton);
            HideButton(distanceField);
            HideButton(leftButton);
            HideButton(rightButton);
            HideButton(coinsTextAndImgs);
            HideButton(boostButton);
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
            ShowButton(roadSelectButton);
            HideButton(distanceField);
            HideButton(leftButton);
            HideButton(rightButton);
            HideButton(coinsTextAndImgs);
            HideButton(boostButton);
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("CoinsAdded"))
                Destroy(g);
            Time.timeScale = 0;
        }
    }

    public Vehicle GetVehicle() => selectedCar;
}
