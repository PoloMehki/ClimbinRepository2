using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer UI Refrences :")]
    [SerializeField] private Image uiFillImage; //the image filling/decreasing
    [SerializeField] private TMP_Text uiText; //timer text (minutes & seconds)

    public int Duration {get; private set;}
    //public bool IsPaused {get; private set;} COMMENTED BECAUSE PAUSE FUNCTION IS IN OWN SCRIPT

    private int remainingDuration; //the current time

    //EVENTS
    private UnityAction onTimerBeginAction ;
    private UnityAction <int> onTimerChangeAction;
    private UnityAction onTimerEndAction ;
    //private UnityAction <bool> onTimerPausedAction ;

    
    private void Awake () {
        ResetTimer ();
    }

    //Restarting Timer at 00:00
    private void ResetTimer (){
        uiText.text = "00:00";
        
        uiFillImage.fillAmount = 0f;

        Duration = remainingDuration = 0;

        onTimerBeginAction = null ; 
        onTimerChangeAction = null ; 
        onTimerEndAction = null ; 

        //IsPaused = false;
    }

    /* COMMENTED BECAUSE PAUSE FUNCTION IS IN OWN SCRIPT
    public void SetPaused(bool paused){
        IsPaused = paused;

        if(onTimerPausedAction != null){
            onTimerPausedAction.Invoke(IsPaused);
        }
    } */
    
    //Sets the timer to a specific time
    public Timer SetDuration(int seconds) {
        Duration = remainingDuration = seconds;
        return this;
    }

    //--Events
    public Timer OnBegin (UnityAction action) {
        onTimerBeginAction = action;
        return this;
    }
    public Timer OnChange (UnityAction<int> action) {
        onTimerChangeAction = action;
        return this;
    }
    public Timer OnEnd (UnityAction action) {
        onTimerEndAction = action;
        return this;
    }
    /* COMMENTED BECAUSE PAUSE FUNCTION IS IN OWN SCRIPT
    public Timer OnPause (UnityAction <bool> action) {
        onTimerPauseAction = action;
        return this;
    }*/


    //Starts the timer
    public void Begin () {
        //begins event
        if (onTimerBeginAction != null){ // calls the timer begin action
            onTimerBeginAction.Invoke();
        }
        
        StopAllCoroutines();
        StartCoroutine(UpdateTimer ());
    }

    //Updates the Timer as it decreases
    private IEnumerator UpdateTimer(){
        while(remainingDuration > 0){
            if(onTimerChangeAction != null){
                onTimerChangeAction.Invoke (remainingDuration);
            }

            UpdateUI (remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds (1f);
        }
        End();
    }

    /* COMMENTED BECAUSE PAUSE FUNCTION IS IN OWN SCRIPT
    //Updates the Timer as it decreases
    private IEnumerator UpdateTimer(){
        while(remainingDuration > 0){
            if(IsPaused){
                if(onTimerChangeAction != null){
                    onTimerChangeAction.Invoke (remainingDuration);
                }

                UpdateUI (remainingDuration);
                remainingDuration--;
            }
            
            yield return new WaitForSeconds (1f);
        }
        End();
    }*/

    //Changes the text and fill image as timer moves doown
    private void UpdateUI(int seconds) {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60); //d2 Means print 2 digits even if the seconds are more than 10
        uiFillImage.fillAmount = Mathf.InverseLerp (0, Duration, seconds);
            //inverselerp returns a value between 0 & 1 depending on the value e.g. btw 0 & 10 value is 5
    }

    public void End () {
        if (onTimerEndAction != null){
            onTimerEndAction.Invoke();
        }

        ResetTimer ();
    }

    private void OnDestroy() {
        StopAllCoroutines ();
    }

}
