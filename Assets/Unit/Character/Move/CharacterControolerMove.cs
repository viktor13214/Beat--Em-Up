using UnityEngine;

public class CharacterControolerMove : Move
{
    private UnityEngine.CharacterController _characterController; // пришлось явно указывать,так-как создал класс с именем CharacterController,виновт.
    
    void Start()
    {
        _characterController = GetComponent<UnityEngine.CharacterController>(); 
    }
    public override void Moving() // этот класс пустышка пока не придумал ему реализацию,но думаю так будет лучше
    {
    }
    void FixedUpdate()
    {
       _characterController.Move(new Vector3(MoveDir.x,0,MoveDir.y) * _speed);

        Velocity = MoveDir.x + MoveDir.y; // меняем скорость 

        if(MoveDir.x != 0 || MoveDir.y != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,90 * 
                                                 (Mathf.RoundToInt(Mathf.Clamp(-MoveDir.y,0,1)) * 2 + 
                                                 Mathf.RoundToInt(MoveDir.x)),transform.rotation.z)); // подбирал некую формула для более меннее нормально функционирования,хотел сделать все ондой строкой )
        }
    }
    public override void SetMoveDir(Vector2 moveDir)
    {
       MoveDir.x  = moveDir.x;
       MoveDir.y = moveDir.y;
    }
}
