using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public static ScoreManager instance;

	public Text scoreText;

	int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score.toString();

	int score = 0; 
    }

    public void addPoint()
    {
	score += 1;
	scoreText.text = "SCORE: " + score.ToString();   
    }
}
