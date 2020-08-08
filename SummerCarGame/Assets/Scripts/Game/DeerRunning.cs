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

    // Start is called before the first frame update
    void Start()
    {
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
        if(canvas.GetComponent<powerUpBoard>().powerUpCounts[1] != 0)
            gameObject.GetComponentInChildren<Renderer>().material = (Material)Resources.Load("Models/Powerups/shinierGold");
        else
            gameObject.GetComponentInChildren<Renderer>().material = normalSkin;
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
