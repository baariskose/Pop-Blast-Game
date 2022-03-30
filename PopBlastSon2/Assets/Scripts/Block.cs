using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    public ColorType colorType;




    public enum ColorType
    {
        BLUE,
        YELLOW,
        GREEN,
        RED,
        NoColor,
    }

    public List<GameObject> GetConnectedObjects()
    {
        List<GameObject> connectedObjects = new List<GameObject>();
        BlockDetector[] detectors = GetComponentsInChildren<BlockDetector>();

        for (int i = 0; i < detectors.Length; i++)
        {
            if (detectors[i].connectedObject)
            {
                if (isEqual(detectors[i].connectedObject) && detectors[i].connectedObject.gameObject.name.Contains("super") == false)
                {
                    connectedObjects.Add(detectors[i].connectedObject);
                }
            }
        }
        return connectedObjects;
    }
    public List<GameObject> GetRightConnectedObjects()
    {
        List<GameObject> connectedObjects = new List<GameObject>();
        BlockDetector[] detectors = GetComponentsInChildren<BlockDetector>();
        SpecialBlockDetector[] detectors2 = GetComponentsInChildren<SpecialBlockDetector>();
        for (int i = 0; i < detectors.Length; i++)
        {
            if (detectors[i].connectedObject && detectors[i].direction == BlockDetector.Direction.RIGHT)
            {
                if (detectors[i].connectedObject.gameObject.name.Contains("super") == false)
                {
                    connectedObjects.Add(detectors[i].connectedObject);
                }
            }
           
        }
        return connectedObjects;
    }
    public List<GameObject> GetLeftConnectedObjects()
    {
        List<GameObject> connectedObjects = new List<GameObject>();
        BlockDetector[] detectors = GetComponentsInChildren<BlockDetector>();
        SpecialBlockDetector[] detectors2 = GetComponentsInChildren<SpecialBlockDetector>();

        for (int i = 0; i < detectors2.Length; i++)
        {
            if (detectors[i].connectedObject && detectors[i].direction == BlockDetector.Direction.LEFT)
            {
                if (detectors[i].connectedObject.gameObject.name.Contains("super") == false)
                {
                    connectedObjects.Add(detectors[i].connectedObject);
                }
            }
        }
        return connectedObjects;
    }

    public bool isEqual(GameObject go)
    {
        return go.GetComponent<Block>().colorType == this.colorType;
    }

}
