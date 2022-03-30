using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    GameObject killerUp;
    GameObject screenController;
    GameObject bg;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        killerUp = GameObject.Find("killerUp");
        screenController = GameObject.Find("ScreenController");
        rb = screenController.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (killerUp.gameObject.transform.position.y <= 13f)
        {
            gameObject.transform.parent = screenController.gameObject.transform;
            if (screenController.gameObject.transform.position.y > -8.0)
                rb.velocity = new Vector2(0, -1f);
            else
            {
                rb.velocity = new Vector2(0,0);

            }
        }
    }
}
