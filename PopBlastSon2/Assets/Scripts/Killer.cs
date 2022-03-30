using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    [Range(-3, 0)]
    [SerializeField]
    public static float speed = -1f;
    public static bool isDestroyAll;
    public GameObject gameoverPanel;
    public GameObject popAnimation;
    public AudioClip popSound;
    AudioSource audioSource;
    Board board;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("ScreenController").GetComponent<AudioSource>();
        board = GameObject.Find("Board").GetComponent<Board>();
       
        isDestroyAll = false;
        speed = -0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Counter.time2 <= 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        if (GameManager.time <=35)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1f);
        }
        if (gameObject.transform.position.y <= -1.109016)
        {
            isDestroyAll = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {

            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            GameManager.currentBallCount = balls.Length - 1;
            if (balls == null || balls.Length <= 1)
            {
                GameManager.isGameover = true;
            }
            GameObject go = Instantiate(popAnimation, collision.gameObject.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(popSound);
            Destroy(collision.gameObject);
            Destroy(go, 0.5f);


        }
        else if (collision.gameObject.CompareTag("block"))
        {
            collision.gameObject.transform.GetChild(4).GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
     
            Destroy(collision.gameObject, 0.3f);
        }
        
    }
}
