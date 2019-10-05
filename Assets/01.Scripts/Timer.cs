using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _limitTime = 180.0f; // 시간제한 3분

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

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
            timeSlider.GetComponentInChildren<Image>().transform.position = new Vector3((520f - ((260f / 180f) * (180f - limitTime))), timeSlider.GetComponentInChildren<Image>().transform.position.y);
        }
    }
    public Slider timeSlider;
    public Text timeText;
    int timeMinute = 0, timeSecond = 0;

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
        yield return new WaitForSeconds(delayTime);

        limitTime -= 1;
        timeSlider.value = limitTime;
        timeSlider.GetComponentInChildren<Image>().transform.position = new Vector3((520f - ((260f/180f) * (180f - limitTime))), timeSlider.GetComponentInChildren<Image>().transform.position.y);

        if (limitTime > 0)
            StartCoroutine("CountTime", 1);
        else
            StartCoroutine("GameOver");
    }

    IEnumerator GameOver()
    {
        Debug.Log("GameOver");

        yield return new WaitForFixedUpdate();

        StopCoroutine("CountTime");
    }
}
