using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//ALL CODE IS IN C#
public class script : MonoBehaviour
{
    //Variables used for assets in unity
    [SerializeField] GameObject wordbox; //the box that contains the word you guess (with letters)
    [SerializeField] GameObject keyboardDisplay; //Displays the keyboard used to play the game
    [SerializeField] GameObject letterContainer; //the actuall boxes that contain the letters for the keyboard 
    [SerializeField] GameObject[] climbinStages; //the different stages, eg; each wrong guess advances the stage until you reach 5, this will result in a loss
    [SerializeField] GameObject letterButton; //The button pressed to select a letter
    [SerializeField] TextAsset possibleWord; //the word the player is attempting to guess

    private string word; //variable to represent the word

    private int incorrect; //Counts the incorrect guesses
    private int correct; //counts the correct guesses
    // Start is called before the first frame update
    void Start()
    {
        InitializeButtons();
        InitializeGame();
    }
    //This will create the displays for the the keyboard
    private void InitializeButtons()
    {
        //Ascii Alphabet
        for(int i = 65; i <= 90; i++){
            //creates a keyboard in alpha. order
            CreateButton(i);
        }
    }

    private void InitializeGame() {
        //reset data
        incorrect = 0;
        correct = 0;
        foreach(Button child in keyboardDisplay.GetComponentsInChildren<Button>()){
            child.interactable = true;
        }
        foreach(Transform child in wordbox.GetComponentInChildren<Transform>()) {
            Destroy(child.gameObject);
        }
        foreach(GameObject stage in climbinStages){
            stage.SetActive(false);
        }

        //game generating
        word = generateWord().ToUpper();
        foreach(char letter in word){
            var temp = Instantiate(letterContainer, wordbox.transform);
        }
    }

    //Makes a button with the input i reperesnting an ascii character
    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(letterButton, keyboardDisplay.transform);
        //Converts int to char with ascii
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        temp.GetComponent<Button>().onClick.AddListener(delegate { CheckLetter(((char)i).ToString()); });
    }
    //Selects a word from the possible word bank (a txt file with 5 letter words)
    private string generateWord(){
        string[] wordList = possibleWord.text.Split('\n');
        string line = wordList[Random.Range(0, wordList.Length -1)];
        return line.Substring(0, line.Length -1);
    }
    
    //When a letter is pressed, this will check whether that letter is found in the word the player is attempting to guess
    private void CheckLetter(string inputLetter) {
        bool letterInWord = false;
        //This will iterate through the possible word
        for(int i = 0; i < word.Length; i++){
            
            if(inputLetter == word[i].ToString()){ //If the letter is found in the word
                letterInWord = true;
                correct++;
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
                ScoreManager.addPoints();
            }
        }
        if(letterInWord == false){ //If the letter is not found in the word
            ScoreManager.subtractPoints();
            incorrect++;
            //changes the stage to move the character down one tile
            climbinStages[incorrect -1].SetActive(true);
        }
        //This will check if the word has been fully guessed
        checkOutCome();
    }
    
    //Determines if the game is failed or if the word has been guessed
    private void checkOutCome(){
        //win
        if(correct == word.Length){
            //Makes the guessed word green
            ScoreManager.correctWord();
            for(int i = 0; i < word.Length; i++){
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.green;
            }
            //code to reset the game and start a new one
            Invoke("InitializeGame", 3f);
        }
        //lose
        if(incorrect == climbinStages.Length) {
            //Makes the correct word red and autofills it
            for(int i = 0; i < word.Length; i++){
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].text = word[i].ToString();
            }
            //restarts the game
            Invoke("InitializeGame", 3f);
        }
    }
}
