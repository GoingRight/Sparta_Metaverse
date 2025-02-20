using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    Camera camera;
    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }
    protected override void HandleAction()
    {
        //플레이어 이동 관련 입력
        base.HandleAction();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        //플레이어 시선 처리 관련 마우스
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        isAttacking = Input.GetMouseButton(0);
    }
    public override void Death()
    {
        base.Death();
        GameManager.Instance.GameOver();
    }
}
