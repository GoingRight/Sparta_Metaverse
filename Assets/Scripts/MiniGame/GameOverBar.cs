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
}
