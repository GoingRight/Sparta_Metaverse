using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AnimationHandler : MonoBehaviour
{
    //테스트
    protected Animator animator;

    private void Awake()
    {
        animator=GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool("IsMove", obj.magnitude > 0.5f);
    }

    public void Damage()
    {
        animator.SetBool("IsDamage", true);
    }

    public void DamageFinish()
    {
        animator.SetBool("IsDamage", false);
    }
}
