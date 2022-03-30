using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    public GameObject[] shapes;
    int Id=0;
    // Start is called before the first frame update
   

    
    void Initialize()
    {
        int shapeToUse = Random.Range(0, shapes.Length);
        GameObject shape = Instantiate(shapes[shapeToUse], transform.position, Quaternion.identity);
        shape.name = this.gameObject.name;
        
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.name = this.gameObject.name;
    }
   
}

