using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControls : MonoBehaviour
{
    public GameObject controlTextField;

    void Start()
    {
        if (controlTextField != null) ChangeTextField(GameDataManager.GetSelectedControl());
    }

    public void ChangeTextField(int i)
    {
        controlTextField.GetComponent<UnityEngine.UI.Text>().text = "Current Controls: " + (i == 0 ? "Buttons" : (i == 1 ? "Tilt" : "Swipe"));
        GameDataManager.SetSelectedControl(i);
    }
}
