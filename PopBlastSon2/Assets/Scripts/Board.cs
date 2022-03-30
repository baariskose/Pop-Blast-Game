using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject[] shapes;
    GameObject choosenShape;
    public List<GameObject> allBlocks;
    public List<GameObject> isKinematicBlocks;
    public int blockCount;
    // Start is called before the first frame update
    void Start()
    {
        allBlocks = new List<GameObject>();
        SetUp();
        blockCount = allBlocks.Count;

    }


    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                CreateShape(i, j);
                GameObject shapeClone = Instantiate(choosenShape, tempPosition, Quaternion.identity);
                shapeClone.transform.parent = this.transform;
                shapeClone.name = "(" + i + "," + j + ")";
                allBlocks.Add(shapeClone);
                if (j <= 13)
                {
                    isKinematicBlocks.Add(shapeClone);
                    shapeClone.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
        }
        Invoke("ChangeRigidbody", 18);
    }
    public void CreateShape(int i, int j)
    {
        choosenShape = shapes[Random.Range(0, shapes.Length - 5)];
    }
    public void ChangeRigidbody()
    {
        foreach (var item in isKinematicBlocks)
        {
            if (item != null)
                item.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }


}
