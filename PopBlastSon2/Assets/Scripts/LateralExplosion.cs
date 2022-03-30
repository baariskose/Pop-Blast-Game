using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralExplosion : MonoBehaviour
{
    Board board;
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("block"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (collision.gameObject.transform.GetChild(6).gameObject.tag == "frontItem")
                collision.gameObject.transform.GetChild(6).GetComponent<SpriteRenderer>().enabled = false;

           
            Destroy(collision.gameObject, 1f);
        }
    }
}
