using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunPoint : MonoBehaviour
{
    public GameObject sun;

    void Start() => sun.transform.rotation = Quaternion.Euler(new Vector3(GameDataManager.GetSunPoint(), 0, 0));
}
