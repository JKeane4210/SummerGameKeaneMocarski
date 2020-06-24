using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    private float speed = 2f;
    private float delta = 1f;

    Vector3 pos;

    void Start()
    {
        pos = transform.position;   
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
        }
    }

    void RemoveAndAddCount(Collider player)
    {
        CoinCounter c = player.GetComponent<CoinCounter>();
        c.AddCoin();
        Destroy(gameObject);
    }
}
