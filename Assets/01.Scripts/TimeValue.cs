using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeValue : MonoBehaviour
{
    public static TimeValue _pInstance;

    public float _fLeftTime;

    private void Awake()
    {
        if (_pInstance == null)
        {
            _pInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
