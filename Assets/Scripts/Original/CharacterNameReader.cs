using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNameReader : MonoBehaviour
{
    // our character name manager
    [SerializeField] CharacterNameManager characterNameManager; // our character name manager in the scene
    [SerializeField] string ourName; // our name
    [SerializeField] Text nameText; // displaying text

    private void Start()
    {
        // get our name manager
        characterNameManager = GameObject.Find("CharacterNameManager").GetComponent<CharacterNameManager>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // get our name
        ourName = characterNameManager.playerName;
        // display out name
        nameText.text = ourName;
    }
}
