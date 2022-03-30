using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    Collision collision;
    private void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        
    }

    public void ActiveCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }






}
