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

        if (hit)
        {
            Debug.Log(hit.collider.tag);
        }
    }

    public void Kick()
    {
        RaycastHit2D hit = Physics2D.Raycast(_trHitPosition.position, Vector2.zero);

        if (hit)
        {
            Debug.Log(hit.collider.tag);
        }
    }

    public void GetDamaged()
    {
        StartCoroutine(TakeDamage());
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
