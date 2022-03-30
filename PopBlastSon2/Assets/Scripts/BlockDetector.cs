using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetector : MonoBehaviour
{

    public GameObject connectedObject;

    public Direction direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("block") && collision.gameObject.name.Contains("super") == false && collision.gameObject.GetComponent<Block>() != null)
        {
            connectedObject = collision.gameObject;
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
}
