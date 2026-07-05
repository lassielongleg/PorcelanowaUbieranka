using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Screenshot : MonoBehaviour
{
    private enum CaptureMode
    {
        Fullscreen,
        CroppedWidth,
    }

    [SerializeField]
    private string _subFolder = "Screenshots";

    [SerializeField]
    private CaptureMode _captureMode = CaptureMode.CroppedWidth;

    [SerializeField, Range(0.01f, 1f)]
    private float _widthFactor = 0.25f;

    private string SaveDirectory => Path.Combine(Application.dataPath, _subFolder);

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(TakeScreenshot);
    }

    private void TakeScreenshot()
    {
        StartCoroutine(TakeScreenshotCoroutine());
    }

    private System.Collections.IEnumerator TakeScreenshotCoroutine()
    {
        yield return new WaitForEndOfFrame();
        var full = ScreenCapture.CaptureScreenshotAsTexture();

        var texture = _captureMode == CaptureMode.CroppedWidth ? CropCentered(full) : full;

        if (!Directory.Exists(SaveDirectory))
            Directory.CreateDirectory(SaveDirectory);

        var fileName = $"screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        var fullPath = Path.Combine(SaveDirectory, fileName);

        File.WriteAllBytes(fullPath, texture.EncodeToPNG());

        if (texture != full)
            Destroy(texture);
        Destroy(full);

        Debug.Log($"Screenshot saved: {fullPath}");
    }

    private Texture2D CropCentered(Texture2D src)
    {
        var width = Mathf.Max(1, Mathf.RoundToInt(src.width * _widthFactor));
        var positionX = (src.width - width) / 2;

        var cropped = new Texture2D(
            width: width,
            height: src.height,
            textureFormat: src.format,
            mipChain: false
        );
        cropped.SetPixels(
            src.GetPixels(x: positionX, y: 0, blockWidth: width, blockHeight: src.height)
        );
        cropped.Apply();
        return cropped;
    }
}