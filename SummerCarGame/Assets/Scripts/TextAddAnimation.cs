using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAddAnimation : MonoBehaviour
{
    public float speed;
    public float deltaY;
    private Vector3 initialPos;
    //private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = gameObject.GetComponent<RectTransform>().position;
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
        else
        {
            Destroy(gameObject);
        }
    }
}
