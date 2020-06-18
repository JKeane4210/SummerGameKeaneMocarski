using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRoad : MonoBehaviour
{
    public Transform car;
    public GameObject road;
    private ArrayList roads = new ArrayList();
    public float block_width;
    private float previous_z = 0;

    // Update is called once per frame
    void Update()
    {
        if ((int)(car.localPosition.z / block_width) - (int)(previous_z / block_width) > 0)
        {
            GameObject road_add = road;
            Instantiate(road_add, new Vector3(0, 1.25f, car.localPosition.z + (2 * block_width)), Quaternion.identity);
            roads.Add(road_add);
        }
        previous_z = car.localPosition.z;
        //for (int i = 0; i < roads.Count; i++)
        //{s
        //    if (Mathf.Abs(car.localPosition.z - road.transform.localPosition.z) > 15)
        //    {
        //        try

        //        if ((GameObject)roads[i] != null)
        //            Destroy((GameObject)roads[i]);
        //        roads.RemoveAt(i);
        //        i--;
        //    }
        //    print("Road " + i);
        //}
    }
}
