using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMoving : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed;
    private GameManager gameManager;
    private GameOverBar gameOverBar;

    private void Awake()
    {
        this.gameManager = GameManager.Instance;
        gameOverBar = GetComponentInChildren<GameOverBar>();
    }
    private void LateUpdate()
    {
        if(gameManager.isGameOver == false)
        {
            Move(); 
        }
    }

    private void Move()
    {
        if(gameManager.KillCount > 0)
        {
            moveSpeed = 0.002f + ((gameManager.KillCount / 5) * 0.01f);
        }
        else
        {
            moveSpeed = 0.002f;
        }


        transform.Translate(new Vector2(moveSpeed, 0));
    }
}
