using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class Shape : MonoBehaviour
{

    int x;
    int y;
    string shapeName, yeni;
    public string shapeTag;
    bool isFirstClick = true;
    List<GameObject> patlayacaklar;
    List<GameObject> etraftakiler;
    // Start is called before the first frame update
    void Start()
    {
        patlayacaklar = new List<GameObject>();
        etraftakiler = new List<GameObject>();
        shapeTag = "a";
    }
  

    private void OnMouseDown()
    {
        //shapeName = gameObject.name;
        //yeni = shapeName.Replace("("," ");
        //yeni = yeni.Replace(")", " ");
        //yeni = yeni.Trim();
        //var s = yeni.Split(',');
        //x = int.Parse(s[0]);   
        //y = int.Parse(s[1]);  
        //Debug.Log(x);
        //Debug.Log(y);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        shapeTag = gameObject.tag;
        if (shapeTag == collision.gameObject.tag)
        {
           // Debug.Log(collision.gameObject.name);
            foreach (GameObject item in etraftakiler)
            {
                if (!String.Equals(item.name, collision.gameObject.name))
                {
                    etraftakiler.Add(collision.gameObject);
                 //   Debug.Log(collision.gameObject.name);
                }
            }
        }
    }

    public void FindSameColor(Collision2D collision)
    {
    }
    
}



