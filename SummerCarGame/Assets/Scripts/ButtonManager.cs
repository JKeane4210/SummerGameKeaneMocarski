using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string level;

    public void ButtonChangeScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
