using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class InputMobile : IInput
{
    
    private Vector2 _moveDir;

    public Vector2 moveDir
    {
        get
        {
            return _moveDir;
        }
        set
        {
            _moveDir = value;
            OnChangeMoveDir?.Invoke(_moveDir);
        }
    }
    public event Action<Vector2> OnChangeMoveDir;
    public event Action OnJumpPressed;
    public event Action OnJumpUp;

    public event Action WeaponAttackStart;

    public event Action WeaponAttackEnd;


    private Joystick joystick;

    private Button button;

    public InputMobile(Joystick joystick,Button button)
    {     
        this.joystick = joystick;
        this.button = button;
        SetMoveDir();
        button.onClick.AddListener(()=> WeaponAttackStart?.Invoke());
    }

    public async void SetMoveDir()
   {
        await Task.Delay(1 * 50);
        
        moveDir = joystick.GetDirect();
        SetMoveDir();
   }
}
