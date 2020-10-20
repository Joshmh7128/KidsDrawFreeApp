using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicManager : MonoBehaviour
{
    /// This script exists to manage topics, generate topics,
    /// manage buttons and UI for the generator, and serve
    /// as our main source of random selection for topics. 
    /// In the future, it will also choose a daily topic

    // topics
    [SerializeField] string[] CategoriesList = { "Nature", "Animals", "Vehicles", "Food", "Activities" };
    [SerializeField] string[] ColorsList = { "Red", "Orange", "Yellow", "Green", "Blue", "Purple" };
    [SerializeField] string[] NatureNouns = { "PlaceHolderTopic1", "PlaceHolderTopic2", "PlaceHolderTopic3", "PlaceHolderTopic4", "PlaceHolderTopic5" };
    [SerializeField] string[] AnimalsNouns = { "PlaceHolderTopic1", "PlaceHolderTopic2", "PlaceHolderTopic3", "PlaceHolderTopic4", "PlaceHolderTopic5" };
    [SerializeField] string[] VehiclesNouns = { "PlaceHolderTopic1", "PlaceHolderTopic2", "PlaceHolderTopic3", "PlaceHolderTopic4", "PlaceHolderTopic5" };
    [SerializeField] string[] FoodNouns = { "PlaceHolderTopic1", "PlaceHolderTopic2", "PlaceHolderTopic3", "PlaceHolderTopic4", "PlaceHolderTopic5" };
    [SerializeField] string[] ActivitiesNouns = { "PlaceHolderTopic1", "PlaceHolderTopic2", "PlaceHolderTopic3", "PlaceHolderTopic4", "PlaceHolderTopic5" };

    // buttons
    [SerializeField] Button CategoryButton;
    [SerializeField] Button ColorAndNounButton;

    // output text   
    [SerializeField] Text[] CategoryText; // categories on the wheel
    [SerializeField] Text[] ColorText; // colors on the wheel
    [SerializeField] Text[] NounText; // nouns on the wheel
    [SerializeField] Text CategoryChoice; // which color did the wheel land on?
    [SerializeField] Text ColorChoice; // which color did the wheel land on?
    [SerializeField] Text NounChoice; // which noun did the wheel land on?

    // spinner animators
    [SerializeField] Animator spinWheelCat;
    [SerializeField] Animator spinWheelColor;
    [SerializeField] Animator spinWheelNoun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // random category
    public void ChooseCategory()
    {
        // choose them on the wheel
        foreach (Text text in CategoryText)
        {
            text.text = CategoriesList[Random.Range(0,CategoriesList.Length)];
        }

        // choose our category
        CategoryChoice.text = CategoryText[0].text;
        spinWheelCat.Play("Spinwheel Spin");
        spinWheelColor.Play("Spinwheel Spin");
        spinWheelNoun.Play("Spinwheel Spin");
    }

    // random color
    public void ChooseColor()
    {
        // choose wheel options
        foreach (Text text in ColorText)
        {
            text.text = ColorsList[Random.Range(0, ColorsList.Length)];
        }

        // choose our color
        ColorChoice.text = ColorText[0].text;
    }

    // random noun
    public void ChooseNoun()
    {
        // set our category
        string category;
        category = CategoryChoice.text;

        if (category == "Nature")
        {   // choose our wheel options
            foreach (Text text in NounText)
            { text.text = NatureNouns[Random.Range(0,NatureNouns.Length)]; }
            NounChoice.text = NounText[0].text;
        }

        if (category == "Animals")
        {   // choose our wheel options
            foreach (Text text in NounText)
            { text.text = AnimalsNouns[Random.Range(0, AnimalsNouns.Length)]; }
            NounChoice.text = NounText[0].text;
        }

        if (category == "Vehicles")
        {   // choose our wheel options
            foreach (Text text in NounText)
            { text.text = VehiclesNouns[Random.Range(0, VehiclesNouns.Length)]; }
            NounChoice.text = NounText[0].text;
        }

        if (category == "Food")
        {   // choose our wheel options
            foreach (Text text in NounText)
            { text.text = FoodNouns[Random.Range(0, FoodNouns.Length)]; }
            NounChoice.text = NounText[0].text;
        }

        if (category == "Activities")
        {   // choose our wheel options
            foreach (Text text in NounText)
            { text.text = ActivitiesNouns[Random.Range(0, ActivitiesNouns.Length)]; }
            NounChoice.text = NounText[0].text;
        }

    }
}
