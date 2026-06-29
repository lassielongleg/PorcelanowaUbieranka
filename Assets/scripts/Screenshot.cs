using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generate a screenshot and save it to disk with the name SomeLevel.png.

public class ExampleScript : MonoBehaviour
{
    void OnMouseDown()
    {
        ScreenCapture.CaptureScreenshot("SomeLevel.png");
    }
}
