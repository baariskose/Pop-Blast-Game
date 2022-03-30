using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Menu : MonoBehaviour
{
    public Button musicButton;
    public Sprite[] musicSprite;
    int flag;
    private AudioListener listener;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        listener = Camera.main.gameObject.GetComponent<AudioListener>();
        audioSource = GameObject.Find("MenuManager").GetComponent<AudioSource>();
            
        if (PlayerPrefs.GetInt("flag") % 2 == 0)
        {
            musicButton.image.sprite = musicSprite[0]; //OPEN
            audioSource.volume = 1;

        }
        else
        {
            musicButton.image.sprite = musicSprite[1]; //Close
            audioSource.volume = 0;
        }

    }

    void Update()
    {
        if (PlayerPrefs.GetInt("flag") % 2 == 0)
        {
            musicButton.image.sprite = musicSprite[0]; //OPEN
            audioSource.volume = 1;

        }
        else
        {
            musicButton.image.sprite = musicSprite[1]; //Close
            audioSource.volume = 0;
        }
    }

    public void ChangeMusicSettings()
    {
        flag++;
        PlayerPrefs.SetInt("flag", flag);
        if (PlayerPrefs.GetInt("flag") % 2 == 0)
        {
            musicButton.image.sprite = musicSprite[0]; //OPEN
            audioSource.volume = 1;

        }
        else
        {
            musicButton.image.sprite = musicSprite[1];
            audioSource.volume = 0;

        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void clickOnMoreGames(string url)
    {
        Application.OpenURL(url);
    }

    public void clickOnRateUs(string url)
    {
        Application.OpenURL(url);
    }
}
