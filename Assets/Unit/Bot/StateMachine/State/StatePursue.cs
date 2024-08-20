using UnityEngine;

public class StatePursue : State
{
    private readonly MoveBot _move;
    private float _forvat;


    private Transform _target;
    private readonly float _minDistansAttack;

    public StatePursue(StateMachine stateMachine,MoveBot moveBot,Transform target,float MinDistansAttack) : base(stateMachine)
    {
        _move = moveBot;
        _target = target;

        this._minDistansAttack = MinDistansAttack;
    }

    public override void Update()
    {
        if(Vector3.Distance(stateMachine.transform.position,_target.position) <= _minDistansAttack) stateMachine.SetState<StateAttack>();
        else Pursue();
    }
    
    void Pursue()
    {
        if(stateMachine == null || !stateMachine.gameObject.activeInHierarchy || _target == null ||
           !_target.gameObject.activeInHierarchy || stateMachine == null) return; 

        _move.SetToTarget(_target);

         Vector3 posTarget = _target.transform.position - stateMachine.transform.position;

        _forvat  = Mathf.Atan2(posTarget.x,posTarget.y) * Mathf.Rad2Deg ;// градусы для поворота
        stateMachine.transform.rotation = Quaternion.Euler(0,_forvat,0);
    }
}