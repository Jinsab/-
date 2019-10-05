using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyQuiz : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private QuestionManager _questionManager;
    private float timeSecond = 0f;

    private void Start()
    {
        //StartCoroutine("Ready", 0.5f);
    }

    IEnumerator Ready()
    {
        gameObject.GetComponentInChildren<Text>().text = "READY!" + "\n";
        yield return new WaitForSeconds(1f);
        StartCoroutine("Go");
    }

    IEnumerator Go()
    {
        gameObject.GetComponentInChildren<Text>().text += "GO!";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("ActiveFalse");
    }


    IEnumerator ActiveFalse()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        
        _timer.StartCoroutine("CountTime", 1f);
        _questionManager.StartCoroutine("CountTime", 1f);
        _questionManager.StartCoroutine("SetQuiz");
    }
}
