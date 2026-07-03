using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Screenshot : MonoBehaviour
{
    [SerializeField] private string _subFolder = "Screenshots";

    private string SaveDirectory => Path.Combine(Application.persistentDataPath, _subFolder);

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(TakeScreenshot);
    }

    private void TakeScreenshot()
    {
        var texture = ScreenCapture.CaptureScreenshotAsTexture();

        if (!Directory.Exists(SaveDirectory))
            Directory.CreateDirectory(SaveDirectory);

        var fileName = $"screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        var fullPath = Path.Combine(SaveDirectory, fileName);

        File.WriteAllBytes(fullPath, texture.EncodeToPNG());
        Destroy(texture);

        Debug.Log($"Screenshot saved: {fullPath}");
    }
}