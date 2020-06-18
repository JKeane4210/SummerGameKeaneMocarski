using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeerInstantiation : MonoBehaviour
{
    public GameObject deer_obj;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        GameObject deer = deer_obj;
        deer.GetComponent<Rigidbody>().useGravity = false;
        DeerRunning deer_running = deer.GetComponent<DeerRunning>();
        deer_running.motion_multiplier = Random.Range(6f, 9f);
        deer_running.player = deer.GetComponent<Transform>();
        deer_running.player_rigidbody = deer.GetComponent<Rigidbody>();
        float controller_z = controller.GetComponent<Transform>().localPosition.z;
        Quaternion rotation = Quaternion.Euler(0f, Random.Range(90f, 150f), 0f);
        Instantiate(deer, new Vector3(Random.Range(-10f, -12.5f), 2.5f, Random.Range(controller_z - 20f - 5f, controller_z - 20f + 5f)), rotation);
    }

}
