using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaker : MonoBehaviour
{
    public GameObject coin;
    private List<GameObject> powerups = new List<GameObject>();
    public float interval;
    private float time;
    private int counter = 0;
    private int power_counter = 0;
    public float width;

    void Start()
    {
        powerups.Add((GameObject)Resources.Load("Models/Powerups/health"));
        powerups.Add((GameObject)Resources.Load("Models/Powerups/twoTimes"));
        powerups.Add((GameObject)Resources.Load("Models/Powerups/cube"));
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= interval)
        {
            time = 0;
            GameObject coin_add = coin;
            if (coin == null)
            {
                coin_add = powerups[(int)Random.Range(0, (float)powerups.Count - 0.01f)];
                coin_add.name = "PowerUp" + power_counter.ToString();
                power_counter++;
                Instantiate(coin_add, new Vector3(Random.Range(-width, width), 3.5f, transform.position.z + 60f), Quaternion.Euler(-90f, 0f, 0f));
            }
            else
            {
                coin_add.name = "Coin" + counter.ToString();
                counter++;
                Instantiate(coin_add, new Vector3(Random.Range(-width, width), 3.5f, transform.position.z + 60f), Quaternion.identity);
            }
        }
    }
}
