using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialColor : MonoBehaviour
{
    Board board;
    ParticleSystem particle;
    public GameObject lateralAnimation;
    AudioSource audioSource;
    public AudioClip pofAnimationSound;
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
    private void OnMouseDown()
    {
        
        //gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
        // Destroy(gameObject, 0.1f);
        Block block = GetComponent<Block>();
        List<GameObject> rightconnectedObjects = GetAllRightConnected(block, new List<GameObject>());
        List<GameObject> leftconnectedObjects = GetAllLeftConnected(block, new List<GameObject>());
        var rightItems = rightconnectedObjects;
        var unique_rightItems = new HashSet<GameObject>(rightItems);

        var leftItems = leftconnectedObjects;
        var unique_leftItems = new HashSet<GameObject>(leftItems);
        if (GameManager.isPaused == false && isClicked == false)
        {
            if (GameManager.isGameover == false)
            {
                GameObject go = Instantiate(lateralAnimation, new Vector2(2.31f, gameObject.transform.position.y), Quaternion.identity);
                Destroy(go, 0.750f);
                audioSource.PlayOneShot(pofAnimationSound);

                foreach (var item in unique_rightItems)
                {
                    GameManager.totalScore += 15;
                    SaveColorPoint(item);
                    item.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(item, 0.8f);
                }
                foreach (var item in unique_leftItems)
                {
                    GameManager.totalScore += 15;
                    SaveColorPoint(item);
                    item.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(item, 0.8f);
                }

                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
             
                Destroy(gameObject,0.8f);
                GameManager.currentMoveCount--;
                GameManager.totalScore += 15;
                GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);
                gameObject.transform.GetChild(6).GetComponent<SpriteRenderer>().enabled = false;
                isClicked = true;
            }
        }
    }
    public void SaveColorPoint(GameObject go)
    {
        switch (go.GetComponent<Block>().colorType)
        {
            case Block.ColorType.BLUE:
                GameManager.blueCount++;
                if (GameManager.blueCount >= OnClick.blueCountLimit)
                    QuestController.isBlueQuestCompleted = true;
                break;
            case Block.ColorType.YELLOW:
                GameManager.yellowCount++;
                if (GameManager.yellowCount >= OnClick.yellowCountLimit)
                    QuestController.isYellowQuestCompleted = true;
                break;
            case Block.ColorType.GREEN:
                GameManager.greenCount++;
                if (GameManager.greenCount >= OnClick.greenCountLimit)
                    QuestController.isGreenQuestCompleted = true;
                break;
            case Block.ColorType.RED:
                GameManager.redCount++;
                if (GameManager.redCount >= OnClick.redCountLimit)
                    QuestController.isRedQuestCompleted = true;
                break;
            default:
                break;
        }
    }
    private List<GameObject> GetAllRightConnected(Block block, List<GameObject> oldList)
    {
        List<GameObject> connectedBlocks = block.GetRightConnectedObjects();

        for (int i = 0; i < oldList.Count; i++)
        {
            removeIfNedeed(oldList[i], connectedBlocks);
        }
        if (!oldList.Contains(block.gameObject))
        {
            oldList.Add(block.gameObject);

            foreach (var item in connectedBlocks)
            {
                List<GameObject> found = GetAllRightConnected(item.GetComponent<Block>(), oldList);
                found.Remove(item);
                found.Remove(block.gameObject);
                oldList.AddRange(found);
                oldList.Add(item);
            }
        }
        return oldList;
    }
    private List<GameObject> GetAllLeftConnected(Block block, List<GameObject> oldList)
    {
        List<GameObject> connectedBlocks = block.GetLeftConnectedObjects();

        for (int i = 0; i < oldList.Count; i++)
        {
            removeIfNedeed(oldList[i], connectedBlocks);
        }
        if (!oldList.Contains(block.gameObject))
        {
            oldList.Add(block.gameObject);

            foreach (var item in connectedBlocks)
            {
                List<GameObject> found = GetAllLeftConnected(item.GetComponent<Block>(), oldList);
                found.Remove(item);
                found.Remove(block.gameObject);
                oldList.AddRange(found);
                oldList.Add(item);
            }
        }
        return oldList;
    }

    private void removeIfNedeed(GameObject go, List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (go.GetInstanceID() == list[i].GetInstanceID())
            {
                list.RemoveAt(i);
            }
        }
    }




}
