using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_Animator : MonoBehaviour
{
    private Animator _animator;
    public bool flag;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Waiting_Animation());
    }

    private IEnumerator Waiting_Animation()
    {
        while (flag)
        { 
            if(!_animator.GetBool("Random"))_animator.SetBool("Random", flag);
            yield return new WaitForSeconds(Random.Range(4.6f, 8.3f));
        }
    }
}
