using UnityEngine;

public class CEnemy : MonoBehaviour
{
    public enum ENEMY_TYPE
    {
        NULL = -1,
        PUNCH,
        KICK,
        NUMBEROFTYPES
    }

    [SerializeField] private Rigidbody2D _rig2D = null;

    public ENEMY_TYPE _eType = ENEMY_TYPE.NULL;
    public float _fMoveSpeed = 0f;

    private Transform _tr = null;
    private bool _bDoDamage = false;
    private bool _bIsDead = false;

    private void Awake()
    {
        _tr = transform;
    }

    private void Update()
    {
        if(!_bIsDead)
            _tr.Translate(Vector3.left * _fMoveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        DoInit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_bDoDamage)
            return;

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<CCharacter>().GetDamaged();
            _bDoDamage = true;
        }
    }

    public void DoInit()
    {
        _rig2D.gravityScale = 0f;
        _bIsDead = false;
        _bDoDamage = false;
    }
    
    public void TakeDamaged()
    {
        _rig2D.gravityScale = 1f;
        float hPower = Random.Range(200f, 400f);
        _rig2D.AddForce(new Vector2(hPower, 200f));
        float rPower = Random.Range(-360f, -720f);
        _rig2D.AddTorque(rPower);
        _bIsDead = true;
        _bDoDamage = true;
    }
}
