using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreManager : MonoBehaviour
{

    public GameObject scoreText;

    private int score = 0;

    // Start is called before the first frame updates
    string Start()
    {
        scoreText.GetComponent<scoreText>().text = score.ToString(); 
        return scoreText;
    }

    // adds 1000 points for each letter guessed correctly 
    public string addPoints()
    {
	    score += 1000;
        scoreText.GetComponent<scoreText>().text = "SCORE: " + score.ToString();
        return scoreText;
    }

    // subtracts 250 points for each letter guessed incorrectly
    public string subtractPoints()
    {
        score -= 250;
        scoreText.GetComponent<scoreText>().text = "SCORE: " + score.ToString();
        return scoreText;
    }

    // adds 10000 points for each word guessed correctly 
    public string correctWord()
    {
        score += 10000;
        scoreText.GetComponent<scoreText>().text = "SCORE: " + score.ToString();
        return scoreText;
    }

    public Form()
    {
        InitializeComponent();
    }

}
