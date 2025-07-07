using UnityEngine;
using System.IO;

public class TextureLoader : MonoBehaviour
{
    public Renderer targetRenderer; // Or RawImage, or SpriteRenderer

    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "webcamSnapShot");

        if (File.Exists(path))
        {
            byte[] fileData = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2); // Size will be replaced
            tex.LoadImage(fileData); // Load PNG

            // Apply texture to a material
            targetRenderer.material.mainTexture = tex;
        }
        else
        {
            Debug.LogWarning("PNG file not found at: " + path);
        }
    }
}
