using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSideTrees : MonoBehaviour
{
    public GameObject tree;
    private const float SPAWN_INTERVAL = 20;
    private const float MAX_PROOTRUSION_DISTANCE = 5; // 0 is the center of the road

    private float time = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > SPAWN_INTERVAL)
        {
            time = 0;
            int sideOfRoad = Random.Range(0, 2) == 0 ? -1 : 1;
            float protrusionIntoRoad = Random.Range(MAX_PROOTRUSION_DISTANCE, 10);
            Instantiate(tree, new Vector3(0, 0, (float)sideOfRoad * protrusionIntoRoad), Quaternion.identity);
        }
    }
}
