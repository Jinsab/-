using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWall : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spr = null;
    [SerializeField] private Transform _tr = null;
    [SerializeField] private float _fMoveSpeed = 1f;

    public void DoInit(Sprite img)
    {
        _spr.sprite = img;
    }

    private void Update()
    {
        if (CGameManager._pInstance._bIsScrollBG)
        {
            _tr.Translate(Vector3.left * _fMoveSpeed * Time.deltaTime);

            if (_tr.position.x < -4.5f)
            {
                CBGController._pInstance._bIsDestroyedWall = true;
                Destroy(gameObject);
            }

            if (CBGController._pInstance._trLastWall.gameObject == gameObject)
            {
                if (CBGController._pInstance._bIsDestroyedWall)
                {
                    CBGController._pInstance.WallRegen();
                }
            }
        }        
    }
}
