using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    Button button;

    int level;
    int index;
    public List<GameObject> LevelPages;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> LevelPages = new List<GameObject>();
        button = GetComponent<Button>();
        index = 0;
        kilitSistemi();
    }

  
    public void ChooseLevel()
    {
        level = int.Parse(button.name);
        SceneManager.LoadScene(level);
    }
    public void NextPage()
    {
        
        if(index != LevelPages.Count-1)
        {
            index++;
            LevelPages[index].SetActive(true);
            LevelPages[index - 1].SetActive(false);
        }

    }
    public void PreviousPage()
    {
       
        if(index != 0)
        {
            index--;
            LevelPages[index].SetActive(true);
            LevelPages[index + 1].SetActive(false);

        }

    }
    public void kilitSistemi()
    {
        int levels = PlayerPrefs.GetInt("nextLevel");
        if(levels == 0)
        {
            levels += 2;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            if(levels>= int.Parse(buttons[i].name))
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
                Color color = new Color(255, 255, 255, 255);
               // buttons[i].GetComponentInChildren<Image>().color = color;
                buttons[i].transform.GetChild(1).GetComponent<Image>().color = color;
            }
        }
    }
}
