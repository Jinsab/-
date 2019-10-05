using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    public static CGameManager _pInstance;

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
}
