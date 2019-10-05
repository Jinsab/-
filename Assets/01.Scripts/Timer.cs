using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _limitTime = 180.0f;
    public float limitTime
    {
        get
        {
            return _limitTime;
        }
        set
        {
            _limitTime = value;
            timeSlider.value = limitTime;
        }
    }
    public Slider timeSlider;
    public Text timeText;
    int timeMinute = 0, timeSecond = 0;

    void Update()
    {
        timeCalculation(limitTime);

        if (limitTime <= 0)
        {
            // 게임오버
        }
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
        yield return new WaitForSeconds(delayTime);

        limitTime -= 1;
        timeSlider.value = limitTime;

        if (limitTime != 0)
            StartCoroutine("CountTime", 1);
    }
}
