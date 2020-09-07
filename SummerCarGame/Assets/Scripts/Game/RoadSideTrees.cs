using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSideTrees : MonoBehaviour
{
    public GameObject tree;
    public float spawnInterval = 20;
    public float maxProtrusionDistance = 5; // 0 is the center of the road

    private float time = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > spawnInterval)
        {
            time = 0;
            int sideOfRoad = Random.Range(0, 2) == 0 ? -1 : 1;
            float protrusionIntoRoad = Random.Range(maxProtrusionDistance, 10);
            Instantiate(tree, new Vector3(0, 0, (float)sideOfRoad * protrusionIntoRoad), Quaternion.identity);
        }
    }
}
