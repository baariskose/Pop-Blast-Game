using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperColor : MonoBehaviour
{
    Board board;
    AudioSource audioSource;
   public AudioClip superPopSound;
    public GameObject popAnim;
    public bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();
        audioSource = GameObject.Find("ScreenController").GetComponent<AudioSource>();
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UseSuperPower()
    {

        List<GameObject> tempList = new List<GameObject>();
        for (int i = 0; i < board.allBlocks.Count; i++)
        {
            if (board.allBlocks[i] != null )
            {
                if (board.allBlocks[i].gameObject.GetComponent<Block>().colorType == gameObject.GetComponent<Block>().colorType)
                {
                    if (gameObject.GetComponent<Block>().colorType == Block.ColorType.GREEN)
                        GameManager.greenCount++;
                    else if (gameObject.GetComponent<Block>().colorType == Block.ColorType.BLUE)
                        GameManager.blueCount++;
                    else if (gameObject.GetComponent<Block>().colorType == Block.ColorType.RED)
                        GameManager.redCount++;
                    else if (gameObject.GetComponent<Block>().colorType == Block.ColorType.YELLOW)
                        GameManager.yellowCount++;

                    if (GameManager.greenCount >= OnClick.greenCountLimit)
                        QuestController.isGreenQuestCompleted = true;
                    if (GameManager.blueCount >= OnClick.blueCountLimit)
                        QuestController.isBlueQuestCompleted = true;
                    if (GameManager.yellowCount >= OnClick.yellowCountLimit)
                        QuestController.isYellowQuestCompleted = true;
                    if (GameManager.redCount >= OnClick.redCountLimit)
                        QuestController.isRedQuestCompleted = true;
                        GameManager.totalScore += 15;
                    //GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);
                    GameObject go2 = Instantiate(popAnim, board.allBlocks[i].transform.position, Quaternion.identity);
                    Destroy(board.allBlocks[i].gameObject,0.8f);
                    Destroy(go2, 2.167f);
                }
            }
        }
        GameObject go = Instantiate(popAnim, gameObject.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(superPopSound);
        Destroy(gameObject, 0.8f);
        Destroy(go, 1);
    }
    private void OnMouseDown()
    {

        if(isClicked == false)
        {
            UseSuperPower();
            isClicked = true;
        }

    }
}
