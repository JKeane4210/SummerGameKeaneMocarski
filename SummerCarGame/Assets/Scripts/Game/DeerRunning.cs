using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRunning : MonoBehaviour
{
    private const float FRICTION = 0.95f; //closer to 1 means less friction

    public Transform player;
    public Rigidbody player_rigidbody;
    public float motion_multiplier;
    public float damage;
    public Material normalSkin;
    public GameObject goldSprinkle;

    private Vector3 trajectory = Vector3.forward;
    private GameObject canvas;
    
    bool sprinkling = false;
    GameObject newSprinkle;

    // Start is called before the first frame update
    void Start()
    {
        goldSprinkle = (GameObject)Resources.Load("EffectExamples/goldSprinkle");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        float degreeRotY = player.localRotation.eulerAngles.y;
        if (degreeRotY <= 151f && degreeRotY >= 89f)
            trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
        else if (degreeRotY <= 271f && degreeRotY >= 209f)
            trajectory = motion_multiplier * new Vector3(-Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
        player_rigidbody.velocity = trajectory;
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.GetComponent<powerUpBoard>().powerUpCounts[1] != 0)
        {
            gameObject.GetComponentInChildren<Renderer>().material = (Material)Resources.Load("Models/Powerups/shinierGold");  
            if (!sprinkling)
            {
                newSprinkle = Instantiate(goldSprinkle, gameObject.transform);
                newSprinkle.transform.localPosition = new Vector3(0, 0, 0);
                newSprinkle.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                sprinkling = true;
            }
        }
        else
        {
            gameObject.GetComponentInChildren<Renderer>().material = normalSkin;
            if (newSprinkle != null)
            {
                ParticleSystem.MainModule settings = newSprinkle.GetComponent<ParticleSystem>().main;
                settings.startColor = new Color(settings.startColor.color.r, settings.startColor.color.g, settings.startColor.color.b, settings.startColor.color.a - 0.05f);
            }
        }
    }

    void FixedUpdate()
    {
        if (player_rigidbody.velocity.x != trajectory.x || player_rigidbody.velocity.z != trajectory.z)
            player_rigidbody.velocity = new Vector3((player_rigidbody.velocity.x - trajectory.x) * FRICTION + trajectory.x, 0, (player_rigidbody.velocity.z - trajectory.z) * FRICTION + trajectory.z);
    }

    public float GetDamage() => damage;
    public Vector3 GetTrajectory() => trajectory;
    public void SetTrajector(Vector3 newTrajectory) => trajectory = newTrajectory;
}
