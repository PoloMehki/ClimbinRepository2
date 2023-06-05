using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public void moveUp(){
        transform.position += Vector3.up *100f;
    }
    public void moveDown(){
        transform.position += Vector3.down *50f;
    }
}
