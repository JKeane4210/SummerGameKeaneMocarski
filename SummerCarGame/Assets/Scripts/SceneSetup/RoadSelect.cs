using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RoadSelect : MonoBehaviour
{
    private float pointA;
    private float pointB;
    public GameObject roundPlatform;
    public GameObject mainCamera;
    public GameObject selectedTerainText;
    private WorldTerrainList worldTerrains;
    private WorldTerrain[] worlds;

    // Start is called before the first frame update
    void Start()
    {
        worldTerrains = GetComponent<WorldTerrainList>();
        mainCamera.transform.position = new Vector3((float)(worldTerrains.GetSelectedTerrainInd() * 90), mainCamera.transform.position.y, mainCamera.transform.position.z);
        selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
        worlds = worldTerrains.GetWorldTerrains();
        float counter = 0;
        foreach(WorldTerrain world in worlds)
        {
            GameObject newWorld = Instantiate(world.GetNormalRoad(), new Vector3(counter * 90f, 0, 0), Quaternion.identity);
            foreach (var comp in newWorld.GetComponents<Component>())
                if (!(comp is Transform))
                    Object.Destroy(comp);
            GameObject newPlatform = Instantiate(roundPlatform, new Vector3(counter * 90f, -2.2f, 0), Quaternion.identity);
            newPlatform.transform.localScale = new Vector3(2325, 210, 1300);
            counter += 1;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    pointA = Input.GetTouch(0).position.x;
                    break;
                case TouchPhase.Moved:
                    pointB = Input.GetTouch(0).position.x;
                    mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + (pointB - pointA) * -0.1f, mainCamera.transform.position.y, mainCamera.transform.position.z);
                    pointA = pointB;
                    if (mainCamera.transform.position.x > (float)((worlds.Length - 1) * 90))
                        mainCamera.transform.position = new Vector3((float)((worlds.Length - 1) * 90), mainCamera.transform.position.y, mainCamera.transform.position.z);
                    else if (mainCamera.transform.position.x < 0)
                        mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
                    worldTerrains.SetSelectedTerrain((int)((mainCamera.transform.position.x + 45) / 90));
                    selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
                    break;
                //case TouchPhase.Ended:
                //    if (mainCamera.transform.position.x % 90 < 40)
                //    {
                //        mainCamera.transform.position = new Vector3((float)((int)((mainCamera.transform.position.x + pointB - pointA) / 90)), mainCamera.transform.position.y, mainCamera.transform.position.z);
                //    }
                //    else
                //    {
                //        mainCamera.transform.position = new Vector3((float)((int)((mainCamera.transform.position.x + pointB - pointA) / 90) + 90), mainCamera.transform.position.y, mainCamera.transform.position.z);
                //    }
                //    if (mainCamera.transform.position.x > (float)((worlds.Length - 1) * 90))
                //        mainCamera.transform.position = new Vector3((float)((worlds.Length - 1) * 90), mainCamera.transform.position.y, mainCamera.transform.position.z);
                //    else if (mainCamera.transform.position.x < 0)
                //        mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
                //    worldTerrains.SetSelectedTerrain((int)(mainCamera.transform.position.x / 90));
                //    print((int)(mainCamera.transform.position.x / 90));
                //    worldTerrains.SetSelectedTerrain((int)((mainCamera.transform.position.x + 45) / 90));
                //    selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
                //    break;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            pointB = Input.mousePosition.x;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + (pointB - pointA) * -0.1f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            if (mainCamera.transform.position.x > (float)((worlds.Length - 1) * 90))
                mainCamera.transform.position = new Vector3((float)((worlds.Length - 1) * 90), mainCamera.transform.position.y, mainCamera.transform.position.z);
            else if (mainCamera.transform.position.x < 0)
                mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
            pointA = pointB;
            worldTerrains.SetSelectedTerrain((int)((mainCamera.transform.position.x + 45) / 90));
            selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
        }
        //else
        //{ }
        //    //latVel = 0;
    }
}
