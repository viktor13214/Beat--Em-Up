using System;
using UnityEngine;

public abstract class Move : MonoBehaviour // спомощью этого класса мы обертываем все абастракцию,например для того чтобы в будующем заменить characterMove на RigidBodyMove типо таво)
{
    [SerializeField]protected float _speed;

    private float _velocity; 
    public float Velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = value;
            OnChangeVelocity?.Invoke(_velocity);
        }
    }
    public Action<float> OnChangeVelocity;


    public Vector2 MoveDir; // направление движения

    public event Action<Vector2> OnSetMoveDir;

    public abstract void Moving(); 
    
    public abstract void SetMoveDir(Vector2 moveDir); // тут будем устанавлять MoveDir
}

