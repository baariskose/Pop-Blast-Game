using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counterText;
    public double time;
    public static double time2;
    public GameObject loadingPanel;
    void Start()
    {
        time = 5;
        time2 = 5;
        loadingPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        time2 -= Time.deltaTime;
        
        counterText.text = time.ToString("0.");
        if(time <= 0)
        {
            loadingPanel.SetActive(false);
        }
    }
}
