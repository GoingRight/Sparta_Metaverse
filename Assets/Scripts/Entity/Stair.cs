using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stair : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("부딪혔습니다");
            SceneManager.LoadScene("MiniGameScene");
        }
    }
}
