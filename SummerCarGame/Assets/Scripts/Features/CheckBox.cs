using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{
    public GameObject check;
    static bool isChecked = false;

    void Start()
    {
        if (isChecked)
            check.SetActive(true);
        else
            check.SetActive(false);
        GetComponent<Button>().onClick.AddListener(delegate { ChangeCheck(); });
    }

    public void ChangeCheck()
    {
        if (isChecked)
        {
            isChecked = false;
            check.SetActive(false);
        }
        else
        {
            isChecked = true;
            check.SetActive(true);
        }
    }

    public bool IsChecked()
    {
        return isChecked;
    }

}
