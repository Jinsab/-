using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public enum GAME_STATE
    {
        NULL = -1,
        QUIZ,
        PRE_ACTION,
        ACTION,
        GAMEOVER,
        NUMBEROFTYPES
    }

    public static CGameManager _pInstance;

    [SerializeField] private CCharacter _character = null;
    [SerializeField] private CameraShake _cameraShake = null;
    [SerializeField] private MeshRenderer _bgMsr = null;
    [SerializeField] private Image _uiFade = null;
    [SerializeField] private Transform _trEnemyPrent = null;

    public GAME_STATE _eState = GAME_STATE.NULL;
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

    private void Start()
    {
        DoInit();
    }

    private void Update()
    {
        if (_eState == GAME_STATE.PRE_ACTION)
        {

        }

        if (_bIsScrollBG == true)
        {
            BGScroll();
        }
    }

    public void DoInit()
    {
        _eState = GAME_STATE.PRE_ACTION;
        _bIsScrollBG = false;
        _character.SetLanding(true);
    }

    public void PlayerTakeDamage()
    {
        _cameraShake.shakeDuration = 0.2f;
    }

    private void BGScroll()
    {
        float offsetX = _bgMsr.material.mainTextureOffset.x + (Time.deltaTime * _fBGScrollSpeed);
        if (offsetX > 1f) offsetX--;

        _bgMsr.material.mainTextureOffset = new Vector2(offsetX, 0f);
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
