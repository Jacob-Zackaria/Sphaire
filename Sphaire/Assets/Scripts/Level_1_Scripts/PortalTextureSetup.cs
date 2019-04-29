using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraB;
    public Camera cameraA;
    public Material cameramatB;
    public Material cameramatA;

    private RenderTexture _renderTexture;
    void Start()
    {
        if(cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        _renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraA.targetTexture = _renderTexture;
        cameramatA.mainTexture = cameraA.targetTexture;
        

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        _renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraB.targetTexture = _renderTexture;
        cameramatB.mainTexture = cameraB.targetTexture;
        
    }

}
