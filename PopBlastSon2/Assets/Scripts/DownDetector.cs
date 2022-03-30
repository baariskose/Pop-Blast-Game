using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownDetector : MonoBehaviour
{
    public bool isEmpty;


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("block"))
        {
            isEmpty = false;
        }
        else
        {
            isEmpty = true;
        }
    }
}
