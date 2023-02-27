using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class script : MonoBehaviour
{
    [SerializeField] GameObject wordbox;
    [SerializeField] GameObject keyboardDisplay;
    [SerializeField] GameObject letterContainer;
    [SerializeField] GameObject[] climbinStages;
    [SerializeField] GameObject letterButton;
    [SerializeField] TextAsset possibleWord;

    private string word;

    private int incorrect;
    private int correct;
    // Start is called before the first frame update
    void Start()
    {
        InitializeButtons();
        InitializeGame();
    }
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

    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(letterButton, keyboardDisplay.transform);
        //Converts int to char with ascii
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        temp.GetComponent<Button>().onClick.AddListener(delegate { CheckLetter(((char)i).ToString()); });
    }

    private string generateWord(){
        string[] wordList = possibleWord.text.Split('\n');
        string line = wordList[Random.Range(0, wordList.Length -1)];
        return line.Substring(0, line.Length -1);
    }

    private void CheckLetter(string inputLetter) {
        bool letterInWord = false;
        for(int i = 0; i < word.Length; i++){
            if(inputLetter == word[i].ToString()){
                letterInWord = true;
                correct++;
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
            }
        }
        if(letterInWord == false){
            incorrect++;
            climbinStages[incorrect -1].SetActive(true);
        }
        checkOutCome();
    }
    private void checkOutCome(){
        //win
        if(correct == word.Length){
            for(int i = 0; i < word.Length; i++){
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.green;
            }
            Invoke("InitializeGame", 3f);
        }
        //lose
        if(incorrect == climbinStages.Length) {
            for(int i = 0; i < word.Length; i++){
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;
                wordbox.GetComponentsInChildren<TextMeshProUGUI>()[i].text = word[i].ToString();
            }
            Invoke("InitializeGame", 3f);
        }
    }
}
