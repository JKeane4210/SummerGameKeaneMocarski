using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorScan : MonoBehaviour
{
    static Color bgColor;
    int resWidth = 256;
    int resHeight = 256;
    float dimming_factor = 0f;
    public Camera snapCam;

    // Start is called before the first frame update
    public void SimulateStart()
    {
        gameObject.SetActive(false);
        snapCam.gameObject.SetActive(true);
        //System.Threading.Thread.Sleep(2000);
        snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapCam.Render();
        RenderTexture.active = snapCam.targetTexture;
        snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        bgColor = snapshot.GetPixel(resWidth / 2, resHeight / 2);
        print(bgColor);
        snapCam.gameObject.SetActive(false);
        gameObject.SetActive(true);
        gameObject.GetComponent<Camera>().backgroundColor = new Color(bgColor.r - dimming_factor, bgColor.g - dimming_factor, bgColor.b - dimming_factor);
        print(gameObject.GetComponent<Camera>().backgroundColor);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    SimulateStart();
    //}
}
