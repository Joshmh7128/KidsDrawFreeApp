using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    /// this script is designed to help buttons and the input field rediscover the 
    /// CharacterNameManager script so that they can modify the player character model and name
    /// as well as anything else we want to change

    // our character name manager
    [SerializeField] CharacterNameManager characterNameManager;
    // are we in button mode or input mode?
    [SerializeField] bool isButtonMode;
    [SerializeField] int characterSelectionInt;
    // our button 
    [SerializeField] Button ourButton;
    // our input field
    [SerializeField] InputField ourInputField;

    // Start is called before the first frame update
    void Start()
    {
        // find our characterNameManager
        characterNameManager = GameObject.Find("CharacterNameManager").GetComponent<CharacterNameManager>();

        // check what mode we are in and set our variables accordingly, then run appropriate functions
        if (isButtonMode == true)
        {
            ourButton = gameObject.GetComponent<Button>();
            ButtonSetup();
        }
        else if (isButtonMode == false)
        {
            ourButton = gameObject.GetComponent<Button>();
            ourInputField = gameObject.GetComponent<InputField>();
            InputFieldSetup();
        }
    }
    
    // button setup function
    void ButtonSetup()
    {
        ourButton.onClick.AddListener(() => characterNameManager.CharacterSelect(characterSelectionInt));
        Debug.Log("Button " + characterSelectionInt + " setup");
    }

    // inputfield setup function
    void InputFieldSetup()
    {
        ourButton.onClick.AddListener(() => characterNameManager.SetName());
        Debug.Log("Input Field Submit button setup");
    }
}
