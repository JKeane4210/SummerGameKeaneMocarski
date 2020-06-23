using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControls : MonoBehaviour
{
    public GameObject controlTextField;
    static int activeIndex = 0;

    void Start()
    {
        if (controlTextField != null)
        {
            ChangeTextField(activeIndex);
        }
    }

    public void ChangeTextField(int i)
    {
        if (i == 0)
        {
            controlTextField.GetComponent<UnityEngine.UI.Text>().text = "Current Controls: " + "Buttons";
            activeIndex = 0;
        }
        else if (i == 1)
        {
            controlTextField.GetComponent<UnityEngine.UI.Text>().text = "Current Controls: " + "Tilt";
            activeIndex = 1;
        }
        else if (i == 2)
        {
            controlTextField.GetComponent<UnityEngine.UI.Text>().text = "Current Controls: " + "Swipe";
            activeIndex = 2;
        }
    }

    public int GetActiveIndex()
    {
        return activeIndex;
    }
}
