using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private const float FORCE_STRENGTH = 200;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Vector3 currentPosition = other.gameObject.transform.position;
            float deltaX = currentPosition.x - gameObject.transform.position.x;
            float deltaZ = currentPosition.z - gameObject.transform.position.z;
            //print($"({deltaX}, {deltaZ})");
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(deltaX * FORCE_STRENGTH,
                                                                            0,
                                                                            deltaZ * FORCE_STRENGTH));
        }
    }
}
