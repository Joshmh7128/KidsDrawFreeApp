using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopicTracker : MonoBehaviour
{
    // what are our color and noun strings?
    public string selectedColor;
    public string selectedNoun;
    // what is our category?
    public string selectedCategory;
    // where is our final output text?
    public Text finalOutputText;

    // Start is called before the first frame update
    void Start()
    {
        // make sure we keep this alive throughout the whole game
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "RandomScene")
        {
            // get our texts
            selectedColor = GameObject.Find("Color Text").GetComponent<Text>().text;
            selectedNoun = GameObject.Find("Noun Text").GetComponent<Text>().text;
        }

        if (currentScene == "DrawScene")
        {
            // search for our final output text
            finalOutputText = GameObject.Find("Final Output Text").GetComponent<Text>();
            finalOutputText.text = "Draw a " + selectedColor + " " + selectedNoun + "!";
        }
    }
}
