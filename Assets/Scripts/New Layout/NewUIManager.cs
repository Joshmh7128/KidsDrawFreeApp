using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUIManager : MonoBehaviour
{
    /// 
    /// this script will...
    /// manage and work with all buttons
    /// hold all functions related to buttons
    /// track which character is selected
    /// track the active scene
    /// navigate through scenes
    /// run the generator and manage it's new animators
    /// 

    // variables
    // buttons
    // partner screen buttons
    [SerializeField] Button nextButton;         // move to next scene
    [SerializeField] Button blueFaceButton;     // choose associated partner
    [SerializeField] Button yellowFaceButton;   // choose associated partner
    [SerializeField] Button greenFaceButton;    // choose associated partner
    [SerializeField] Button orangeFaceButton;   // choose associated partner
    // tracking
    public Sprite currentPartner; // what is our active partner? change this game object whenever we change partners
    [SerializeField] Sprite bluePartner;    // partner Sprite
    [SerializeField] Sprite greenPartner;   // partner Sprite
    [SerializeField] Sprite yellowPartner;  // partner Sprite
    [SerializeField] Sprite orangePartner;  // partner Sprite

    // start runs when the object is activated
    private void Start()
    {
        // make sure we make this object persist throughout all of our scenes for tracking purposes
        DontDestroyOnLoad(gameObject);
    }

    // character selection function
    public void CharacterSelection(int characterChoice)
    {
        // int characterChoice determines which character we've selected
        switch (characterChoice)
        {
            // throw 0 if there is no selection
            case 0:
                currentPartner = null; // set to null
                break;
            case 1:
                currentPartner = bluePartner;
                break;
            case 2:
                currentPartner = greenPartner;
                break;
            case 3:
                currentPartner = yellowPartner;
                break;
            case 4:
                currentPartner = orangePartner;
                break;
        }
        // display change is done inside the display objects
    }


}
