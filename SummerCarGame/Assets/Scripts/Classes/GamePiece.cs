using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePiece
{
    readonly private string name;
    readonly private string assetPath;

    public GamePiece(string name, string assetPath)
    {
        this.name = name;
        this.assetPath = assetPath;
    }

    public string GetName() => name;
    public string GetAssetPath() => assetPath;
    public GameObject GetGameObject() => (GameObject)Resources.Load(assetPath);
    public GameObject PlaceGameObject(Vector3 loc, Quaternion rot) => Object.Instantiate(GetGameObject(), loc, rot);
}
