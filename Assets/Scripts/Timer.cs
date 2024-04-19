using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text myText;
    public float gameTime = 120;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        StartCoroutine(timerGoing());
    }

    IEnumerator timerGoing()
    {
        yield return new WaitForSeconds(1);
        gameTime -= 1;
        StartCoroutine(timerGoing());
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = Convert.ToInt32(gameTime).ToString();
    }
}
