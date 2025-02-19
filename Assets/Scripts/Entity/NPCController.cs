using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRender;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject TeachInterActiveKey;
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

   private Coroutine InteractionCoroutine;//저장

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (InteractionCoroutine != null)
            {
                StopCoroutine(InteractionCoroutine);
            }
            if (TeachInterActiveKey == null) { return; }
            InteractionCoroutine = StartCoroutine(InteractionCo());
    }

    private IEnumerator InteractionCo()//생성
    {
        TeachInterActiveKey.SetActive(true);
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.F));//조건이 만족될때까지 대기
        TeachInterActiveKey.SetActive(false);
        //UI 띄우기
        Debug.Log("켜졌습니다");
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.F));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        //UI 꺼주기
        Debug.Log("꺼졌습니다");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(InteractionCoroutine != null)
        {
            StopCoroutine(InteractionCoroutine);
            TeachInterActiveKey.SetActive(false);
        }
    }
}
