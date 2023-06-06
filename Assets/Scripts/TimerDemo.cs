using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;
=======
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
>>>>>>> Stashed changes

public class TimerDemo : MonoBehaviour
{
    [SerializeField] Timer timer; //create timer
    public int timerDuration; //duration of Level 3
<<<<<<< Updated upstream



    public void Start() {
        startTimer(timerDuration);
        
        //toEndScene.MoveToScene(2);
        //endScene.MoveToScene(2);

=======
    

    public void Start() {
        startTimer(timerDuration);
>>>>>>> Stashed changes
    }

    public void startTimer(int duration){
        timer
        .SetDuration (duration)
        .OnBegin(() => Debug.Log ("Timer started")) //when timer starts then output debug message
        .OnChange((remainingSeconds) => Debug.Log ("Timer changed : " + remainingSeconds)) //takes in an int
        .OnEnd(() => Debug.Log ("Timer ended"))
<<<<<<< Updated upstream
=======
        //.OnPause(paused => Debug.Log("-------Paused : " + isPaused))
>>>>>>> Stashed changes
        .Begin ();
    }

    // Update is called once per frame
    private void Update() {
<<<<<<< Updated upstream
        if(timer.remainingDuration == 0){
            SceneManager.LoadScene(2);
        }

        //uiText.text
=======
        
>>>>>>> Stashed changes
    }

}
