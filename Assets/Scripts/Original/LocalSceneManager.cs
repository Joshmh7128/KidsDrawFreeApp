using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocalSceneManager : MonoBehaviour
{
    /// this script lets us go from the main menu to any of our different scenes. it loads scenes singularly, not additively
    /// Buttons are assigned functions from the editor

    // Open New Scene
    public void CustomLoadScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }

    // Opens URL
    public void OpenURL(string targetURL)
    {
        Application.OpenURL(targetURL);
    }
}
