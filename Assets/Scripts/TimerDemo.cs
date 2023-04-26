using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDemo : MonoBehaviour
{
    [SerializeField] Timer timer1;
    // Start is called before the first frame update
    private void Start()
    {
        timer1.SetDuration (7).Begin ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
