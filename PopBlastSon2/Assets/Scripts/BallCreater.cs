using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreater : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        //-0.52  4.48
        for (int i = 0; i < 25; i++)
        {
            GameObject ballClone = Instantiate(ball, new Vector2(Random.Range(-0.52f, 4.48f), 25.06f), Quaternion.identity);
        }
    }

}
