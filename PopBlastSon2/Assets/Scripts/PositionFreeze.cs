using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFreeze : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("block"))
        {
            collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
}
