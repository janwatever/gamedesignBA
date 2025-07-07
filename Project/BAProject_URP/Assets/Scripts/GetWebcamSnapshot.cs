using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class GetWebcamSnapshot : MonoBehaviour 
{
    public GameObject webcamDisplayobj;
    public GameObject triggerSnap;
    public bool stopCamera;
    public Texture noCamTexture;
    WebCamTexture webcamTexture = null;
    Material webcamDisplayMat = null;

    public void SetStopCamTrue() => stopCamera = true;
    public void SetStopCamFalse() => stopCamera = false;

    void Start()
    {
        //Save get the camera devices, in case you have more than 1 camera.
        WebCamDevice[] camDevices = WebCamTexture.devices;
        //Get the material for the webcam display obj
        webcamDisplayMat = webcamDisplayobj.GetComponent<Renderer>().material;

        //Get the used camera name for the WebCamTexture initialization.
        string camName = camDevices[0].name;
        webcamTexture = new WebCamTexture(camName);

        //Render the image in the screen.
        webcamDisplayMat.mainTexture = webcamTexture;
        webcamTexture.Play();


    }

    void Update()
    {
        // if (triggerSnap.activeSelf == true)
        // {
        //     stopCamera = true;
        // }
        // else
        // {
        //     stopCamera = false;
        // }


        //This is to take the picture, save it and stop capturing the camera image.
        if (stopCamera == true)
        {
            SaveImage();
            webcamTexture.Stop();
        }
    }


    void SaveImage()
    {
        //Create a Texture2D with the size of the rendered image on the screen.
        Texture2D texture = new Texture2D(webcamDisplayMat.mainTexture.width, webcamDisplayMat.mainTexture.height, TextureFormat.ARGB32, false);
        
        //Save the image to the Texture2D
        texture.SetPixels(webcamTexture.GetPixels());
        texture.Apply();

        //Encode it as a PNG.
        byte[] bytes = texture.EncodeToPNG();

        // Build a full path (this example uses persistent data path)
        string path = Path.Combine(Application.persistentDataPath, "webcamSnapShot");
        
        //Save it in a file.
        // Write to disk
        File.WriteAllBytes(path, bytes);
    }
}