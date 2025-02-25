using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    private BaseController baseController;
    private StatHandler statHandler;
    private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statHandler.Health;

    private Action<float> OnChangeHealth;

    private void Awake()
    {
        baseController = GetComponent<BaseController>();
        statHandler = GetComponent<StatHandler>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    private void Start()
    {
        CurrentHealth = statHandler.Health;
    }

    private void Update()
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                animationHandler.DamageFinish();
            }
        }
    }

    public void ChangeHealth(float change)
    {
        if (change == 0 || timeSinceLastChange < healthChangeDelay)
        {
            return;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        OnChangeHealth?.Invoke(CurrentHealth/MaxHealth);

        if (change < 0)
        {
            animationHandler.Damage();
        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }

    }
    private void Death()
    {
        baseController.Death();
    }

    public void AddHealthChageEvent(Action<float> action)
    {
        OnChangeHealth += action;
    }

    public void RemoveHealthChangeEvent(Action<float> action)
    {
        OnChangeHealth -= action;
    }
}
