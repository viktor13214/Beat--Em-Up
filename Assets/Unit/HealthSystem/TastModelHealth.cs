using System;
using UnityEngine;
public abstract class TastModelHealth
{
    private TastViewHealth view;

    public  Action OnDead; // ивент смерти который будем активировать если хп == 0

    private float _healthCount = 100f;

    private ScriptableDataHealth  _scriptableDataHealth;

    public float HealthCount
    {
        get
        {
            return _healthCount;
        }
        set
        {
            _healthCount = Mathf.Clamp(value,0,_scriptableDataHealth.HealthCount);

            view.ChangeUI(HealthCount);

            if(_healthCount <= 0)
            {
                OnDead?.Invoke();
                
            }
        }

    }

    public TastModelHealth(ref TastViewHealth view,ScriptableDataHealth scriptableDataHealth)
    {
        _scriptableDataHealth = scriptableDataHealth;

        this.view = view;
        HealthCount = scriptableDataHealth.HealthCount;
    }
}
