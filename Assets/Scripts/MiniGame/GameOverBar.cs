using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBar : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //게임오버
            Debug.Log("Game over");
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CheckCollisionBlock")
        {
            Debug.Log("블록과 닿았습니다.");
            GameObject tileMap = collision.transform.parent.gameObject;
            Vector2 pos = tileMap.transform.position;
            pos.x += 104;
            tileMap.transform.position = pos;
        }
    }
}
