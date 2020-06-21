using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRunning : MonoBehaviour
{
    public Transform player;
    public Rigidbody player_rigidbody;
    public float motion_multiplier;
    private Vector3 trajectory = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        float degreeRotY = player.localRotation.eulerAngles.y;
        print(degreeRotY);
        //trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.eulerAngles.y), 0f, Mathf.Sin(player.localRotation.eulerAngles.y));

        if (degreeRotY <= 151f && degreeRotY >= 89f)
            trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
        else if (degreeRotY <= 271f && degreeRotY >= 209f)
            trajectory = motion_multiplier * new Vector3(-Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
    }

    private void FixedUpdate()
    {
        player_rigidbody.velocity = trajectory;
    }
}
