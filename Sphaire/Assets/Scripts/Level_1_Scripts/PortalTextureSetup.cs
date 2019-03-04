using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraB;
    public Camera cameraA;
    public Material cameramatB;
    public Material cameramatA;
    void Start()
    {
        if(cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraA.targetTexture.MarkRestoreExpected();
        cameramatA.mainTexture = cameraA.targetTexture;

        if(cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraB.targetTexture.MarkRestoreExpected();
        cameramatB.mainTexture = cameraB.targetTexture;
    }

}
