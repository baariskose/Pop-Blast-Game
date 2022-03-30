using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class OnClick : MonoBehaviour
{
    public ParticleSystem particle;
    Board board;
    public static int blueCountLimit, greenCountLimit, yellowCountLimit, redCountLimit;
    public GameObject bubbleAnim, popAnim;
    public bool isClicked;
    public int totalScore2;
    public GameObject floatText;
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();
        //particle = gameObject.transform.GetChild(4).GetComponent<ParticleSystem>();
        blueCountLimit = SceneManager.GetActiveScene().buildIndex / 2 + 20;
        greenCountLimit = SceneManager.GetActiveScene().buildIndex / 2 + 15;
        yellowCountLimit = SceneManager.GetActiveScene().buildIndex / 2 + 15;
        redCountLimit = SceneManager.GetActiveScene().buildIndex / 2 + 20;
        isClicked = false;
    }


    private void OnMouseDown()
    {
        //List<GameObject> connectedObjects = new List<GameObject>();
        Block block = GetComponent<Block>();
        // connectedObjects.AddRange(block.GetConnectedObjects());
        List<GameObject> connectedObjects = GetAllConnected(block, new List<GameObject>());
        List<GameObject> connectedObjects2 = block.GetConnectedObjects();
        var items = connectedObjects;
        var unique_items = new HashSet<GameObject>(items);
        int counter = 0;
        if (GameManager.isPaused == false && isClicked == false)
        {
            if (GameManager.isGameover == false)
            {
                if (connectedObjects2.Count > 0)
                {
                    foreach (var item in unique_items)
                    {
                        GameObject go2 = Instantiate(bubbleAnim, item.transform.position, Quaternion.identity);
                        GameObject go3 = Instantiate(popAnim, item.transform.position, Quaternion.identity);
                        GameManager.totalScore += 15;
                        totalScore2 += 15;
                        SaveColorPoint(item);
                        //particle.Play();
                        item.GetComponent<OnClick>().isClicked = true;
                        StartCoroutine(SpriteRendererEnabled(item));
                        Destroy(item, 0.4f);
                        counter++;
                        Destroy(go2, 0.6f);
                        Destroy(go3, 0.5f);
                    }
                    totalScore2 += 15;
                    GameObject floatTextC = Instantiate(floatText, transform.position, Quaternion.identity);
                    floatTextC.GetComponent<TextMeshPro>().text = totalScore2.ToString();
                    CreateColor(gameObject, floatTextC);
                    Destroy(floatTextC, 1);
                    totalScore2 = 0;
                    GameObject pop = Instantiate(popAnim, gameObject.transform.position, Quaternion.identity);
                    GameObject bubble = Instantiate(bubbleAnim, gameObject.transform.position, Quaternion.identity);
                    Destroy(bubble, 0.6f);
                    Destroy(pop, 0.5f);
                    SaveColorPoint(gameObject);
                    //particle.Play();
                    StartCoroutine(SpriteRendererEnabled(gameObject));
                    isClicked = true;

                    Destroy(gameObject, 0.4f);
                    GameManager.currentMoveCount--;
                    GameManager.totalScore += 15;
                    GameManager.audioSource.PlayOneShot(GameManager.instance.popSound);


                    if (counter > 8 && gameObject.GetComponent<Block>().colorType == Block.ColorType.GREEN)
                    {
                        
                        GameObject superColor = Instantiate(board.shapes[4], transform.position, Quaternion.identity);
                        GameManager.audioSource.PlayOneShot(GameManager.instance.bestComboSound);
                    }
                    else if (counter > 8 && gameObject.GetComponent<Block>().colorType == Block.ColorType.BLUE)
                    {
                        GameObject superColor = Instantiate(board.shapes[5], transform.position, Quaternion.identity);
                        GameManager.audioSource.PlayOneShot(GameManager.instance.bestComboSound);
                    }
                    else if (counter > 8 && gameObject.GetComponent<Block>().colorType == Block.ColorType.YELLOW)
                    {
                        GameObject superColor = Instantiate(board.shapes[6], transform.position, Quaternion.identity);
                        GameManager.audioSource.PlayOneShot(GameManager.instance.bestComboSound);
                    }
                    else if (counter > 8 && gameObject.GetComponent<Block>().colorType == Block.ColorType.RED)
                    {
                        GameObject superColor = Instantiate(board.shapes[7], transform.position, Quaternion.identity);
                        GameManager.audioSource.PlayOneShot(GameManager.instance.bestComboSound);
                    }

                    if (counter >= 5 && counter <= 8)
                    {
                        GameObject superColor = Instantiate(board.shapes[8], transform.position, Quaternion.identity);
                        GameManager.audioSource.PlayOneShot(GameManager.instance.lowComboSound);
                    }
                    if (counter >= 4 && counter < 6)
                    {
                        GameManager.audioSource.PlayOneShot(GameManager.instance.middleComboSound);
                    }
                }

            }

        }

    }


    public void SaveColorPoint(GameObject go)
    {
        switch (go.GetComponent<Block>().colorType)
        {
            case Block.ColorType.BLUE:
                GameManager.blueCount++;

                if (GameManager.blueCount >= blueCountLimit)
                    QuestController.isBlueQuestCompleted = true;
                break;
            case Block.ColorType.YELLOW:
                GameManager.yellowCount++;
                if (GameManager.yellowCount >= yellowCountLimit)
                    QuestController.isYellowQuestCompleted = true;
                break;
            case Block.ColorType.GREEN:
                GameManager.greenCount++;
                if (GameManager.greenCount >= greenCountLimit)
                    QuestController.isGreenQuestCompleted = true;
                break;
            case Block.ColorType.RED:
                GameManager.redCount++;
                if (GameManager.redCount >= redCountLimit)
                    QuestController.isRedQuestCompleted = true;
                break;
            default:
                break;
        }
    }
    public void CreateColor(GameObject go,GameObject floatClone)
    {
        if(go.GetComponent<Block>().colorType == Block.ColorType.YELLOW)
        {
            floatClone.GetComponent<TextMeshPro>().color = Color.yellow;
            
        }
        else if (go.GetComponent<Block>().colorType == Block.ColorType.BLUE)
        {
            floatClone.GetComponent<TextMeshPro>().color = Color.blue;

        }
        else if (go.GetComponent<Block>().colorType == Block.ColorType.RED)
        {
            floatClone.GetComponent<TextMeshPro>().color = Color.magenta;

        }
        else if (go.GetComponent<Block>().colorType == Block.ColorType.GREEN)
        {
            floatClone.GetComponent<TextMeshPro>().color = Color.green;

        }
    }

    public static List<GameObject> connected = new List<GameObject>();

    public static bool addIfNeeded(GameObject go)
    {
        if (connected.Contains(go))
        {
            return false;
        }
        else
            connected.Add(go);
        return true;
    }



    private List<GameObject> GetAllConnected(Block block, List<GameObject> oldList)
    {
        List<GameObject> connectedBlocks = block.GetConnectedObjects();

        for (int i = 0; i < oldList.Count; i++)
        {
            removeIfNedeed(oldList[i], connectedBlocks);
        }
        if (!oldList.Contains(block.gameObject))
        {
            oldList.Add(block.gameObject);

            foreach (var item in connectedBlocks)
            {
                List<GameObject> found = GetAllConnected(item.GetComponent<Block>(), oldList);
                found.Remove(item);
                found.Remove(block.gameObject);
                oldList.AddRange(found);
                oldList.Add(item);
                var items = oldList;
                var unique_items = new HashSet<GameObject>(items);
                oldList = unique_items.ToList();
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
    public IEnumerator SpriteRendererEnabled(GameObject go)
    {
        yield return new WaitForSeconds(0.1f);
        go.GetComponent<SpriteRenderer>().enabled = false;
    }



}
