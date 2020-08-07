using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMover : MonoBehaviour
{
    private float speed = 2f;
    private float delta = 1f;
    private GameObject canvas;

    Vector3 pos;

    void Start()
    {
        pos = transform.position;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 150f, 0f) * Time.deltaTime);

        float nY = Mathf.Sin(speed * Time.time) * delta + pos.y;
        transform.position = new Vector3(transform.position.x, nY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RemoveAndAddCount(other);
            GameObject addedAnim = (GameObject)Resources.Load("Models/UI_Stuff/CoinsAdded");
            GameObject addToScreen = Instantiate(addedAnim, addedAnim.transform.position, addedAnim.transform.rotation);
            addToScreen.GetComponent<TextAddAnimation>().coinAdd = other.gameObject.GetComponent<CoinCounter>().coinAddition;
            if (other.GetComponent<CoinCounter>().isTwoTimes)
                addToScreen.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            addToScreen.transform.SetParent(canvas.transform, false);
            //addToScreen.GetComponent<RectTransform>().position = new Vector3(-167, 84, 0);
            //coinsAddedMsg.SetActive(true);
        }
    }

    void RemoveAndAddCount(Collider player)
    {
        CoinCounter c = player.GetComponent<CoinCounter>();
        c.AddCoin();
        Destroy(gameObject);
    }
}
