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
    [SerializeField] private TMP_Text uiText;

    public int Duration {get; private set;} //read only 

    private int remainingDuration; //the current time

    private void Awake () {
        ResetTimer ();
    }

    //Restarting Timer at 00:00
    private void ResetTimer (){
        uiText.text = "00:00";
        
        uiFillImage.fillAmount = 0f;

        Duration = remainingDuration = 0;
    }

    //Sets the timer to a specific time
    public Timer SetDuration(int seconds) {
        Duration = remainingDuration = seconds;
        return this;
    }

    //Starts the timer
    public void Begin () {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer ());
    }

    //Updates the Timer as it decreases
    private IEnumerator UpdateTimer(){
        while(remainingDuration > 0){
            UpdateUI (remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds (1f);
        }
        End();
    }

    //Changes the text and fill image as timer moves doown
    private void UpdateUI(int seconds) {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60); //d2 Means print 2 digits even if the seconds are more than 10
        uiFillImage.fillAmount = Mathf.InverseLerp (0, Duration, seconds);
            //inverselerp returns a value between 0 & 1 depending on the value e.g. btw 0 & 10 value is 5
    }

    public void End () {
        ResetTimer ();
    }

    private void OnDestroy() {
        StopAllCoroutines ();
    }

}
