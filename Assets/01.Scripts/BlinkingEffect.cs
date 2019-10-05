using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlinkingEffect : MonoBehaviour
{
    [SerializeField] private ReadyQuiz _readyQuiz;

    public GameObject Rapid;
    public float speed = 10f;
    public CanvasGroup canvasGroup;
    public Image yeonghe;
    public GameObject TimeUI;
    public GameObject QuizUI;

    private float y1 = 0f;
    private float y2 = 0f;
    private float alpha = 0f;

    private Image blinkingImage;

    void Start()
    {
        blinkingImage = gameObject.GetComponent<Image>();
        StartCoroutine("In");
        y1 = (TimeUI.transform.position.y-640f) / 60.0f;
        y2 = (QuizUI.transform.position.y-640f) / 60.0f;
    }

    IEnumerator In()
    {
        blinkingImage.color = new Color(blinkingImage.material.color.r, blinkingImage.material.color.g, blinkingImage.material.color.b, 0f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Out");
    }

    IEnumerator Out()
    {
        blinkingImage.color = new Color(blinkingImage.material.color.r, blinkingImage.material.color.g, blinkingImage.material.color.b, 1f);
        yield return new WaitForSeconds(0.5f);
        
        if (Time.time > 2)
            StartCoroutine("RapidScroll");
        else
            StartCoroutine("In");
    }

    IEnumerator RapidScroll()
    {
        while (Rapid.transform.position.x < 2880f)
        {
            speed += Time.time;
            Rapid.transform.position += new Vector3(speed, 0f);
            canvasGroup.alpha -= 0.023337f;
            yield return new WaitForSeconds(0.01f);
            yield return new WaitForFixedUpdate();
        }

        StartCoroutine("MoveUI");
    }

    IEnumerator MoveUI()
    {
        while (TimeUI.transform.position.y-640f > 0 && QuizUI.transform.position.y-640f < 0)
        {
            TimeUI.transform.position -= new Vector3(0f, y1);
            QuizUI.transform.position -= new Vector3(0f, y2);

            alpha += 0.01667f;

            yeonghe.color = new Color(blinkingImage.material.color.r, blinkingImage.material.color.g, blinkingImage.material.color.b, alpha);

            yield return new WaitForSeconds(0.016667f);
        }

        _readyQuiz.StartCoroutine("Ready", 0.5f);
        Rapid.SetActive(false);
    }
}
