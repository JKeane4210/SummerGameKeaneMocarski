using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject fuelNeedle;
    public GameObject loadingText;
    static bool isNightMode = false;

    /// <summary>
    /// What to do on startup of the scene
    ///     - Save player data
    ///     - Set up the loading scene if exists
    /// </summary>
    void Start()
    {
        SavePlayerData.LoadPlayer();
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);
            fuelNeedle.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    /// <summary>
    /// Changes the scene of the button (also saves the player data)
    /// </summary>
    /// <param name="level">The scene to load into</param>
    public void ButtonChangeScene(string level)
    {
        SavePlayerData.SavePlayer();
        StartCoroutine(LoadAsynchronously(level));
    }

    /// <summary>
    /// Move the fuel needle around based on the percent loaded
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    IEnumerator LoadAsynchronously(string level)
    {
        float moveSpeed = 0.05f;
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        //operation.allowSceneActivation = false;
        if (loadingScreen != null)
            loadingScreen.SetActive(true);
        if (fuelNeedle != null)
        {
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                Debug.Log(progress);
                float loaded_angle = 90f - 180f * progress;
                //fuelNeedle.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, loade);
                while (fuelNeedle.GetComponent<RectTransform>().rotation.eulerAngles.z != loaded_angle)
                {
                    fuelNeedle.GetComponent<RectTransform>().rotation = Quaternion.Slerp(fuelNeedle.GetComponent<RectTransform>().rotation, Quaternion.Euler(0, 0, loaded_angle), moveSpeed * Time.time);
                    float piece = fuelNeedle.GetComponent<RectTransform>().rotation.eulerAngles.z;
                    if (piece >= 270)
                        piece = -NegativeAngle(piece); //<0>>>90
                    else
                        piece = -NegativeAngle(piece) - 360; //-90>>>0
                    piece += 90; //0>>>180
                    loadingText.GetComponent<TextMeshProUGUI>().text = "Fueling Up " + ((int)(100f * (piece/ 180f))).ToString() + "%";
                    if (fuelNeedle.GetComponent<RectTransform>().rotation.eulerAngles.z == 270)
                        break;
                    yield return null;
                }
                if (fuelNeedle.GetComponent<RectTransform>().rotation.eulerAngles.z == 270)
                    break;
                yield return null;
            }
        }
        operation.allowSceneActivation = true;
    }

    private float NegativeAngle(float f) => -(360f - f);
    public void ChangeIsNightMode(bool nm) => isNightMode = nm;
    public bool GetIsNightMode() => isNightMode;
    public void FlipNightMode() => isNightMode = !isNightMode;
    public void ReloadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
