using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReader : MonoBehaviour
{
    [SerializeField] CharacterNameManager characterNameManager; // our character name manager in the scene
    [SerializeField] GameObject ourCharacter;
    [SerializeField] SpriteRenderer ourRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // get our own sprite renderer
        ourRenderer = gameObject.GetComponent<SpriteRenderer>();
        // get our character manager
        characterNameManager = GameObject.Find("CharacterNameManager").GetComponent<CharacterNameManager>();
        // get our prefab object
        ourCharacter = characterNameManager.characterSelection;
        // set our sprite renderer based on the character
        ourRenderer.sprite = ourCharacter.GetComponent<SpriteRenderer>().sprite;
        ourRenderer.color = ourCharacter.GetComponent<SpriteRenderer>().color;
    }

    private void FixedUpdate()
    {
        // get our prefab object
        ourCharacter = characterNameManager.characterSelection;
        // set our sprite renderer based on the character
        ourRenderer.sprite = ourCharacter.GetComponent<SpriteRenderer>().sprite;
        ourRenderer.color = ourCharacter.GetComponent<SpriteRenderer>().color;
    }
}
