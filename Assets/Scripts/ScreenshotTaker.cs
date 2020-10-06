using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Saved!");
        ScreenCapture.CaptureScreenshot("SampleScreenshot");
    }
}
