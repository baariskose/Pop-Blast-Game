using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckController : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("ActiveCollider", 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            GameManager.currentBallCount = balls.Length -1;
            Destroy(collision.gameObject);
        }
    }

    public void ActiveCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
