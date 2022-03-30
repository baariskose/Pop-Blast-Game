using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
   
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate( new Vector3(0,0,100*Time.deltaTime));
    }
}
