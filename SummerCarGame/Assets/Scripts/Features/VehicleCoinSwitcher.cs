using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCoinSwitcher : MonoBehaviour
{
    public GameObject vehiclesPanel;
    public GameObject coinsPanel;

    public void ActivatePanel(bool vehiclesPanelActive)
    {
        vehiclesPanel.SetActive(vehiclesPanelActive);
        coinsPanel.SetActive(!vehiclesPanelActive);
    }

    private void Start()
    {
        ActivatePanel(true);
    }
}
