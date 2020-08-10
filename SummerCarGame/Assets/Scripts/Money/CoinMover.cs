using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMover : MonoBehaviour
{
    private const float BOBBING_SPEED = 2f;
    private const float BOBBING_AMPLITUDE = 1f;
    private GameObject canvas;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 150f, 0f) * Time.deltaTime);
        float newY = Mathf.Sin(BOBBING_SPEED * Time.time) * BOBBING_AMPLITUDE + initialPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RemoveAndAddCount(other);
            GameObject addedAnim = (GameObject)Resources.Load("Models/UI_Stuff/CoinsAdded");
            GameObject addToScreen = Instantiate(addedAnim, addedAnim.transform.position, addedAnim.transform.rotation);
            addToScreen.GetComponent<TextAddAnimation>().coinAdd = other.gameObject.GetComponent<CoinCounter>().coinAddition;
            if (canvas.GetComponent<powerUpBoard>().powerUpCounts[0] > 0)
                addToScreen.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            addToScreen.transform.SetParent(canvas.transform, false);
        }
    }

    void RemoveAndAddCount(Collider player)
    {
        CoinCounter c = player.GetComponent<CoinCounter>();
        c.AddCoin();
        Destroy(gameObject);
    }
}
