using UnityEngine;
using System;
using System.Threading.Tasks;
public class StateAttack : State
{
    private TastControllerWeapon _currentWeapon;
    private float _forvat;

    private Transform _targetAttack;

    private readonly float _minDistansAttack;    // дистанция с которой игрок будет аттаковать 
    private readonly int _delayAttack = 1; // по хорошему надо прокинуть через ScriptableObject

    public Action<TastControllerWeapon> OnAttack;

   
      
     public StateAttack(StateMachine stateMachine,TastControllerWeapon weapon,Transform target,float MinDistansAttack) : base(stateMachine)
    {
        _currentWeapon = weapon;
        _targetAttack = target;

        this._minDistansAttack = MinDistansAttack;
        
    }
    public override void Enter()
    {
        base.Enter();
        WeaponAttack();
    }

    public override void Update()
    {
        if(Vector3.Distance(stateMachine.transform.position,_targetAttack.position) > _minDistansAttack) stateMachine.SetState<StatePursue>();
        
    }
     
    async void  WeaponAttack()
    {
        
        
        await Task.Delay(1000 * _delayAttack);
        if(stateMachine == null || !stateMachine.gameObject.activeInHierarchy || _targetAttack == null ||
          !_targetAttack.gameObject.activeInHierarchy || stateMachine == null) return; 

         Vector3 posTarget = _targetAttack.position - stateMachine.transform.position;

        _forvat  = Mathf.Atan2(posTarget.x,posTarget.y) * Mathf.Rad2Deg; // градусы для поворота

        stateMachine.transform.rotation = Quaternion.Euler(0,_forvat,0);

        if(_currentWeapon.Attack(stateMachine.gameObject.layer))
        {
            OnAttack?.Invoke(_currentWeapon);
        }

        WeaponAttack();
    }
}