using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTitle : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz");
        }
    }
}
