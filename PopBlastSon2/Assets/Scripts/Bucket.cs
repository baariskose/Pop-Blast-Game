using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bucket : MonoBehaviour
{
    int ballCount, moreScore;
    [SerializeField]
    [Range(5, 20)]
    public int countLimit;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        GiveQuest();
        GameManager.targetBallCount = countLimit;
        ballCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCount >= countLimit)
        {
            QuestController.isBallQuestCompleted = true;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            ballCount++;
            if (ballCount >= countLimit)
            {
                GameManager.totalScore +=10;

            }
            GameManager.audioSource.PlayOneShot(GameManager.instance.candyFallSound);
        }
    }

    public void GiveQuest()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2 && SceneManager.GetActiveScene().buildIndex <= 6)
        {
            scene = SceneManager.GetActiveScene();
            countLimit = SceneManager.GetActiveScene().buildIndex * 3+2;
        }
        else if (SceneManager.GetActiveScene().buildIndex > 6 && SceneManager.GetActiveScene().buildIndex <= 11)
        {
            countLimit = 14;
        }
        else if (SceneManager.GetActiveScene().buildIndex > 11 && SceneManager.GetActiveScene().buildIndex <= 30)
        {
            countLimit = 16;
        }







    }
}
