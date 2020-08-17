using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockedPage_ : MonoBehaviour
{
    public GameObject unlockedPagePanel;
    public GameObject nameText;
    public GameObject nameDescrText;
    public Button okButton;
    public Button useButton;

    private GameObject car;
    private GameObject autoShopPanel;
    private GameObject sceneController;

    void Start()
    {
        autoShopPanel = GameObject.FindGameObjectWithTag("AutoShopPanel");
        unlockedPagePanel.SetActive(false);
        okButton.onClick.AddListener(delegate { unlockedPagePanel.SetActive(false); });
        okButton.onClick.AddListener(delegate { DestroyCar(); });
        okButton.onClick.AddListener(delegate { autoShopPanel.SetActive(true); });
        okButton.onClick.AddListener(delegate { SceneManager.LoadScene("AutoShop"); });

        useButton.onClick.AddListener(delegate { unlockedPagePanel.SetActive(false); });
        useButton.onClick.AddListener(delegate { DestroyCar(); });
        useButton.onClick.AddListener(delegate { autoShopPanel.SetActive(true); });
        useButton.onClick.AddListener(delegate { SceneManager.LoadScene("AutoShop"); });
    }

    public void DestroyCar()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        Destroy(car);
    }
}
