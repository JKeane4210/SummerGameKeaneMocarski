using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRoad : MonoBehaviour
{
    public Transform car;
    public GameObject road;
    public GameObject gasStationRoad;
    private ArrayList roads = new ArrayList();
    public float block_width;
    //private float previous_z = 0;
    private int i = 1;
    private int i2 = 1;
    private ArrayList invalid_names = new ArrayList();
    private float distance_traveled;
    public int gasStationInterval = 10;
    private int gasStationIndicator;
    public GameObject fuelObject;

    void Start()
    {
        gasStationIndicator = gasStationInterval;
        distance_traveled = 5 * road.GetComponent<BoxCollider>().size.z;
        //invalid_names.Add("forestRoad");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if ((int)(car.localPosition.z / block_width) - (int)(previous_z / block_width) > 0)
    //    {
    //        GameObject road_add = road;
    //        Instantiate(road_add, new Vector3(0, 1.25f, car.localPosition.z + (3 * block_width)), Quaternion.identity);
    //        road_add.name = "forestRoad" + i.ToString();
    //        //roads.Add(road_add);
    //        i++;
    //    }
    //    previous_z = car.localPosition.z;
    //    //for (int i = 0; i < roads.Count; i++)
    //    //{s
    //    //    if (Mathf.Abs(car.localPosition.z - road.transform.localPosition.z) > 15)
    //    //    {
    //    //        try

    //    //        if ((GameObject)roads[i] != null)
    //    //            Destroy((GameObject)roads[i]);
    //    //        roads.RemoveAt(i);
    //    //        i--;
    //    //    }
    //    //    print("Road " + i);
    //    //}
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.ToString().Contains("forestRoad"))
        {
            //print("Blocked " + other.ToString().Split(' ')[0]);
            if (!invalid_names.Contains(other.ToString().Split(' ')[0]))
            {
                if (gasStationIndicator == 0)
                {
                    GameObject road_add = gasStationRoad;
                    road_add.GetComponent<myGasStop>().myPlane.GetComponent<FuelUp>().fuelBar = fuelObject.GetComponent<FuelBar>();
                    Instantiate(road_add, new Vector3(0, 1.25f, distance_traveled + 13.75f), Quaternion.Euler(new Vector3(0, Random.Range(0, 3) * 180, 0)));
                    roads.Add(road_add);
                    road_add.name = "forestRoadGas" + i2.ToString();
                    Debug.Log("New frame" + (i+i2).ToString() + " --> " + other.ToString());
                    invalid_names.Add(other.ToString().Split(' ')[0]);
                    distance_traveled += road_add.GetComponent<BoxCollider>().size.z;
                    gasStationIndicator = gasStationInterval;
                    i2++;
                }
                else
                {
                    GameObject road_add = road;
                    Instantiate(road_add, new Vector3(0, 1.25f, distance_traveled), Quaternion.identity);
                    roads.Add(road_add);
                    road_add.name = "forestRoad" + i.ToString();
                    Debug.Log("New frame" + (i+i2).ToString() + " --> " + other.ToString());
                    invalid_names.Add(other.ToString().Split(' ')[0]);
                    distance_traveled += road_add.GetComponent<BoxCollider>().size.z;
                    i++;
                    gasStationIndicator--;
                }  
            }
            else
                print("Blocked " + other.ToString().Split(' ')[0]);
        }
    }
}
