using System;
using UnityEngine;

public class EventNotificationService : MonoBehaviour
{
    public event Action OnEnableEvent;

    public event Action OnDisableEvent;
    
    void OnEnable()
    {
        OnEnableEvent?.Invoke();
    }
    void OnDisable()
    {
        OnDisableEvent?.Invoke();
    }
}
