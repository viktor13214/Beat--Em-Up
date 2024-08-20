using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveBot : MonoBehaviour // не стал наследовать от Move,так-как мне показалость,что тут не получится сделать нормальное наследование,а получится только нарушить принцип подстановки из SOLID
{
    public Action<float> OnChangeVelocity;

    private NavMeshAgent _navMeshAgent;
    
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

    private Transform _target;

    [SerializeField] private float _speed = 2f;
    

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
    }
    public void SetToTarget(Transform transform)
    {
        _target = transform;
    }
    void Update()
    {
        
        Velocity = _navMeshAgent.velocity.x + _navMeshAgent.velocity.z;
        if(_target == null) return;
        _navMeshAgent.SetDestination(_target.position);
    }



}
