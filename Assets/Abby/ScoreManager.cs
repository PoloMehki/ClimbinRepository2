using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreManager : MonoBehaviour
{

    public GameObject scoreText;

    public int score = 0;

    // Start is called before the first frame updates
    void Start()
    {
        scoreText.GetComponent<scoreText>().text = score.ToString(); 
    }

    // adds points for each letter guessed correctly 
    public void addPoints()
    {
	    score += 1000;
        scoreText.text = "SCORE: " + score.ToString();
    }

    // subtracts points for each letter guessed incorrectly
    public void subtractPoints()
    {
        score -= 250;
        scoreText.text = "SCORE: " + score.ToString();
    }

    // adds points for each word guessed correctly 
    public void correctWord()
    {
        score += 10000;
        scoreText.text = "SCORE: " + score.ToString();
    }
    /* 
    public override string ToString()
    {
        return score;
    }
    */
}
