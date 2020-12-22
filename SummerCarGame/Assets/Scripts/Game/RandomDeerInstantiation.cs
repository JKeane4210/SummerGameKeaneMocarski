using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeerInstantiation : MonoBehaviour
{
    [SerializeField] string[] animalNames; //automatically filled so we know what animals are available
    [SerializeField] AnimationCurve myCurve;

    private const float TIME_UNTIL_MAX_DIFFICULTY = 60;
    private const float TIME_OFFSET_FROM_HITTING_DESTINATION = 2;

    private Animal[] animals;
    private GameObject deer_obj;
    public GameObject controller;
    private int deer_count;
    private GameObject sceneContr;
    private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        sceneContr = GameObject.FindGameObjectWithTag("SceneController");
        animals  = sceneContr.GetComponent<WorldTerrainList>().GetSelectedTerrain().GetAnimals();
        animalNames = new string[animals.Length];
        int animal_ind = (int)Random.Range(0, (float)animals.Length - 0.01f);
        Animal currentAnimal = animals[animal_ind];
        deer_obj = currentAnimal.GetGameObject();
        for (int i = 0; i < animalNames.Length; i++)
            animalNames[i] = animals[i].GetName();
        float averageVel = currentAnimal.GetAverageSpeed();
        float difficulty = myCurve.Evaluate(Time.timeSinceLevelLoad / TIME_UNTIL_MAX_DIFFICULTY); // 0-1 (1 = max difficulty)
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
        for (int i = 0; i < deer_count; i++)
        {
            GameObject deer = deer_obj;
            deer.GetComponent<Rigidbody>().useGravity = false;
            DeerRunning deer_running = deer.GetComponent<DeerRunning>();
            float vel = Random.Range(averageVel - 1.5f, averageVel + 1.5f);
            deer_running.motion_multiplier = vel;
            deer_running.damage = animals[0].GetDamage();
            deer_running.player = deer.GetComponent<Transform>();
            deer_running.player_rigidbody = deer.GetComponent<Rigidbody>();
            deer_running.normalSkin = deer.GetComponentInChildren<Renderer>().sharedMaterial;
            int pn_side = Random.Range(0, 2) - 1;
            Quaternion rotation;
            if (pn_side == -1)
                rotation = Quaternion.Euler(0f, Random.Range(90f, 150f), 0f);
            else
                rotation = Quaternion.Euler(0f, Random.Range(210f, 270f),0f);
            float carZ = car.transform.position.z;
            float futureCarZ = carZ + TIME_OFFSET_FROM_HITTING_DESTINATION * car.GetComponent<SwipeControls>().velocity;
            Vector3 destination = new Vector3(Random.Range(-10f, 10f), 2.3f, Random.Range(futureCarZ, futureCarZ + 30));
            float distance = TIME_OFFSET_FROM_HITTING_DESTINATION * vel;
            float theta = rotation.y;
            Vector3 start = new Vector3(destination.x + pn_side * distance * Mathf.Cos(theta), 2.3f, destination.z + distance * Mathf.Sin(theta));
            Instantiate(deer, start, rotation);
        }
    }
}
