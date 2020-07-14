using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject fuelNeedle;

    void Start()
    {
        if(loadingScreen != null)
            loadingScreen.SetActive(false);
    }

    public void ButtonChangeScene(string level)
    {
        StartCoroutine(LoadAsynchronously(level));
    }

    IEnumerator LoadAsynchronously(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        if(loadingScreen != null)
            loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            if(fuelNeedle != null)
                fuelNeedle.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90f + 180f * progress);
            //System.Threading.Thread.Sleep(2000);
            yield return null;
        }
    }
}
