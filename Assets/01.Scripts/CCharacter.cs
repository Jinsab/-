using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacter : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;

    void Update()
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
}
