using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    public Text questionText;
    //public Text correntText;
    public Timer timer;
    public Image questionTimer;
    public Image ok_Mark;
    public Image x_Mark;
    public Image timeOut;
    public Image yeonghe01;
    public Image yeonghe02;
    public Image yeonghe03;
    public Image yeonghe04;
    public Image fadeBackImage;
    public Image outWall;
    public Image fadeImage;
    public Image film;
    public Button askButton01;
    public Button askButton02;
    public Button askButton03;
    public float maxTime = 10f;
    public Animator animator;

    private int questionNumber = 0, randomQuestion;
    private float remainder = 0, quotient = 0;
    private int quizCount = 0;
    private int hash = Animator.StringToHash("FlowerPot");

    private void Start()
    {
        questionTimer.fillAmount = 1;
        questionNumber = Random.Range(0, 1);
    }

    IEnumerator CountTime(float delayTime)
    {
        while (true)
        {
            questionTimer.fillAmount -= 0.1f;
            yield return new WaitForSeconds(delayTime);

            if (questionTimer.fillAmount == 0)
            {
                timeOut.gameObject.SetActive(true);
                timer.limitTime -= maxTime;
                StartCoroutine("SetQuiz");

                yield return new WaitForSeconds(1f);

                timeOut.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator SetQuiz()
    {
        questionNumber = Random.Range(0, 10); // max값은 문제의 개수

        switch (questionNumber)
        {
            case 0:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question01(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question01(askButton02, askButton01, askButton03);
                    else
                        Question01(askButton03, askButton01, askButton02);
                }
                break;

            case 1:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question02(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question02(askButton02, askButton01, askButton03);
                    else
                        Question02(askButton03, askButton01, askButton02);
                }
                break;

            case 2:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question03(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question03(askButton02, askButton01, askButton03);
                    else
                        Question03(askButton03, askButton01, askButton02);
                }
                break;

            case 3:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question04(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question04(askButton02, askButton01, askButton03);
                    else
                        Question04(askButton03, askButton01, askButton02);
                }
                break;

            case 4:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question05(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question05(askButton02, askButton01, askButton03);
                    else
                        Question05(askButton03, askButton01, askButton02);
                }
                break;

            case 5:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question06(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question06(askButton02, askButton01, askButton03);
                    else
                        Question06(askButton03, askButton01, askButton02);
                }
                break;

            case 6:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question07(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question07(askButton02, askButton01, askButton03);
                    else
                        Question07(askButton03, askButton01, askButton02);
                }
                break;

            case 7:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question08(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question08(askButton02, askButton01, askButton03);
                    else
                        Question08(askButton03, askButton01, askButton02);
                }
                break;

            case 8:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question09(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question09(askButton02, askButton01, askButton03);
                    else
                        Question09(askButton03, askButton01, askButton02);
                }
                break;

            default:
                {
                    randomQuestion = Random.Range(0, 3);

                    if (randomQuestion == 0)
                        Question10(askButton01, askButton02, askButton03);
                    else if (randomQuestion == 1)
                        Question10(askButton02, askButton01, askButton03);
                    else
                        Question10(askButton03, askButton01, askButton02);
                }
                break;
        }

        questionTimer.fillAmount = 1;

        yield return new WaitForFixedUpdate();
    }

    IEnumerator ClearQuiz()
    {
        _timer.StopCoroutine("CountTime");
        yeonghe01.gameObject.SetActive(false);
        yeonghe02.gameObject.SetActive(true);
        animator.Play(hash);

        StartCoroutine("FadeIn");

        while (gameObject.transform.parent.position.y > -1440f)
        {
            gameObject.transform.parent.position -= new Vector3(0f, 10f);
            yield return new WaitForSeconds(0.01337f);
        }

        gameObject.transform.parent.gameObject.SetActive(false);

        yield return new WaitForFixedUpdate();
    }

    IEnumerator FadeIn()
    {
        float alpha = 0f;

        while (fadeBackImage.color.a < 1)
        {
            alpha += 0.01667f;
            fadeBackImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        outWall.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        yeonghe03.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        float speed = 4f;

        while (outWall.transform.localPosition.y < 1134f)
        {
            outWall.transform.localPosition += new Vector3(0f, speed);
            speed += 4f;
            Debug.Log(outWall.transform.position);
            yield return new WaitForSeconds(0.0133337f);
        }

        outWall.transform.localPosition = new Vector3(outWall.transform.localPosition.x, 1134f);
        yeonghe03.gameObject.SetActive(false);
        yeonghe04.gameObject.SetActive(true);
    }

    void Question01 (Button button1, Button button2, Button button3)
    {
        // 어떤 수를 X로 나눴더니 몫이 Y, 나머지가 Z가 되었다. 어떤 수는 얼마인가?
        // 정답 1 : X*Y+Z, 정답 2 : 얼마
        // 예외처리 : Y＜X, 즉 X는 어떤 수 > X

        int x = Random.Range(1, 100); // 어떤수
        int y = Random.Range(1, x+1);

        Debug.Log(x);
        Debug.Log(y);

        quotient = x / y;
        remainder = x % y;
        float result = (x * quotient) + remainder;

        questionText.text = "어떤 수를 " + y + "으로 나누었더니 몫이 " + quotient + ", 나머지가 " + remainder + "가 되었다. 어떤 수는 얼마인가?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = "" + result;
        else
            button1.GetComponentInChildren<Text>().text = "얼마";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = "" + (result + margin1);
        

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = "" + (result + margin2);

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question02(Button button1, Button button2, Button button3)
    {
        // X인승 버스 Y대에 나눠탄 뒤 버스마다 Z자리씩 비어 있다면 총 인원은 모두 몇 명인가?
        // 정답 1 : (X-Z)*Y, 정답 2 : 세다가 버스를 놓쳤다.
        // 예외처리 : Z＜X

        int x = Random.Range(1, 200);
        int y = Random.Range(1, 200);
        int z = Random.Range(1, x + 1);

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);

        quotient = (x-z)*y;

        questionText.text = x + "인승 버스 " + y + "대에 나눠탄 뒤 버스마다 " + z + "자리씩 비어 있다면 총 인원은 모두 몇 명인가?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = quotient + "명";
        else
            button1.GetComponentInChildren<Text>().text = "세다가 버스를 놓쳤다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = (quotient + margin1) + "명";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = (quotient + margin2) + "명";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question03(Button button1, Button button2, Button button3)
    {
        // 하루에 X번 줄넘기를 일주일 동안 하면 어떻게 되는가?
        // 정답 1 : X*7, 정답 2 : 종아리에 알베긴다.
        // 예외처리 : X=100~30000

        int x = Random.Range(100, 30000);

        Debug.Log(x);

        quotient = x * 7;

        questionText.text = "하루에 " + x + "번 줄넘기를 일주일 동안 하면 어떻게 되는가?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = quotient + "번";
        else
            button1.GetComponentInChildren<Text>().text = "종아리에 알베긴다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = (quotient + margin1) + "번";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = (quotient + margin2) + "번";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question04(Button button1, Button button2, Button button3)
    {
        // 아침에 X그램짜리 사과 Y개, 점심에 Z그램짜리 복숭아 N개를 먹으면?
        // 정답 1 : (X*Y)+(Z*N), 정답 2 : 배탈난다.
        // 예외처리 : 모든 변수 범위는 10~200

        int x = Random.Range(10, 200);
        int y = Random.Range(10, 200);
        int z = Random.Range(10, 200);
        int n = Random.Range(10, 200);

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);
        Debug.Log(n);

        quotient = (x*y)+(z*n);

        questionText.text = "아침에 " + x + "그램짜리 사과 " + y + "개, 점심에 " + z + "그램짜리 복숭아 " + n + "개를 먹으면?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = quotient + "g";
        else
            button1.GetComponentInChildren<Text>().text = "배탈난다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = (quotient + margin1) + "g";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = (quotient + margin2) + "g";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question05(Button button1, Button button2, Button button3)
    {
        // 어떤 수에 X를 곱해야 하는데 Y를 곱하여 Z가 나왔다. 바르게 계산하면 어떻게 되는가?
        // 정답 1 : (Z/Y)*X, 정답 2 : 계산적이란 평가를 받는다.
        // 예외처리 : Z=X*Y

        int n = Random.Range(1, 200);
        int x = Random.Range(1, 200);
        int y = Random.Range(1, 200);
        int z = n * y;

        Debug.Log(n);
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);

        quotient = (z/y) * x;

        questionText.text = "어떤 수에 " + x + "을(를) 곱해야 하는데 " + y + "을(를) 곱하여 " + z + "이(가) 나왔다. 바르게 계산하면 어떻게 되는가?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = "" + quotient;
        else
            button1.GetComponentInChildren<Text>().text = "계산적이란 평가를 받는다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = "" + (quotient + margin1);

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = "" + (quotient + margin2);

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question06(Button button1, Button button2, Button button3)
    {
        // 길이 Xcm인 테이프 Y장을 Zcm씩 겹쳐서 이어붙였을 때 길이는?
        // 정답 1 : (X-Z)*(Y-1)+X, 정답 2 : 내 키보다 크다.
        // 예외처리 : X=90~180, Y&N=1~9, Z=10~30

        int x = Random.Range(90, 181);
        int y = Random.Range(1, 10);
        int z = Random.Range(1, 10);
        // int m = Random.Range(10, 31);

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);

        quotient = (x-z)*((y-1)+x);

        questionText.text = "길이 " + x + "cm인 테이프 " + y + "장을 " + z + "cm씩 겹쳐서 이어붙였을 때 길이는?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = quotient + "cm";
        else
            button1.GetComponentInChildren<Text>().text = "내 키보다 크다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 11);

        button2.GetComponentInChildren<Text>().text = (quotient + margin1) + "cm";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 11);

        button3.GetComponentInChildren<Text>().text = (quotient + margin2) + "cm";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question07(Button button1, Button button2, Button button3)
    {
        // Xkg Yg의 밀가루에서 ZKg Ng만큼 사용하고 Ag만큼 사왔을 때, 지금 있는 밀가루는?
        // 정답 1 : (X*1000+Y)-(Z*1000+N)+A, 정답 2 : 비올때 부침개 해먹는다.
        // 예외처리 : X=90~180, Y&N=1~9, Z=10~30, Z=1~20, X=Z+3~9, 숫자값 반환 기능을 사용하여 킬로그램 단위 표시
        
        int x = Random.Range(90, 181);
        int y = Random.Range(1, 10);
        int z = Random.Range(10, 31);
        int n = Random.Range(1, 21);
        int a = Random.Range(z + 3, 10);

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);
        Debug.Log(n);
        Debug.Log(a);

        quotient = (x * 1000 + y) - (z * 1000 + n) + a;

        questionText.text = x + "Kg " + y + "g의 밀가루에서 " + z + "Kg " + n + "g만큼 사용하고 " + a + "g만큼 사왔을 때, 지금 있는 밀가루는?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = "" + (quotient/1000) + "Kg ";
        else
            button1.GetComponentInChildren<Text>().text = "비올때 부침개 해먹는다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10000, 10001);

        button2.GetComponentInChildren<Text>().text = "" + ((quotient + margin1) / 1000) + "Kg";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10000, 10001);

        button3.GetComponentInChildren<Text>().text = "" + ((quotient + margin2) / 1000) + "Kg";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question08(Button button1, Button button2, Button button3)
    {
        // 고양이의 몸무게는 XKg Yg이고, 영희가 고양이를 안고 잰 몸무게는 ZKg Ng이다. 영희의 몸무게는?
        // 정답 1 : (Z*1000+N)-(X*1000+Y), 정답 2 : 여자의 몸무게는 비밀♡
        // 예외처리 : Y&N=1~999, X=1~5, Z=X+45~55, 숫자값 반환 기능을 사용하여 킬로그램 단위 표시

        int x = Random.Range(1, 6);
        int y = Random.Range(1, 1000);
        int z = Random.Range(x+45, x+56);
        int n = Random.Range(1, 1000);
        
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);
        Debug.Log(n);
        
        quotient = (z*1000+n)-(x*1000+y);

        questionText.text = "고양이의 몸무게는 " + x + "Kg " + y + "g이고, 영희가 고양이를 안고 잰 몸무게는 " + z + "Kg" + n + "g이다. 영희의 몸무게는?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = "" + (int)(quotient / 1000) + "Kg " + (quotient % 1000) + "g";
        else
            button1.GetComponentInChildren<Text>().text = "여자의 몸무게는 비밀♡";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-5000, 5001);

        button2.GetComponentInChildren<Text>().text = "" + (int)((quotient + margin1) / 1000) + "Kg " + ((quotient + margin1) % 1000) + "g";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-5000, 5001);

        button3.GetComponentInChildren<Text>().text = "" + (int)((quotient + margin2) / 1000) + "Kg " + ((quotient + margin2) % 1000) + "g";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question09(Button button1, Button button2, Button button3)
    {
        // 먹쇠가 X개, 장쇠가 Y개만큼의 나무를 해온 뒤 동쇠가 Z개만큼 사용하여 아궁이를 지폈을 때 남은 나무의 갯수는?
        // 정답 1 : X+Y-Z, 정답 2 : 마님은 돌쇠에게만 쌀밥을 준다.
        // 예외처리 : Z<X+Y, X&Y=10~70

        int x = Random.Range(10, 71);
        int y = Random.Range(10, 71);
        int z = Random.Range(0, x+y);

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);

        quotient = x + y - z;

        questionText.text = "먹쇠가 " + x + "개, 장쇠가 " + y + "개 만큼의 나무를 해온 뒤 동쇠가 " + z + "개 만큼 사용하여 아궁이를 지폈을 때 남은 나무의 갯수는?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
            button1.GetComponentInChildren<Text>().text = quotient + "개";
        else
            button1.GetComponentInChildren<Text>().text = "마님은 돌쇠에게만 쌀밥을 준다.";

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-10, 101);

        button2.GetComponentInChildren<Text>().text = (quotient + margin1) + "개";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-10, 101);

        button3.GetComponentInChildren<Text>().text = (quotient + margin2) + "개";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void Question10(Button button1, Button button2, Button button3)
    {
        // 고니가 X만원, 아귀가 Y만원, 곽쳘용이 Z만원만큼 판돈을 걸면?
        // 정답 1 : X+Y+Z, 정답 2 : 묻고 더블로 간다.
        // 예외처리 : X&Y&Z=1000~9999

        int x = Random.Range(1000, 10000);
        int y = Random.Range(1000, 10000);
        int z = Random.Range(1000, 10000);

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);

        quotient = x + y + z;

        questionText.text = "고니가 " + x + "만원, 아귀가 " + y + "만원, 곽철용이 " + z + "만원만큼 판돈을 걸면?";

        int randomResult = Random.Range(0, 2);

        if (randomResult == 1)
        {
            if (quotient > 10000)
                button1.GetComponentInChildren<Text>().text = (int)(quotient/10000) + "억 " + (quotient%10000) + "만원";
            else
                button1.GetComponentInChildren<Text>().text = quotient + "만원";
        }
        else
        {
            button1.GetComponentInChildren<Text>().text = "묻고 더블로 간다.";
        }

        int margin1 = 0, margin2 = 0;

        while (margin1 == 0)
            margin1 = Random.Range(-3000, 3001);

        if ((quotient + margin1) > 10000)
            button2.GetComponentInChildren<Text>().text = (int)((quotient + margin1) / 10000) + "억 " + ((quotient + margin1) % 10000) + "만원";
        else
            button2.GetComponentInChildren<Text>().text = (quotient + margin1) + "만원";

        while (margin2 == 0 || margin2 == margin1)
            margin2 = Random.Range(-3000, 3001);

        if ((quotient + margin2) > 10000)
            button3.GetComponentInChildren<Text>().text = (int)((quotient + margin2) / 10000) + "억 " + ((quotient + margin2) % 10000) + "만원";
        else
            button3.GetComponentInChildren<Text>().text = (quotient + margin2) + "만원";

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(correct);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(wrong);

        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(wrong);
    }

    void correct()
    {
        x_Mark.gameObject.SetActive(false);
        timeOut.gameObject.SetActive(false);
        StartCoroutine("CorrectRoutine");
    }

    void wrong()
    {
        ok_Mark.gameObject.SetActive(false);
        timeOut.gameObject.SetActive(false);
        StartCoroutine("WrongRoutine");
    }

    IEnumerator CorrectRoutine()
    {
        quizCount++;
        ok_Mark.gameObject.SetActive(true);
        int okQuestion = randomQuestion;

        StartCoroutine("SetQuiz", 1.0f);
        film.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        ok_Mark.gameObject.SetActive(false);
        film.gameObject.SetActive(false);

        if (quizCount >= 5)
            StartCoroutine("ClearQuiz");
    }

    IEnumerator WrongRoutine()
    {
        x_Mark.gameObject.SetActive(true);
        timer.limitTime -= maxTime;
        int okQuestion = randomQuestion;

        StartCoroutine("SetQuiz", 1.0f);
        film.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        film.gameObject.SetActive(false);
        x_Mark.gameObject.SetActive(false);
    }
}
