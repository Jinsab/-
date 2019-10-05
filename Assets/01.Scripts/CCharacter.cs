using System.Collections;
using UnityEngine;

public class CCharacter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spr = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Transform _trHitPosition = null;

    private void Update()
    {
        if (SwipeInput.swipedUp)
        {
            _animator.SetTrigger("Punch");
        }
        else if (SwipeInput.swipedDown)
        {
            _animator.SetTrigger("Kick");
        }
    }

    public void Punch()
    {
        RaycastHit2D hit = Physics2D.Raycast(_trHitPosition.position, Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            CEnemy enemy = hit.transform.gameObject.GetComponent<CEnemy>();

            if (enemy._eType == CEnemy.ENEMY_TYPE.PUNCH)
            {
                enemy.TakeDamaged();
            }            
        }
    }

    public void Kick()
    {
        RaycastHit2D hit = Physics2D.Raycast(_trHitPosition.position, Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            CEnemy enemy = hit.transform.gameObject.GetComponent<CEnemy>();

            if (enemy._eType == CEnemy.ENEMY_TYPE.KICK)
            {
                enemy.TakeDamaged();
            }
        }
    }

    public void SetLanding(bool isLand)
    {
        _animator.SetBool("Land", isLand);
    }

    public void GetDamaged()
    {
        StartCoroutine(TakeDamage());

        CGameManager._pInstance.PlayerTakeDamage();
    }

    IEnumerator TakeDamage()
    {
        for( int i =0; i<4; i++)
        {
            _spr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            _spr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
