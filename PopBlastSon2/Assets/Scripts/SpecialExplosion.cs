
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.CompareTag("block"))
        //{
        //    if(collision.gameObject.GetComponent<Block>().colorType == Block.ColorType.BLUE)
        //    {
        //        GameManager.blueCount++;
        //        GameManager.totalScore += 15;
        //        GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);
        //    }
        //    else if (collision.gameObject.GetComponent<Block>().colorType == Block.ColorType.YELLOW)
        //    {
        //        GameManager.yellowCount++;
        //        GameManager.totalScore += 15;
        //        GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);
        //    }
        //    else if (collision.gameObject.GetComponent<Block>().colorType == Block.ColorType.RED)
        //    {
        //        GameManager.redCount++;
        //        GameManager.totalScore += 15;
        //        GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);
        //    }
        //    else if (collision.gameObject.GetComponent<Block>().colorType == Block.ColorType.GREEN)
        //    {
        //        GameManager.greenCount++;
        //        GameManager.totalScore += 15;
        //        GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);
        //    }
        //    Destroy(collision.gameObject);
        //}
    }

   
}
