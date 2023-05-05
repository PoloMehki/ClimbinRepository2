using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDemo : MonoBehaviour
{
    [SerializeField] Timer timer1; //create timer
    [SerializeField] int l1Duration; //duration of Level 1
    [SerializeField] int l2Duration; //duration of Level 2
    [SerializeField] int l3Duration; //duration of Level 3
    // Start is called before the first frame update
    private void Start()
    {
        timer1
        .SetDuration (l1Duration)
        .OnBegin(() => Debug.Log ("Timer started")) 
        .OnChange((remainingSeconds) => Debug.Log ("Timer changed : " + remainingSeconds)) //takes in an int
        .OnEnd(() => Debug.Log ("Timer ended")) 
        .Begin ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
