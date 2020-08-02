using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeerInstantiation : MonoBehaviour
{
    [SerializeField] AnimationCurve myCurve;
    public GameObject deer_obj;
    public GameObject controller;
    private int deer_count;
    private float timeUntilMaxDifficulty = 60;
    //private GameObject car;
    //public GameObject deer_container;

    // Start is called before the first frame update
    void Start()
    {
        //car = GameObject.FindGameObjectWithTag("Player");
        //print("Time " + Time.time.ToString());
        float difficulty = myCurve.Evaluate(Time.timeSinceLevelLoad / timeUntilMaxDifficulty); // 0-1 (1 = max difficulty)
        //print(difficulty.ToString());
        int random_num = (int)Random.Range(difficulty * 5f, 6f + difficulty * 2f);
        if (random_num <= 2)
            deer_count = 1;
        else if (random_num <= 4)
            deer_count = 2;
        else if (random_num == 5)
            deer_count = 3;
        else if (random_num == 6)
            deer_count = 4;
        else if (random_num == 7)
            deer_count = 5;
        else if (random_num == 8)
            deer_count = 6;
        //print(random_num + " " +deer_count);
        for (int i = 0; i < deer_count; i++)
        {
            GameObject deer = deer_obj;
            deer.GetComponent<Rigidbody>().useGravity = false;
            DeerRunning deer_running = deer.GetComponent<DeerRunning>();
            deer_running.motion_multiplier = Random.Range(9f, 12f);
            deer_running.player = deer.GetComponent<Transform>();
            deer_running.player_rigidbody = deer.GetComponent<Rigidbody>();
            float controller_z = controller.GetComponent<Transform>().localPosition.z;
            int random_side = Random.Range(0, 2);
            int pn_side;
            if (random_side == 0)
                pn_side = -1;
            else
                pn_side = 1;
            //print(pn_side);
            Quaternion rotation;
            if (pn_side == -1)
                rotation = Quaternion.Euler(0f, Random.Range(90f, 150f), 0f);
            else
                rotation = Quaternion.Euler(0f, Random.Range(210f, 270f),0f);
            Instantiate(deer, new Vector3(Random.Range(pn_side * 10f, pn_side * 20f), 2.3f, Random.Range(controller_z -30f - 20f, controller_z -30f + 10f)), rotation);
        }
    }
}
