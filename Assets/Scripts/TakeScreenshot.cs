using System;
using System.IO;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public string screenshotKey = "q"; // Key to trigger the screenshot capture
    public GameObject screenshotTakenMessage; // Reference to the message GameObject
    public LeftPrimaryButton leftPrimaryButton;
    private void Start()
    {
        leftPrimaryButton.OnLeftPrimaryButton += LeftPrimaryButton_OnLeftPrimaryButton;
    }

    private void LeftPrimaryButton_OnLeftPrimaryButton(object sender, EventArgs e)
    {
        CaptureScreenshot();
    }


    void CaptureScreenshot()
    {
        int screenshotWidth = playerCamera.pixelWidth;
        int screenshotHeight = playerCamera.pixelHeight;

        RenderTexture renderTexture = new RenderTexture(screenshotWidth, screenshotHeight, 24);
        playerCamera.targetTexture = renderTexture;
        playerCamera.Render();

        RenderTexture.active = renderTexture;

        Texture2D screenshot = new Texture2D(screenshotWidth, screenshotHeight);
        screenshot.ReadPixels(new Rect(0, 0, screenshotWidth, screenshotHeight), 0, 0);
        screenshot.Apply();

        playerCamera.targetTexture = null;

        byte[] bytes = screenshot.EncodeToPNG();
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

        string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(folderPath, "Screenshot/screenshot_" + timestamp + ".png");

        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Screenshot saved to: " + filePath);

        if (screenshotTakenMessage != null)
        {
            screenshotTakenMessage.SetActive(true);
        }
    }

    void HideScreenshotTakenMessage()
    {
        if (screenshotTakenMessage != null)
        {
            screenshotTakenMessage.SetActive(false);
        }
    }
}