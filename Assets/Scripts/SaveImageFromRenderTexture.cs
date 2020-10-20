using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class SaveImageFromRenderTexture : MonoBehaviour
{
    public RenderTexture rt;
    /*
    public void SaveTexture()
    {
        byte[] bytes = rt.EncodeToPNG();
        System.IO.File.WriteAllBytes("C:/Users/egsha/SavedScreen.png", bytes);
    }*/
}
