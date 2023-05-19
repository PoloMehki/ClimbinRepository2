using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDemo : MonoBehaviour
{
    [SerializeField] Timer timer; //create timer
    public int timerDuration; //duration of Level 3
    

    public void Start() {
        startTimer(timerDuration);
    }

    public void startTimer(int duration){
        timer
        .SetDuration (duration)
        .OnBegin(() => Debug.Log ("Timer started")) //when timer starts then output debug message
        .OnChange((remainingSeconds) => Debug.Log ("Timer changed : " + remainingSeconds)) //takes in an int
        .OnEnd(() => Debug.Log ("Timer ended"))
        //.OnPause(paused => Debug.Log("-------Paused : " + isPaused))
        .Begin ();
    }

    // Update is called once per frame
    private void Update() {
        
    }

}
