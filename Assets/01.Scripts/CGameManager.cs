using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public static CGameManager _pInstance;

    [SerializeField] private CameraShake _cameraShake = null;
    [SerializeField] private MeshRenderer _bgMsr = null;
    [SerializeField] private Image _uiFade = null;

    public bool _bIsScrollBG = false;
    public float _fBGScrollSpeed = 1f;

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

    private void Update()
    {
        Debug.Log(_bgMsr.material.mainTextureOffset);
        if (_bIsScrollBG == true)
        {
            float offsetX = _bgMsr.material.mainTextureOffset.x + (Time.deltaTime * _fBGScrollSpeed);
            if (offsetX > 1f) offsetX--;

            _bgMsr.material.mainTextureOffset = new Vector2(offsetX, 0f);
        }
    }

    public void PlayerTakeDamage()
    {
        _cameraShake.shakeDuration = 0.2f;
    }

    IEnumerator Fadeout()
    {
        while(_uiFade.color.a < 1f)
        {
            _uiFade.color = new Color(0f, 0f, 0f, _uiFade.color.a + Time.deltaTime);
            yield return null;
        }
    }
}
