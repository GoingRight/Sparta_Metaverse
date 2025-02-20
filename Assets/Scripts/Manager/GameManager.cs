using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public PlayerController player { get; private set; }
    public ResourceController _playerResource;
    private EnemyManager enemyManager;
    private UIManager uiManager;
    private int killCount = 0;
    private int BestScore = 0;
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

        Debug.Log(player.name);
        //enemyManager = FindObjectOfType<EnemyManager>();
        //enemyManager.Init(this);
        uiManager = FindObjectOfType<UIManager>();

        _playerResource = player.GetComponent<ResourceController>();
        _playerResource.RemoveHealthChangeEvent(uiManager.UpdateHPSlider);
        _playerResource.AddHealthChageEvent(uiManager.UpdateHPSlider);
    }

    public void KillCountPlus()
    {
        KillCount++;
        uiManager.ChangeKillCount(KillCount);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        CheckBestScore();
        uiManager.SetGameOverUI();
    }

    public void CheckBestScore()
    {
        if (KillCount > BestScore)
        {
            BestScore = KillCount;
        }
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
