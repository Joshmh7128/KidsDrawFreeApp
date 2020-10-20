using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNameManager : MonoBehaviour
{
    public string playerName; // this is the player's name
    public GameObject[] characterOptions; // the list of characters that the player can choose
    public GameObject characterSelection; // our selected object to be displayed
    public InputField nameInputField; // the player's name input

    private void Start()
    {
        // make sure we don't destroy on load because we will need this information throughout the game
        DontDestroyOnLoad(gameObject);
    }

    public void CharacterSelect(int selection)
    {
        // set our character selection to whichever we choose
        characterSelection = characterOptions[selection];
    }

    public void SetName()
    {
        // set our name
        playerName = nameInputField.text;
    }
}
