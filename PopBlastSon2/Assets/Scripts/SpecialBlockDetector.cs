using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockDetector : MonoBehaviour
{
    public GameObject connectedObject;

    public Direction direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("block") && collision.gameObject.name.Contains("super") == false && collision.gameObject.GetComponent<Block>() != null)
        {
            connectedObject = collision.gameObject;
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == connectedObject)
        {
            connectedObject = null;
        }
    }

    public enum Direction
    {
        RIGHT,
        LEFT,
        UP,
        DOWN,
    }
    private void FixedUpdate()
    {
        if (connectedObject == null)
        {
            if(direction == Direction.RIGHT)
            {
                if (gameObject.GetComponent<BoxCollider2D>().offset.x < 3.6f)
                    gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(gameObject.GetComponent<BoxCollider2D>().offset.x + Time.deltaTime, gameObject.GetComponent<BoxCollider2D>().offset.y);
            }
            else if (direction == Direction.LEFT)
            {
                if (gameObject.GetComponent<BoxCollider2D>().offset.x > -3.6f)
                    gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(gameObject.GetComponent<BoxCollider2D>().offset.x - Time.deltaTime, gameObject.GetComponent<BoxCollider2D>().offset.y);
            }
          
           
        }
        
    }
}
