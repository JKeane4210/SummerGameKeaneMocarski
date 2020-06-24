using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaker : MonoBehaviour
{
    public GameObject coin;
    public float interval;
    private float time;
    private int counter = 0;
    public float width;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval)
        {
            time = 0;
            GameObject coin_add = coin;
            coin_add.name = "Coin" + counter.ToString();
            counter++;
            Instantiate(coin_add, new Vector3(Random.Range(-width, width), 3.5f, transform.position.z + 60f), Quaternion.identity);
        }
    }
}
