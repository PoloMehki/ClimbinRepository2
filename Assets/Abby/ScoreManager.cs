using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreManager : MonoBehaviour
{

    private string scoreText;

    public int score = 0;

    // Start is called before the first frame updates
    void Start()
    {
        scoreText = score.ToString(); 
    }

    // adds points for each letter guessed correctly 
    public static string addPoints()
    {
	    score += 1000;
        return "SCORE: " + score.ToString();
    }

    // subtracts points for each letter guessed incorrectly
    public static string subtractPoints()
    {
        score -= 250;
        return "SCORE: " + score.ToString();
    }

    // adds points for each word guessed correctly 
    public static string correctWord()
    {
        score += 10000;
        return "SCORE: " + score.ToString();
    }

    public override string ToString()
    {
        return score;
    }

}
