using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentedFade : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent == null)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            ParticleSystem.MainModule settings = gameObject.GetComponent<ParticleSystem>().main;
            settings.startColor = new Color(settings.startColor.color.r, settings.startColor.color.g, settings.startColor.color.b, settings.startColor.color.a - 0.05f);
        }
    }
}
