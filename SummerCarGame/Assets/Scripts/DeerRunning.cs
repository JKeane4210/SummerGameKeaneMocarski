using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRunning : MonoBehaviour
{
    public float vel_min;
    public float vel_max;
    public Transform player;
    public Rigidbody player_rigidbody;
    public float motion_multiplier;
    private Vector3 trajectory = Vector3.forward + Vector3.up * 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
    }

    private void FixedUpdate()
    {
        player_rigidbody.velocity = trajectory;
    }
}
