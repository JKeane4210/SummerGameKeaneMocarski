using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRoad : MonoBehaviour
{
    public Transform car;
    public GameObject road;
    private ArrayList roads = new ArrayList();
    public float renderRate;

    // Update is called once per frame
    void Update()
    {
        if (car.localPosition.z % 20 > renderRate)
        {
            GameObject road_add = road;
            Instantiate(road_add, new Vector3(0, 0, car.localPosition.z + 40), Quaternion.identity);
            roads.Add(road_add);
            
        }
        //for (int i = 0; i < roads.Count; i++)
        //{
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
