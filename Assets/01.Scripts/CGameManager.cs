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
    [SerializeField] private GameObject[] _prefEnemys = null;
    [SerializeField] private Transform[] _trEnemyRegenPos = null;
    [SerializeField] private Transform _trEnemyPrent = null;

    public GAME_STATE _eState = GAME_STATE.NULL;
    public bool _bIsScrollBG = false;
    public float _fCharacterActPos = 0f;

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

        Screen.SetResolution(720, 1280, true);
    }

    private void Start()
    {
        DoInit();
    }

    private void Update()
    {
        if (_eState == GAME_STATE.PRE_ACTION)
        {
            _character.transform.Translate(Vector3.left * Time.deltaTime * 5f);

            if (_character.transform.position.x < _fCharacterActPos)
            {
                _character.transform.position = new Vector3(_fCharacterActPos, 
                    _character.transform.position.y, _character.transform.position.z);

                _character.SetLanding(false);

                _eState = GAME_STATE.ACTION;

                StartCoroutine(RegenEnemy());
            }
        }
    }

    public void DoInit()
    {
        _eState = GAME_STATE.PRE_ACTION;
        _bIsScrollBG = true;
        _character.SetLanding(true);
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

    IEnumerator RegenEnemy()
    {
        yield return new WaitForSeconds(3f);

        while(true)
        {
            int randEnemyIdx = Random.Range(0, _prefEnemys.Length);

            CEnemy enemy = Instantiate(_prefEnemys[randEnemyIdx], 
                _trEnemyRegenPos[randEnemyIdx].position, Quaternion.identity).GetComponent<CEnemy>();

            enemy.DoInit();
            enemy.transform.SetParent(_trEnemyPrent);

            yield return new WaitForSeconds(2f);
        }        
    }
}
