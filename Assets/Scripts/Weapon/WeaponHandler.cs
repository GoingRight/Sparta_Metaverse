using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [Header("Attack Info")]
    [SerializeField] private float delay = 1f;
    public float Delay { get => delay; set => delay = value; }

    [SerializeField] private float weaponSize = 1f;
    public float WeaponSize { get => weaponSize; set => weaponSize = value; }

    [SerializeField] public float power = 1f;
    public float Power { get => power; set => power = value; }

    [SerializeField] private float speed = 1f;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField] private float attackRange = 10f;
    public float AttackRange { get => attackRange; set => attackRange = value; }

    public LayerMask target;
    public BaseController Controller { get; private set; }

    private Animator animator;

    private SpriteRenderer weaponRenderer;

    protected virtual void Awake()
    {
        Controller = GetComponentInParent<BaseController>();
        animator = GetComponentInChildren<Animator>();
        weaponRenderer = GetComponentInChildren<SpriteRenderer>();

        animator.speed = 1.0f / delay;
        transform.localScale = Vector3.one * weaponSize;
    }
    protected virtual void Start()
    {
        
    }

    public virtual void Attack()
    {
        AttackAnimation();
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("IsAttack");
    }

    public virtual void Rotate(bool isLeft)
    {
        weaponRenderer.flipY = isLeft;
    }
}
