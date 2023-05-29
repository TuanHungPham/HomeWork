using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Destroy(this.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
