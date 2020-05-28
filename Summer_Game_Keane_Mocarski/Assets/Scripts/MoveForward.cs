using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private bool isWalking = false;
    public Animator anim;
    public CharacterController controller;
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isWalking = true;
            Vector3 move = transform.right * z + transform.forward * x;
            controller.Move(move * 6f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isWalking = true;
            Vector3 move = -1 * transform.right * z - transform.forward * x;
            controller.Move(move * -6f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isWalking = true;
            transform.Rotate(Vector3.up * (float)(0.1));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = true;
            playerBody.Rotate(Vector3.up * (float)(-0.1));
        }
        if(isWalking)
        {
            anim.Play("Walking");
        }
        else
        {
            anim.Play("ArmAnimation");
        }
        isWalking = false;
    }
}
