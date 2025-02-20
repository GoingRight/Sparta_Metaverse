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
        else if(collision.gameObject.name == "Goblin" ||  collision.gameObject.name == "Orc")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CheckCollisionBlock")//타일맵을 루프시키는 로직
        {
            GameObject tileMap = collision.transform.parent.gameObject;
            Vector2 pos = tileMap.transform.position;
            pos.x += 104;
            tileMap.transform.position = pos;
        }
    }
}
