using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAddAnimation : MonoBehaviour
{
    public bool useGameObj;
    public int coinAdd;
    public float speed;
    public float deltaY;
    public string txt;
    private Vector3 initialPos;
    private GameObject sceneController;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
        initialPos = gameObject.GetComponent<RectTransform>().position;
        TextMeshProUGUI gameObjectText = gameObject.GetComponent<TextMeshProUGUI>();
        if (useGameObj)
        {
            if (sceneController.GetComponent<ButtonManager>().GetIsNightMode()) gameObjectText.text = "+" + ((int)(1.5 * (float)coinAdd)).ToString();
            else gameObjectText.text = "+" + coinAdd.ToString();
        }
        else gameObjectText.text = txt;
        gameObject.SetActive(true);    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPos = gameObject.GetComponent<RectTransform>().position;
        if (gameObject.activeInHierarchy && currentPos.y < initialPos.y + deltaY)
        {
            gameObject.GetComponent<RectTransform>().position = new Vector3(currentPos.x, currentPos.y + speed * Time.deltaTime, currentPos.z);
            float currentAlpa = gameObject.GetComponent<TextMeshProUGUI>().alpha;
            gameObject.GetComponent<TextMeshProUGUI>().alpha = currentAlpa - (speed / 100 * Time.deltaTime);
        }
        else Destroy(gameObject);
    }

    public void SetColor(Color c)
    {
        GetComponent<TextMeshProUGUI>().color = c;
    }
}
