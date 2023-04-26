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

    //LETTER VARS
    bool ban, ana, can, dan, ear, fat, gat, hin, ing, jin, kin, lin, mde, nop, oer, por, qur, ret, ste, tub, unb, ver, wea, xas, yus, zus;


    private void ResetKeyboard(){
        //ban, ana, can, dan, ear, fat, gat, hin, ing, jin, kin, lin, mde, nop, oer, por, qur, ret, ste, tub, unb, ver, wea, xas, yus, zus
        ban = false;
        ana = false;
        can = false;
        dan = false;
        ear = false;
        fat = false;
        gat = false;
        hin = false;
        ing = false;
        jin = false;
        kin = false;
        lin = false;
        mde = false;
        nop = false;
        oer = false;
        por = false;
        qur = false;
        ret = false;
        ste = false;
        tub = false;
        unb = false;
        ver = false;
        wea = false;
        xas = false;
        yus = false;
        zus = false;

    }

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
        ResetKeyboard();
        
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
        return line.Substring(0, line.Length-1);
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
            }
        }
        if(letterInWord == false){ //If the letter is not found in the word
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
    void Update(){
        //List: ban, ana, can, dan, ear, fat, gat, hin, ing, jin, kin, lin, mde, nop, oer, por, qur, ret, ste, tub, unb, ver, wea, xas, yus, zus
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("A was pressed");
            if(ana == false){
            CheckLetter("A");
            Debug.Log("BANANALOCK");
            ana = true;}
        }

        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("B was pressed");
            if(ban == false){
            CheckLetter("B");
            Debug.Log("BANANALOCK");
            ban = true;}
        }

        if(Input.GetKeyDown(KeyCode.C)){
            Debug.Log("C was pressed");
            if(can == false){
            CheckLetter("C");
            Debug.Log("BANANALOCK");
            can = true;}
        }

        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("D was pressed");
            if(dan == false){
            CheckLetter("D");
            Debug.Log("BANANALOCK");
            dan = true;}
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("E was pressed");
            if(ear == false){
            CheckLetter("E");
            Debug.Log("BANANALOCK");
            ear = true;}
        }

        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("F was pressed");
            if(fat == false){
            CheckLetter("F");
            Debug.Log("BANANALOCK");
            fat = true;}
        }

        if(Input.GetKeyDown(KeyCode.G)){
            Debug.Log("G was pressed");
            if(gat == false){
            CheckLetter("G");
            Debug.Log("BANANALOCK");
            gat = true;}
        }

        if(Input.GetKeyDown(KeyCode.H)){
            Debug.Log("H was pressed");
            if(hin == false){
            CheckLetter("H");
            Debug.Log("BANANALOCK");
            hin = true;}
        }

        if(Input.GetKeyDown(KeyCode.I)){
            Debug.Log("I was pressed");
            if(ing == false){
            CheckLetter("I");
            Debug.Log("BANANALOCK");
            ing = true;}
        }
        if(Input.GetKeyDown(KeyCode.J)){
            Debug.Log("J was pressed");
            if(jin == false){
            CheckLetter("J");
            Debug.Log("BANANALOCK");
            jin = true;}
        }
        if(Input.GetKeyDown(KeyCode.K)){
            Debug.Log("K was pressed");
            if(kin == false){
            CheckLetter("K");
            Debug.Log("BANANALOCK");
            kin = true;}
        }
        if(Input.GetKeyDown(KeyCode.L)){
            Debug.Log("L was pressed");
            if(lin == false){
            CheckLetter("L");
            Debug.Log("BANANALOCK");
            lin = true;}
        }
        if(Input.GetKeyDown(KeyCode.M)){
            Debug.Log("M was pressed");
            if(mde == false){
            CheckLetter("M");
            Debug.Log("BANANALOCK");
            mde = true;}
        }

        if(Input.GetKeyDown(KeyCode.N)){
            Debug.Log("N was pressed");
            if(nop == false){
            CheckLetter("N");
            Debug.Log("BANANALOCK");
            nop = true;}
        }

        if(Input.GetKeyDown(KeyCode.O)){
            Debug.Log("O was pressed");
            if(oer == false){
            CheckLetter("O");
            Debug.Log("BANANALOCK");
            oer = true;}
        }

        if(Input.GetKeyDown(KeyCode.P)){
            Debug.Log("P was pressed");
            if(por == false){
            CheckLetter("P");
            Debug.Log("BANANALOCK");
            por = true;}
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("Q was pressed");
            if(qur == false){
            CheckLetter("Q");
            Debug.Log("BANANALOCK");
            qur = true;}
        }

        if(Input.GetKeyDown(KeyCode.R)){
            Debug.Log("R was pressed");
            if(ret == false){
            CheckLetter("R");
            Debug.Log("BANANALOCK");
            ret = true;}
        }

        if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log("S was pressed");
            if(ste == false){
            CheckLetter("S");
            Debug.Log("BANANALOCK");
            ste = true;}
        }

        if(Input.GetKeyDown(KeyCode.T)){
            Debug.Log("T was pressed");
            if(tub == false){
            CheckLetter("T");
            Debug.Log("BANANALOCK");
            tub = true;}
        }

        if(Input.GetKeyDown(KeyCode.U)){
            Debug.Log("U was pressed");
            if(unb == false){
            CheckLetter("U");
            Debug.Log("BANANALOCK");
            unb = true;}
        }

        if(Input.GetKeyDown(KeyCode.V)){
            Debug.Log("V was pressed");
            if(ver == false){
            CheckLetter("V");
            Debug.Log("BANANALOCK");
            ver = true;}
        }

        if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("W was pressed");
            if(wea == false){
            CheckLetter("W");
            Debug.Log("BANANALOCK");
            wea = true;}
        }

        if(Input.GetKeyDown(KeyCode.X)){
            Debug.Log("X was pressed");
            if(xas == false){
            CheckLetter("X");
            Debug.Log("BANANALOCK");
            xas = true;}
        }

        if(Input.GetKeyDown(KeyCode.Y)){
            Debug.Log("Y was pressed");
            if(yus == false){
            CheckLetter("Y");
            Debug.Log("BANANALOCK");
            yus = true;}
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            Debug.Log("Z was pressed");
            if(zus == false){
            CheckLetter("Z");
            Debug.Log("BANANALOCK");
            zus = true;}
        }
    }
}
