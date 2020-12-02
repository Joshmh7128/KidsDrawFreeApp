using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] Button blueFaceButton;     // choose associated partner
    [SerializeField] Button yellowFaceButton;   // choose associated partner
    [SerializeField] Button greenFaceButton;    // choose associated partner
    [SerializeField] Button orangeFaceButton;   // choose associated partner
    [SerializeField] Button vehiclesCatButton;  // choose category
    [SerializeField] Button animalsCatButton;   // choose category
    [SerializeField] Button foodsCatButton;     // choose category
    [SerializeField] Button natureCatButton;    // choose category
    [SerializeField] Button sportsCatButton;    // choose category
    // tracking
    public Sprite currentPartner;           // what is our active partner? change this game object whenever we change partners
    [SerializeField] Sprite bluePartner;    // partner Sprite
    [SerializeField] Sprite greenPartner;   // partner Sprite
    [SerializeField] Sprite yellowPartner;  // partner Sprite
    [SerializeField] Sprite orangePartner;  // partner Sprite
    [SerializeField] SpriteRenderer[] CharacterDisplays; // the list of character displays
    [SerializeField] string ourCharacter;
    [SerializeField] string ourCategory;
    // camera positions
    [SerializeField] Transform[] cameraPositions;   // the positions that our camera can move too and from
    [SerializeField] int cameraPos;                 // 0 to max of cameraPositions;
    [SerializeField] Transform cameraTransform;     // the transform of our camera
    // category tracking
    [SerializeField] int categoryChoice; // 0 - null ; 1 - cars ; 2 - animals ; 3 - foods ; 4 - nature ; 5 - sports ;
    [SerializeField] GameObject carsCatIcon; // icons to enable / disable for the generation screen
    [SerializeField] GameObject animalsCatIcon; // icons to enable / disable for the generation screen
    [SerializeField] GameObject foodsCatIcon; // icons to enable / disable for the generation screen
    [SerializeField] GameObject natureCatIcon; // icons to enable / disable for the generation screen
    [SerializeField] GameObject sportsCatIcon; // icons to enable / disable for the generation screen
    // spinner text tracking
    [SerializeField] TextMeshPro[] activeVerbs; // actual active verbs
    [SerializeField] TextMeshPro[] activeNouns; // actual active nouns
    [SerializeField] TextMeshPro popupSentence; // the sentence presented to the user as  "LETS DRAW A VERBING NOUN TOGETHER!"
    [SerializeField] readonly string[] verbs = { "DANCING", "JUMPING", "RUNNING", "FLYING", "SPINNING", "RELAXING", "EATING", "LAUGHING", "SINGING", "PAINTING", "CELEBRATING"};
    [SerializeField] readonly string[] vehicles = { "TRUCK", "CAR", "RACECAR", "BULLDOZER", "DUMPTRUCK", "CRANE", "CHERRYPICKER", "TRAIN", "PLANE", "BOAT", "HELICOPTER"};
    [SerializeField] readonly string[] animals = { "DOG", "CAT", "MOUSE", "MONKEY", "FROG", "LIZARD", "LION", "TIGER", "BEAR", "SNAKE", "BIRD"};
    [SerializeField] readonly string[] foods = { "CARROT", "APPLE", "TOMATO", "SOUP", "CRACKER", "POTATO", "BURGER", "PIZZA", "PASTA", "STRAWBERRY", "LEMON"};
    [SerializeField] readonly string[] nature = { "TREE", "ROCK", "CLOUD", "BUSH", "FLOWER", "SNOWFLAKE", "CACTUS", "RIVER", "LAKE", "WATERFALL", "VOLCANO"};
    [SerializeField] readonly string[] sports = { "SOCCER BALL", "BASEBALL BAT", "HOCKEY PUCK", "BASEBALL", "BASKETBALL", "HELMET", "SHOE", "TENNIS RACKET", "TENNIS BALL", "BOWLING BALL", "ROPE"};
    // animations and animators
    [SerializeField] Animator verbWheel;
    [SerializeField] Animator nounWheel;
    [SerializeField] Animator popupAnimator;

    // start runs when the object is activated
    private void Start()
    {
        // make sure we make this object persist throughout all of our scenes for tracking purposes
        DontDestroyOnLoad(gameObject);
        // assign verbs first, then reassign when animations replay
        VerbAssign();
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
                ourCharacter = "sky";
                break;
            case 2:
                currentPartner = greenPartner;
                ourCharacter = "jade";
                break;
            case 3:
                currentPartner = yellowPartner;
                ourCharacter = "rose";
                break;
            case 4:
                currentPartner = orangePartner;
                ourCharacter = "clay";
                break;
        }
        // display change
        UpdatedCharacterDisplays();
    }

    // list of sprite displays
    public void UpdatedCharacterDisplays()
    {
        int i = 0;
        foreach (SpriteRenderer display in CharacterDisplays)
        {
            CharacterDisplays[i].sprite = currentPartner;
            i += 1;
        }
    }

    // move the camera left or right, 1 is right, -1 is left
    public void CameraNavigation(int changeAmount)
    {
        // make sure we can't go below 0, or above the positions
        if ((cameraPos >= 0) && (cameraPos < cameraPositions.Length))
        {   // change our position by the desired amount
            cameraPos += changeAmount;
            // move our camera
            cameraTransform.position = cameraPositions[cameraPos].position;
        }
    }

    // category selection // 0 - null ; 1 - cars ; 2 - animals ; 3 - foods ; 4 - nature ; 5 - sports ;
    public void CategorySelection(int localCategoryChoice)
    {
        // to avoid nothing showing up, default state is set to cars. null is implemented for testing purposes.
        // set our category choice
        categoryChoice = localCategoryChoice;
        // start by disabling all our icons
        carsCatIcon.SetActive(false);
        animalsCatIcon.SetActive(false);
        foodsCatIcon.SetActive(false);
        natureCatIcon.SetActive(false);
        sportsCatIcon.SetActive(false);
        // 0 - null ; 1 - cars ; 2 - animals ; 3 - foods ; 4 - nature ; 5 - sports ;
        switch (localCategoryChoice)
        {
            case 0: // do nothing cus it's null
                break;
            case 1:
                carsCatIcon.SetActive(true);
                ourCategory = "vehicles";
                break;
            case 2:
                animalsCatIcon.SetActive(true);
                ourCategory = "animals";
                break;
            case 3:
                foodsCatIcon.SetActive(true);
                ourCategory = "foods";
                break;
            case 4:
                natureCatIcon.SetActive(true);
                ourCategory = "nature";
                break;
            case 5:
                sportsCatIcon.SetActive(true);
                ourCategory = "sports";
                break;
        }

        // after selection is made, assign nouns, also change verbs for fun
        NounAssign();
        VerbAssign();
    }

    // spinning and text assignment
    public void VerbAssign()
    {
        foreach (TextMeshPro verbTMP in activeVerbs)
        {   // for each of our verbs in the list, change the verb to one of our verbs above
            verbTMP.text = verbs[Random.Range(0, verbs.Length)];
        }
    }
    public void NounAssign()
    {
        // categories: 0 - null ; 1 - vehicles ; 2 - animals ; 3 - foods ; 4 - nature ; 5 - sports ;
        foreach (TextMeshPro nounTMP in activeNouns)
        {   // for each of our noun TMP objects in the list, change the noun to one of
            switch (categoryChoice)
            {
                case 1: // vehicle
                nounTMP.text = vehicles[Random.Range(0, vehicles.Length)]; // add one more to the randomizer, because maximum is exclusive for ints
                    break;
                case 2: // animals
                nounTMP.text = animals[Random.Range(0, animals.Length)]; // add one more to the randomizer, because maximum is exclusive for ints
                    break;
                case 3: // foods
                nounTMP.text = foods[Random.Range(0, foods.Length)]; // add one more to the randomizer, because maximum is exclusive for ints
                    break;
                case 4: // nature
                nounTMP.text = nature[Random.Range(0, nature.Length)]; // add one more to the randomizer, because maximum is exclusive for ints
                    break;
                case 5: // sports
                nounTMP.text = sports[Random.Range(0, sports.Length)]; // add one more to the randomizer, because maximum is exclusive for ints
                    break;
            }
        }
    }

    // spin the wheels
    public void SpinVerb()
    {
        // set default state
        
        // play anim
        verbWheel.Play("New Vertical Spinner");
    }

    public void SpinNoun()
    {
        // play anim
        nounWheel.Play("New Noun Vert Spinner");
    }

    // when user is satisfied with their selection present the popup
    public void PopUpTrigger(bool MoveIn /*is the popup moving in or out?*/)
    {
        // change the popup text to the proper sentence
        popupSentence.text = "LETS DRAW A " + activeVerbs[activeVerbs.Length - 1].text + " " + activeNouns[activeNouns.Length - 1].text;
        // animated based on state
        if (MoveIn == true)
        {
            // move the popup in
            popupAnimator.Play("Popup Move In");
        }

        if (MoveIn == false)
        {
            // move the popup out
            popupAnimator.Play("Popup Move Out");
        }
    }

    public void OpenWebPage()
    {
        // format our verbs and nouns
        string noun = activeNouns[activeNouns.Length - 1].text;
        string verb = activeVerbs[activeVerbs.Length - 1].text;
        // no spaces
        noun = noun.Replace(" ", "-");
        verb = verb.Replace(" ", "-");
        // no capitals
        noun = noun.ToLower();
        verb = verb.ToLower();
        // get the final string together for the printable page
        string finalString = "http://kidsdrawfree.com/print/"+"?kid="+ourCharacter+"&noun="+ noun + "&verb="+ verb + "&category="+ourCategory+"&game=drawing-game";
        Application.OpenURL(finalString);
    }
}
