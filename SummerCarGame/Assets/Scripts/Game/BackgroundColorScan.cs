using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorScan : MonoBehaviour
{
    static Color bgColor;
    const int CAPTURE_WIDTH = 256;
    const int CAPTURE_HEIGHT = 256;
    public Camera snapCam;

    /// <summary>
    /// Runs what would want to be called by Start, but it is called in the Start method of another instance
    /// Checks the color in front of the camera and makes the background that color based on lighting, etc.
    /// </summary>
    public void SimulateStart()
    {
        gameObject.SetActive(false);
        snapCam.gameObject.SetActive(true);
        snapCam.targetTexture = new RenderTexture(CAPTURE_WIDTH, CAPTURE_HEIGHT, 24);
        Texture2D snapshot = new Texture2D(CAPTURE_WIDTH, CAPTURE_HEIGHT, TextureFormat.RGB24, false);
        snapCam.Render();
        RenderTexture.active = snapCam.targetTexture;
        snapshot.ReadPixels(new Rect(0, 0, CAPTURE_WIDTH, CAPTURE_HEIGHT), 0, 0);
        bgColor = snapshot.GetPixel(CAPTURE_WIDTH / 2, CAPTURE_HEIGHT / 2);
        snapCam.gameObject.SetActive(false);
        gameObject.SetActive(true);
        float red = bgColor.r;
        float green = bgColor.g;
        float blue = bgColor.b;
        //if (red > 67f / 255f)
        //    red = 67f / 255f;
        //if (green > 160f / 255f)
        //    green = 160f / 255f;
        //if (blue > 85f / 255f)
        //    blue = 85f / 255f;
        gameObject.GetComponent<Camera>().backgroundColor = new Color(red, green, blue);
    }
}
