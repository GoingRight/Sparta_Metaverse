using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    private PlayerController player;
    private int killCount = 0;
    public bool isGameOver = false;
    public int KillCount { get { return killCount; } set { killCount = value;} }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        player = FindObjectOfType<PlayerController>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
    }
}
