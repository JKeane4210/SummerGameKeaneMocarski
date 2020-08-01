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
    public GameObject camera;
    public GameObject selectedTerainText;
    private float location;
    private int count;
    private WorldTerrainList worldTerrains;
    private WorldTerrain[] worlds;

    // Start is called before the first frame update
    void Start()
    {
        worldTerrains = GetComponent<WorldTerrainList>();
        selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
        worlds = worldTerrains.GetWorldTerrains();
        //float elementWidth = scrollbarElement.GetComponent<RectTransform>().rect.width;
        //GetComponent<RectTransform>().sizeDelta = new Vector2(0, worlds.Length * (elementWidth + 10));
        float counter = 0;
        foreach(WorldTerrain world in worlds)
        {
            print(world.GetName());
            //GameObject newScrollbarItem = Instantiate(scrollbarElement);
            //newScrollbarItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(counter * (elementWidth + 10), 0);
            //newScrollbarItem.transform.SetParent(transform, false);
            //newScrollbarItem.name = world.GetName() + "Buttons";
            GameObject newWorld = Instantiate(world.GetNormalRoad(), new Vector3(counter * 90f, 0, 0), Quaternion.identity);
            foreach (var comp in newWorld.GetComponents<Component>())
            {
                if (!(comp is Transform))
                    Object.Destroy(comp);

            }
                
                //GameObject carCopy = Object.Instantiate(car, location, Quaternion.identity);
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
                    //print("Point A:" + pointA.ToString() + "\nPointB: " + pointB.ToString());
                    camera.transform.position = new Vector3(camera.transform.position.x + (pointB - pointA) * -0.1f, camera.transform.position.y, camera.transform.position.z);
                    pointA = pointB;
                    break;
                case TouchPhase.Ended:
                    if(camera.transform.position.x % 90 < 40)
                    {
                        camera.transform.position = new Vector3((float)((int)((camera.transform.position.x + pointB - pointA) / 90)), camera.transform.position.y, camera.transform.position.z);
                    }
                    else
                    {
                        camera.transform.position = new Vector3((float)((int)((camera.transform.position.x + pointB - pointA) / 90) + 90), camera.transform.position.y, camera.transform.position.z);
                    }
                    if (camera.transform.position.x > (float)((worlds.Length - 1) * 90))
                        camera.transform.position = new Vector3((float)((worlds.Length - 1) * 90), camera.transform.position.y, camera.transform.position.z);
                    else if (camera.transform.position.x < 0)
                        camera.transform.position = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
                    worldTerrains.SetSelectedTerrain((int)(camera.transform.position.x / 90));
                    print((int)(camera.transform.position.x / 90));
                    selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
                    break;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            pointB = Input.mousePosition.x;
            camera.transform.position = new Vector3(camera.transform.position.x + (pointB - pointA) * -0.1f, camera.transform.position.y, camera.transform.position.z);
            if (camera.transform.position.x > (float)((worlds.Length - 1) * 90))
                camera.transform.position = new Vector3((float)((worlds.Length - 1) * 90), camera.transform.position.y, camera.transform.position.z);
            else if (camera.transform.position.x < 0)
                camera.transform.position = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
            pointA = pointB;
            worldTerrains.SetSelectedTerrain((int)((camera.transform.position.x + 45) / 90));
            selectedTerainText.GetComponent<TextMeshProUGUI>().text = worldTerrains.GetSelectedTerrain().GetName();
        }
        //else
        //{ }
        //    //latVel = 0;
    }
}
