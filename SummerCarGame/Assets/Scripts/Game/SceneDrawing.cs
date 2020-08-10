using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneDrawing : MonoBehaviour
{
    private const int HEALTH_SLIDER_MAX_VALUE = 100;
    private const float FUEL_SLIDER_MAX_VALUE = 4;

    public GameObject sun;
    public GameObject headlightL;
    public GameObject headlighR;
    public GameObject illuminateCar;
    public GameObject mainCamera;
    public GameObject healthBarObj;
    public GameObject fuelBarObj;
    public GameObject replayButton;
    public GameObject homeButton;
    public GameObject gameOverTextField;
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
            catch { print("Already has no RandomDeerInstantion"); }
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
        HideItems(new GameObject[] { replayButton,
                                     homeButton,
                                     gameOverTextField,
                                     finalDistanceField,
                                     roadSelectButton });
        ShowItems(new GameObject[] { distanceField,
                                     leftButton,
                                     rightButton,
                                     coinsTextAndImgs,
                                     boostButton });
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

    public void HideItem(GameObject gameObject) => gameObject.SetActive(false);
    public void ShowItem(GameObject gameObject) => gameObject.SetActive(true);

    public void HideItems(GameObject[] gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
            HideItem(gameObject);
    }

    public void ShowItems(GameObject[] gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
            ShowItem(gameObject);
    }

    void Update()
    {
        bool outOfFuel = fuelBarObj.GetComponent<FuelBar>().GetFuel() == 0;
        bool damagedBeyondRepair = healthBarObj.GetComponent<HealthBar>().GetValue() == 0;
        bool gameOver = damagedBeyondRepair || outOfFuel;
        if (gameOver)
        {
            if(damagedBeyondRepair)
                gameOverTextField.GetComponent<UnityEngine.UI.Text>().text = "Damaged Beyond Repair";
            else
                gameOverTextField.GetComponent<UnityEngine.UI.Text>().text = "Out Of Fuel";
            ShowItems(new GameObject[] { gameOverTextField,
                                         replayButton,
                                         homeButton,
                                         finalDistanceField,
                                         roadSelectButton });
            HideItems(new GameObject[] { distanceField,
                                         leftButton,
                                         rightButton,
                                         coinsTextAndImgs,
                                         boostButton });
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("CoinsAdded"))
                Destroy(g);
            Time.timeScale = 0;
        }
    }

    public Vehicle GetVehicle() => selectedCar;
    public void ReloadScene() => SceneManager.LoadScene("Car");
    public void ResetHealthBar(HealthBar healthBar) => healthBar.SetMaxHealth(HEALTH_SLIDER_MAX_VALUE);
    public void ResetFuelBar(FuelBar fuelBar) => fuelBar.SetMaxFuel(FUEL_SLIDER_MAX_VALUE);
}
