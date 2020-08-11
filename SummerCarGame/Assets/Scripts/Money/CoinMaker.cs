using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaker : MonoBehaviour
{
    public GameObject coin;
    public float spawnInterval;
    public float roadWidth;

    private List<GameObject> powerups = new List<GameObject>();
    private float timeSinceLastSpawn;
    private int coinCounter = 0;
    private int powerupCounter = 0;

    void Start()
    {
        powerups.Add((GameObject)Resources.Load("Models/Powerups/health"));
        powerups.Add((GameObject)Resources.Load("Models/Powerups/twoTimes"));
        powerups.Add((GameObject)Resources.Load("Models/Powerups/cube"));
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0;
            GameObject addedObject;
            if (coin == null)
            {
                addedObject = powerups[(int)Random.Range(0, (float)powerups.Count - 0.01f)];
                addedObject.name = $"PowerUp{powerupCounter}";
                powerupCounter++;
                Instantiate(addedObject, new Vector3(Random.Range(-roadWidth, roadWidth), 3.5f, transform.position.z + 60f), Quaternion.Euler(-90f, 0f, 0f));
            }
            else
            {
                addedObject = coin;
                addedObject.name = $"Coin{coinCounter}";
                coinCounter++;
                Instantiate(addedObject, new Vector3(Random.Range(-roadWidth, roadWidth), 3.5f, transform.position.z + 60f), Quaternion.identity);
            }
        }
    }
}
