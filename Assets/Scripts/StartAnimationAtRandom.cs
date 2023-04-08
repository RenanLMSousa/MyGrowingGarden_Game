using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationAtRandom : MonoBehaviour
{
    private Animator _animator;
    private void OnEnable()
    {
        _animator = this.GetComponent<Animator>();
        var state = _animator.GetCurrentAnimatorStateInfo(0);
        _animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));

    }
}
