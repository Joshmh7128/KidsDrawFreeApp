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
    [SerializeField] string[] RandomTopics = { "alligator", "ant", "bear", "bee", "bird", "camel", "cat", "cheetah", "chicken", "chimpanzee", "cow",
        "crocodile", "deer", "dog", "dolphin", "duck", "eagle", "elephant", "fish", "fly", "fox", "frog", "giraffe", "goat", "goldfish", "hamster",
        "hippopotamus", "horse", "kangaroo", "kitten", "lion", "lobster", "monkey", "octopus", "owl", "panda", "pig", "puppy", "rabbit", "rat",
        "scorpion", "seal", "shark", "sheep", "snail", "snake", "spider", "squirrel", "tiger", "turtle", "wolf", "zebra", "Van", "Taxi", "Police car", "Bus",
        "Ambulance", "Skateboard", "Baby carriage", "Bicycle", "Mountain bike", "Scooter", "Motorcycle", "Fire engine", "Crane", "Forklift", "Tractor",
        "Recycling truck", "Cement mixer", "Dump truck", "Subway", "Helicopter", "Airplane", "Balloon", "Train", "Carriage", "Rowboat", "Boat", "Train", };
    // buttons
    [SerializeField] Button RandomButton;
    [SerializeField] Button ComboButton;
    [SerializeField] Button LearningButton;
    // output text
    [SerializeField] Text RandomText;
    [SerializeField] string lastRandText;
    [SerializeField] Text ComboText;
    [SerializeField] Text LearningText;
    [SerializeField] Text DailyTopicText;
    // get the day of the year out of 366
    int iDayOfYear = System.DateTime.UtcNow.DayOfYear;

    // Start is called before the first frame update
    void Start()
    {
        // assign our buttton listeners
        RandomButton.onClick.AddListener(RandomTopicGen);
        ComboButton.onClick.AddListener(ComboTopicGen);
        LearningButton.onClick.AddListener(LearningTopicGen);
        DailyTopicText.text = "Today's Topic is topic " + iDayOfYear;
    }

    // random topic selection
    void RandomTopicGen()
    {
        string i = RandomTopics[Random.Range(0, RandomTopics.Length)];

        if (i == lastRandText)
        {
            i = RandomTopics[Random.Range(0, RandomTopics.Length)];
        }

        lastRandText = i;

        RandomText.text = "Draw a " + i + "!";
    }

    // multiple topic selection
    void ComboTopicGen()
    {
        string i = RandomTopics[Random.Range(0, RandomTopics.Length)];
        string x = RandomTopics[Random.Range(0, RandomTopics.Length)];

        while (x == i)
        {
            x = RandomTopics[Random.Range(0, RandomTopics.Length)];
        }

        if (x != i)
        {
            ComboText.text = "Draw a " + i + " and a " + x + "!";
        }
    }

    // learning topic selection
    void LearningTopicGen()
    {

    }
}
