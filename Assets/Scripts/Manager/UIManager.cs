using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Count;
    [SerializeField] private Slider hpSlider;
    [SerializeField]private GameObject GameOverUI;

    GameManager gameManager;
    private void Awake()
    {
        this.gameManager = GameManager.Instance;
    }

    public void ChangeKillCount(int killCount)
    {
        Count.text = killCount.ToString();
    }

    public void UpdateHPSlider(float percentage)
    {
        hpSlider.value = percentage;
    }

    public void SetGameOverUI()
    {
        GameOverUI.SetActive(true);
    }
}
