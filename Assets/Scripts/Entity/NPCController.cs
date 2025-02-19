using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRender;
    [SerializeField] private Transform target;

    private Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private void Update()
    {
        FindTarget();
        Rotate(lookDirection);
    }

    private void Rotate(Vector2 direction)//direction에 lookDirection이 들어감
    {
        float theta = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(theta) > 90f;

        characterRender.flipX = isLeft;
    }

    private void FindTarget()//플레이어 위치 탐색
    {
        Vector2 targetPosition = target.position;
        Vector2 nowPosition = transform.position;
        lookDirection = (targetPosition - nowPosition);
    }
}
