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

    void Start()
    {
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);
            fuelNeedle.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void ButtonChangeScene(string level)
    {
        //SavePlayerData.SavePlayer();
        StartCoroutine(LoadAsynchronously(level));
    }

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
