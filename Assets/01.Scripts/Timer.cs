using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float limitTime = 180.0f;
    public Slider timeSlider;
    public Text timeText;
    float second = 0.0f;
    int timeMinute = 0, timeSecond = 0;

    private void Start()
    {
        StartCoroutine("CountTime", 1.0f);
    }

    void Update()
    {
        timeCalculation(limitTime);
    }
    
    void timeCalculation(float limitTime)
    {
        timeMinute = (int)limitTime / 60;
        timeSecond = (int)limitTime - (timeMinute * 60);

        if (timeSecond < 10)
        {
            timeText.text = "0" + timeMinute + ":" + "0" + timeSecond;
        }
        else
        {
            timeText.text = "0" + timeMinute + ":" + timeSecond;
        }
    }

    IEnumerator CountTime(float delayTime)
    {
        Debug.Log("Time : " + Time.time);
        limitTime -= 1;
        timeSlider.value = limitTime;
        yield return new WaitForSeconds(delayTime);
        if (limitTime != 0)
            StartCoroutine("CountTime", 1);
    }
}
