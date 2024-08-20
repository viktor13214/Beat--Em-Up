using System;
using UnityEngine;
public interface IInput 
{
    public Vector2 moveDir{get;set;}

    public event Action<Vector2> OnChangeMoveDir; // евент который будет запускатся при изменении moveDir

    public void SetMoveDir(); // метод где мы будем устанавливать moveDir

    public event Action OnJumpPressed;

    public event Action OnJumpUp;

    public event Action WeaponAttackStart;

    public event Action WeaponAttackEnd;
}
