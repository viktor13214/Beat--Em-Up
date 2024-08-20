using UnityEngine;
public abstract class TastModelUnit
{
    protected TastViewUnit view;

    private bool _isDeath; // мертва ли сущность 
    public bool IsDeath
    {
        get
        {
            return _isDeath;
        }
        set
        {
            _isDeath = value;
            
            if(IsDeath == false) return;
            view.Death();
        }
    }
    
    private float _velocity; // скорость сущности(это нужно для анимации)
    public float Velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = Mathf.Clamp(value,int.MinValue,int.MaxValue);

            view.SetVelocity(_velocity);
        }
    }
    
    public TastModelUnit(TastViewUnit view)
    {
        this.view = view;
    }

    public virtual void AnimationAttackSet(string layerName,int countCombo)
    {
        view.SetAnimaton(layerName,countCombo);
    }
    public virtual void AnimationDamageSet(string layerName)
    {
        view.SetAnimatonFailed(layerName);
    }
}
