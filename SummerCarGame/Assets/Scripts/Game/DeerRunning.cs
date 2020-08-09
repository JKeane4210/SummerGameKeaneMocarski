using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRunning : MonoBehaviour
{
    public Transform player;
    public Rigidbody player_rigidbody;
    public float motion_multiplier;
    public float damage;
    private Vector3 trajectory = Vector3.forward;
    private GameObject canvas;
    public Material normalSkin;
    public GameObject goldSprinkle;
    bool sprinkling = false;
    GameObject newSprinkle;

    // Start is called before the first frame update
    void Start()
    {
        goldSprinkle = (GameObject)Resources.Load("EffectExamples/goldSprinkle");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        //normalSkin = gameObject.GetComponentInChildren<Renderer>().material;
        float degreeRotY = player.localRotation.eulerAngles.y;
        //print(degreeRotY);
        //trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.eulerAngles.y), 0f, Mathf.Sin(player.localRotation.eulerAngles.y));

        if (degreeRotY <= 151f && degreeRotY >= 89f)
            trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
        else if (degreeRotY <= 271f && degreeRotY >= 209f)
            trajectory = motion_multiplier * new Vector3(-Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
    }

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

    private void FixedUpdate()
    {
        player_rigidbody.velocity = trajectory;
    }

    public float GetDamage()
    {
        return damage;
    }
}
