using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static int blueCount;
    public static int greenCount;
    public static int yellowCount;
    public static int redCount;
    public static int currentBallCount;
    public static int targetBallCount;
    public static int moveCountLimit;
    public static int currentMoveCount;
    public static float time;
    public static bool isAllRequestCompleted;
    public static float maxTime;
    public static int totalScore;

    public static bool isPaused = false;
    public static bool isGameover = false;
    public static bool isGameover2 = false;
    public static bool isWin = false;
    public static int targetScore;
    public Text targetBallText, ballTexts, moveText, timeText, totalScoreText, targetScoreText, targetBlueCountText, targetGreenCountText, targetRedCountText, targetYellowCountText, currentBlueCountText, currentRedCountText, currentYellowCountText, currentGreenCountText;
    public Button pauseButton , musicButton;
    public Sprite[] pauseSprites , musicSprites;
    Scene scene;
    public Image star;
    public Sprite[] starsImages;
    public GameObject gameOverPanel, winPanel, pausePanel,deneme;
    int flag;
    int musicFlag;
    public bool isGameoverSoundPlayed, isWinSoundPlayed;
    AdmobInters intersAd;
    private AudioListener listener;
    public static AudioSource audioSource, audioSource2;
    public AudioClip popSound, winSound, loseSound, backGroundSound, bestComboSound, middleComboSound, lowComboSound, instantiateSound, candyFallSound, pofAnimationSound;
    public static GameManager instance;
    
    int index;
    bool isAdShowed;


    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 70;
    }
    void Start()
    {

        GameObject go = Instantiate(deneme, transform.position, Quaternion.identity);
        go.GetComponent<TextMeshPro>().text = totalScore.ToString();
        Destroy(go, 1);

        listener = Camera.main.gameObject.GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource2 = GameObject.Find("ScreenController").GetComponent<AudioSource>();
        isGameoverSoundPlayed = false;
        isWinSoundPlayed = false;
        blueCount = 0;
        greenCount = 0;
        yellowCount = 0;
        redCount = 0;
        intersAd = GameObject.Find("Scripts").GetComponent<AdmobInters>();
        maxTime = 65;
        currentBallCount = 25;
        moveCountLimit = 40;
        currentMoveCount = moveCountLimit;
        time = maxTime;
        scene = SceneManager.GetActiveScene();
        totalScore = 0;
        winPanel.SetActive(false);
        Time.timeScale = 1;
        isWin = false;
        isGameover = false;
        isAllRequestCompleted = false;
        gameOverPanel.SetActive(false);
        audioSource.PlayOneShot(backGroundSound);
        isAdShowed = false;

    }

    // Update is called once per frame
    void Update()
    {
        targetBallText.text = targetBallCount.ToString();
        ballTexts.text = currentBallCount.ToString();
        moveText.text = currentMoveCount.ToString();
        if (targetBlueCountText != null)
            targetBlueCountText.text = OnClick.blueCountLimit.ToString();
        if (targetGreenCountText != null)
            targetGreenCountText.text = OnClick.greenCountLimit.ToString();
        if (targetRedCountText != null)
            targetRedCountText.text = OnClick.redCountLimit.ToString();
        if (targetYellowCountText != null)
            targetYellowCountText.text = OnClick.yellowCountLimit.ToString();
        if (targetScoreText != null)
            targetScoreText.text = targetScore.ToString();
        if (currentBlueCountText != null)
            currentBlueCountText.text = blueCount.ToString();
        if (currentGreenCountText != null)
            currentGreenCountText.text = greenCount.ToString();
        if (currentYellowCountText != null)
            currentYellowCountText.text = yellowCount.ToString();
        if (currentRedCountText != null)
            currentRedCountText.text = redCount.ToString();
        time -= Time.deltaTime;
        timeText.text = time.ToString("0.");
        totalScoreText.text = totalScore.ToString();

        if (isGameover == true)
        {
            gameOverPanel.SetActive(true);
            if (!isGameoverSoundPlayed)
            {
                audioSource.Stop();
                audioSource2.PlayOneShot(loseSound);

                isGameoverSoundPlayed = true;
            }
            if (intersAd.interstitial.IsLoaded() && isAdShowed == false)
            {
                intersAd.interstitial.Show();
                isAdShowed = true;
            }
            Time.timeScale = 0;
            isGameover = false;
        }
        if (PlayerPrefs.GetInt("flag") % 2 != 0 || Time.timeScale == 0)
        {
            listener.enabled = false;

        }
        else
        {
            listener.enabled = true;

        }
        if (isGameover2 == true && Killer.isDestroyAll == true)
        {
            gameOverPanel.SetActive(true);
            if (!isGameoverSoundPlayed)
            {
                audioSource.Stop();
                audioSource2.PlayOneShot(loseSound);
                isGameoverSoundPlayed = true;
            }
            if (intersAd.interstitial.IsLoaded() && isAdShowed == false)
            {
                intersAd.interstitial.Show();
                isAdShowed = true;
            }
            Time.timeScale = 0;
            isGameover2 = false;
        }
        if (isWin && Killer.isDestroyAll == true)
        {
            winPanel.SetActive(true);
            if (!isWinSoundPlayed)
            {
                audioSource.Stop();
                audioSource2.PlayOneShot(winSound);
                isWinSoundPlayed = true;
            }
            Time.timeScale = 0;
            GiveStarScore();
            isWin = false;
        }

        if (currentBallCount < targetBallCount)
        {
            isGameover = true;
        }
        if (time <= 0 && SceneManager.GetActiveScene().buildIndex > 16 && SceneManager.GetActiveScene().buildIndex < 30)
        {
            QuestController.isTimeRequestCompleted = false;
            isGameover = true;
            time = 0;
        }
        if (totalScore > targetScore)
        {
            QuestController.isScoreQuestCompleted = true;
        }
        if (currentMoveCount <= 0 && SceneManager.GetActiveScene().buildIndex > 16)
        {
            isGameover = true;
            currentMoveCount = 1;
        }

       
    }
    public void Pause()
    {
        flag++;
        if (flag % 2 == 0)
        {
            Time.timeScale = 1;
            pauseButton.image.sprite = pauseSprites[0];
            pausePanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseButton.image.sprite = pauseSprites[1];
            pausePanel.SetActive(true);
            isPaused = true;
        }
    }
    public void Restart()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, totalScore);
        //else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        //    gameCenterLeaderBoard.ReportScore(totalScore, leaderboard_id);
        //}
        isGameover = false;
        isWin = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoLevelSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("nextLevel", nextLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
      
            PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, totalScore);

        
        //else if(Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        //    gameCenterLeaderBoard.ReportScore(totalScore, leaderboard_id);
        //}
    }
    public void GiveStarScore()
    {
        if (totalScore > 0 && totalScore <= 2000)
        {
            star.sprite = starsImages[0];
        }
        else if (totalScore > 2000 && totalScore <= 3000)
        {
            star.sprite = starsImages[1];
        }
        else if (totalScore > 3000)
        {
            star.sprite = starsImages[2];
        }

    }
    public void TurnOffOnMusic()
    {
        musicFlag++;
        if (musicFlag % 2 == 0)
        {
            audioSource.volume = 0.259f;
            audioSource2.volume = 1;
            musicButton.image.sprite = musicSprites[0];
        }
        else
        {
            audioSource.volume = 0;
            audioSource2.volume = 0;
            musicButton.image.sprite = musicSprites[1];
        }


    }
    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }


}
