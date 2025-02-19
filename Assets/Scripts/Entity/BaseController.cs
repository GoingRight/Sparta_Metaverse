using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRender;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    public WeaponHandler WeaponPrefab;
    protected WeaponHandler weaponHandler;

    protected bool isAttacking;

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();

        if(SceneManager.GetActiveScene().buildIndex == 1)//1 == MiniGameScene
        {
            if (WeaponPrefab != null)
            {
                weaponHandler = Instantiate(WeaponPrefab, weaponPivot);
            }
            else
            {
                Debug.LogWarning("WaponPrefab is NULL");
            }
        } 

    }

    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {

            Movement(movementDirection);


    }

    protected virtual void HandleAction()
    {
        
    }

    private void Movement(Vector2 direction)//direction에 movementDirection이 들어감
    {
        direction = direction * 5;//나중에 스텟 스피드로 대체

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    private void Rotate(Vector2 direction)//direction에 lookDirection이 들어감
    {
        float theta = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(theta) > 90f;

        characterRender.flipX = isLeft;
    }
}
