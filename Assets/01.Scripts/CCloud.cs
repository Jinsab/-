using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCloud : MonoBehaviour
{
    [SerializeField] private Transform _tr = null;
    [SerializeField] private SpriteRenderer _spr = null;
    [SerializeField] private float _fMoveSpeed = 0f;

    private void Update()
    {
        if (CGameManager._pInstance._bIsScrollBG)
        {
            _tr.Translate(Vector3.left * _fMoveSpeed * Time.deltaTime);

            if (_tr.position.x < -6f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void DoInit(Sprite img)
    {
        _spr.sprite = img;
    }
}
