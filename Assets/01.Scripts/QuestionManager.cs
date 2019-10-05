using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    public Slider questionTimer;
    public Button askButton01;
    public Button askButton02;
    public Button askButton03;
    public float maxTime = 10f;

    private int questionNumber = 0;
    private int n = 0, m = 0;
    private float remainder = 0, quotient = 0;

    private void Start()
    {
        questionTimer.maxValue = maxTime;
        questionTimer.value = maxTime;
        questionNumber = Random.Range(0, 1);
        StartCoroutine("SetQuiz", 1.0f);
    }

    void Update()
    {

    }

    IEnumerator CountTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        questionTimer.value -= 1;

        if (questionTimer.value == 0)
            StartCoroutine("SetQuiz");
        else
            StartCoroutine("CountTime", 1);
    }

    IEnumerator SetQuiz()
    {
        questionNumber = Random.Range(0, 1); // max값은 문제의 개수

        if (questionNumber == 0)
        {
            int randomQuestion = Random.Range(0, 3);

            if (randomQuestion == 0)
                Question01(askButton01, askButton02, askButton03);
            else if (randomQuestion == 1)
                Question01(askButton02, askButton01, askButton03);
            else
                Question01(askButton03, askButton01, askButton02);
        }

        questionTimer.value = 10;

        yield return new WaitForFixedUpdate();
        StartCoroutine("CountTime", 1);
    }
    void Question01 (Button button1, Button button2, Button button3)
    {
        // 어떤 수를 X로 나눴더니 몫이 Y, 나머지가 Z가 되었다. 어떤 수는 얼마인가?
        // 정답 1 : X*Y+Z, 정답 2 : 얼마
        // 예외처리 : Y＜X, 즉 X는 어떤 수 > X

        n = Random.Range(1, 100);
        m = Random.Range(1, n+1);

        Debug.Log(n);
        Debug.Log(m);

        quotient = n / m;
        remainder = n % m;

        questionText.text = "어떤 수를 " + m + "으로 나누었더니 몫이 " + quotient + ", 나머지가 " + remainder + "가 되었다. 어떤 수는 얼마인가?";

        int randomResult = Random.Range(0, 1);


        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = (n + "*" + m + "+" + remainder);
        else
            button1.GetComponentInChildren<Text>().text = "" + ((n * m) + remainder);


        int margin1 = 0, margin2 = 0;


        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = "" + ((n * m) + remainder + margin1);
        

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = "" + ((n * m) + remainder + margin2);
    }
}
