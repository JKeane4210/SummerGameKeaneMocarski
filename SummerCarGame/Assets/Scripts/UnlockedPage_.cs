using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedPage_ : MonoBehaviour
{
    public GameObject unlockedPagePanel;
    public GameObject nameText;
    public GameObject nameDescrText;
    public GameObject okButton;
    private GameObject car;

    void Start()
    {
        unlockedPagePanel.SetActive(false);
        okButton.GetComponent<Button>().onClick.AddListener(delegate { unlockedPagePanel.SetActive(false); });
        okButton.GetComponent<Button>().onClick.AddListener(delegate { DestroyCar(); });
    }

    public void DestroyCar()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        Destroy(car);
    }
}
