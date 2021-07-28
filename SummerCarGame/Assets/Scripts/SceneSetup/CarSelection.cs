using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [SerializeField]private Button previousButton;
    [SerializeField]private Button nextButton;
    
    private int currentCar;
    private void Awake()
    {
        SelectCar(0);
    }

    /// <summary>
    /// Functionality for selecting a car to use
    /// </summary>
    /// <param name="_index">Car index</param>
    private void SelectCar(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount-1);
      for(int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(1).gameObject.SetActive(i == _index);
      }
    }

    /// <summary>
    /// Changes car
    /// </summary>
    /// <param name="_change">Select index</param>
    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);
    }
}
