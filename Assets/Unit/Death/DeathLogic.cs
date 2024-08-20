using System;

public abstract class DeathLogic
{
    public event Action OnDeath;
    public DeathLogic(ref Action Death)
    {
       Death += OnDeathInvoke;
    }    
    private void OnDeathInvoke()
    {
        OnDeath?.Invoke();
    }

}
