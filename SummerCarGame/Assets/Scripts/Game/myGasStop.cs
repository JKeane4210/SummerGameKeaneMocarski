using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGasStop : MonoBehaviour
{
    public GameObject myPlane;
    public GameObject gasLight1;
    public GameObject gasLight2;
    private GameObject sceneController;

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
        if(sceneController.GetComponent<ButtonManager>().GetIsNightMode())
        {
            gasLight1.SetActive(true);
            gasLight2.SetActive(true);
        }
        else
        {
            gasLight1.SetActive(false);
            gasLight2.SetActive(false);
        }
    }
}
