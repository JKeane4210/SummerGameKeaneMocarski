using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeerInstantiation : MonoBehaviour
{
    public GameObject deer_obj;
    public GameObject controller;
    private int deer_count;

    // Start is called before the first frame update
    void Start()
    {
        int random_num = (int)Random.Range(1f, 6f);
        if (random_num <= 2)
            deer_count = 1;
        else if (random_num <= 4)
            deer_count = 2;
        else if (random_num <= 5)
            deer_count = 3;
        else
            deer_count = 4;
        for (int i = 0; i <= deer_count; i++)
        {
            GameObject deer = deer_obj;
            deer.GetComponent<Rigidbody>().useGravity = false;
            DeerRunning deer_running = deer.GetComponent<DeerRunning>();
            deer_running.motion_multiplier = Random.Range(9f, 12f);
            deer_running.player = deer.GetComponent<Transform>();
            deer_running.player_rigidbody = deer.GetComponent<Rigidbody>();
            float controller_z = controller.GetComponent<Transform>().localPosition.z;
            Quaternion rotation = Quaternion.Euler(0f, Random.Range(90f, 150f), 0f);
            Instantiate(deer, new Vector3(Random.Range(-10f, -20f), 2.25f, Random.Range(controller_z -5f - 10f, controller_z -5f + 10f)), rotation);
        }
    }
}
