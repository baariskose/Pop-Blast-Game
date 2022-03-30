using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    // Start is called before the first frame update
    Scene currentScene;
    public Sprite UISquare;
    public Image squareUIUp, squareUIDown,scoreCheck, scoreImage, scoreSlash;
    public Text slash1, slash2 ;
    public Sprite blue, green, yellow, red;
    public static bool isBallQuestCompleted, isTimeRequestCompleted, isScoreQuestCompleted, isBlueQuestCompleted, isRedQuestCompleted, isYellowQuestCompleted, isGreenQuestCompleted, isMoveQuestCompleted, isAllQuestCompleted;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Scripts").GetComponent<GameManager>();
        currentScene = SceneManager.GetActiveScene();
        isBallQuestCompleted = false;
        isTimeRequestCompleted = true;
        isScoreQuestCompleted = false;
        isMoveQuestCompleted = true;
        isAllQuestCompleted = false;
        isGreenQuestCompleted = false;
        isBlueQuestCompleted = false;
        isRedQuestCompleted = false;
        isYellowQuestCompleted = false;
       
        
        if(SceneManager.GetActiveScene().buildIndex > 6 && SceneManager.GetActiveScene().buildIndex <= 30)
        {
            scoreCheck.enabled = false;
            scoreSlash.enabled = true;
        }
        if (SceneManager.GetActiveScene().buildIndex > 21 && SceneManager.GetActiveScene().buildIndex <= 23)
        {
            squareUIUp.sprite = blue;
            squareUIDown.sprite = green;
            gameManager.targetBlueCountText.enabled = true;
            gameManager.currentBlueCountText.enabled = true;
            gameManager.targetGreenCountText.enabled = true;
            gameManager.currentGreenCountText.enabled = true;
            slash1.enabled = true;
            slash2.enabled = true;

            
        }
        else if (SceneManager.GetActiveScene().buildIndex > 23 && SceneManager.GetActiveScene().buildIndex <= 30)
        {
            squareUIUp.sprite = yellow;
            squareUIDown.sprite = red;
            gameManager.targetYellowCountText.enabled = true;
            gameManager.currentYellowCountText.enabled = true;
            gameManager.targetRedCountText.enabled = true;
            gameManager.currentRedCountText.enabled = true;
            slash1.enabled = true;
            slash2.enabled = true;
            

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2 && SceneManager.GetActiveScene().buildIndex <= 6)
        {
            if (isBallQuestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isAllQuestCompleted = true;
            }
            
        }
        else if (SceneManager.GetActiveScene().buildIndex > 6 && SceneManager.GetActiveScene().buildIndex <= 11)
        {
            GameManager.targetScore = SceneManager.GetActiveScene().buildIndex * 260;
            if (isScoreQuestCompleted)
            {
                scoreSlash.enabled = false;
                gameManager.targetScoreText.enabled = false;
                gameManager.totalScoreText.enabled = false;
                scoreImage.enabled = false;
                scoreCheck.enabled = true;
            }
            if (isBallQuestCompleted && isScoreQuestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isScoreQuestCompleted = false;
                isAllQuestCompleted = true;
            }
           
        }
        else if (SceneManager.GetActiveScene().buildIndex > 11 && SceneManager.GetActiveScene().buildIndex <= 16)
        {
            if (isScoreQuestCompleted)
            {
                scoreSlash.enabled = false;
                gameManager.targetScoreText.enabled = false;
                gameManager.totalScoreText.enabled = false;
                scoreImage.enabled = false;
                scoreCheck.enabled = true;
            }
            GameManager.targetScore = SceneManager.GetActiveScene().buildIndex *170;
            if (isBallQuestCompleted && isScoreQuestCompleted && isTimeRequestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isScoreQuestCompleted = false;
                isAllQuestCompleted = true;
            }
          
        }
        else if (SceneManager.GetActiveScene().buildIndex > 11 && SceneManager.GetActiveScene().buildIndex <= 16)
        {

            GameManager.targetScore = SceneManager.GetActiveScene().buildIndex * 181;
            if (isScoreQuestCompleted)
            {
                scoreSlash.enabled = false;
                gameManager.targetScoreText.enabled = false;
                gameManager.totalScoreText.enabled = false;
                scoreImage.enabled = false;
                scoreCheck.enabled = true;
            }
            if (isBallQuestCompleted && isScoreQuestCompleted && isTimeRequestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isScoreQuestCompleted = false;
                isAllQuestCompleted = true;
            }
          
        }
        else if (SceneManager.GetActiveScene().buildIndex > 16 && SceneManager.GetActiveScene().buildIndex <= 21)
        {
            GameManager.targetScore = SceneManager.GetActiveScene().buildIndex * 138;
            if (isScoreQuestCompleted)
            {
                scoreSlash.enabled = false;
                gameManager.targetScoreText.enabled = false;
                gameManager.totalScoreText.enabled = false;
                scoreImage.enabled = false;
                scoreCheck.enabled = true;
            }
            if (isBallQuestCompleted && isScoreQuestCompleted && isTimeRequestCompleted && isMoveQuestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isScoreQuestCompleted = false;
                isMoveQuestCompleted = false;
                isAllQuestCompleted = true;
            }
           
        }
        else if (SceneManager.GetActiveScene().buildIndex > 21 && SceneManager.GetActiveScene().buildIndex <= 23)
        {
            GameManager.targetScore = SceneManager.GetActiveScene().buildIndex * 126;
            if (isScoreQuestCompleted)
            {
                scoreSlash.enabled = false;
                gameManager.targetScoreText.enabled = false;
                gameManager.totalScoreText.enabled = false;
                scoreImage.enabled = false;
                scoreCheck.enabled = true;
            }
            if (isBlueQuestCompleted)
            {
                squareUIUp.sprite = UISquare;
                gameManager.targetBlueCountText.enabled = false;
                gameManager.currentBlueCountText.enabled = false;
                slash1.enabled = false;

            }
            if (isGreenQuestCompleted)
            {
                squareUIDown.sprite = UISquare;
                gameManager.targetGreenCountText.enabled = false;
                gameManager.currentGreenCountText.enabled = false;
                slash2.enabled = false;
            }
            if (isBallQuestCompleted && isScoreQuestCompleted && isTimeRequestCompleted && isMoveQuestCompleted && isBlueQuestCompleted && isGreenQuestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isScoreQuestCompleted = false;
                isMoveQuestCompleted = false;
                isBlueQuestCompleted = false;
                isGreenQuestCompleted = false;
                isAllQuestCompleted = true;
            }
         
        }
        else if (SceneManager.GetActiveScene().buildIndex > 23 && SceneManager.GetActiveScene().buildIndex <= 30)
        {
            GameManager.targetScore = SceneManager.GetActiveScene().buildIndex * 90;
            if (isScoreQuestCompleted)
            {
                scoreSlash.enabled = false;
                gameManager.targetScoreText.enabled = false;
                gameManager.totalScoreText.enabled = false;
                scoreImage.enabled = false;
                scoreCheck.enabled = true;
            }
            if (isRedQuestCompleted)
            {
                squareUIDown.sprite = UISquare;
              
                gameManager.targetRedCountText.enabled = false;
                gameManager.currentRedCountText.enabled = false;
                slash1.enabled = false;
            }
            if (isYellowQuestCompleted)
            {
                squareUIUp.sprite = UISquare;
                gameManager.targetYellowCountText.enabled = false;
                gameManager.currentYellowCountText.enabled = false;
                slash2.enabled = false;
            }
            if (isBallQuestCompleted && isScoreQuestCompleted && isTimeRequestCompleted && isMoveQuestCompleted && isRedQuestCompleted && isYellowQuestCompleted)
            {
                GameManager.isWin = true;
                isBallQuestCompleted = false;
                isScoreQuestCompleted = false;
                isMoveQuestCompleted = false;
                isRedQuestCompleted = false;
                isYellowQuestCompleted = false;
                isAllQuestCompleted = true;
            }
           
        }
        
    }
}
