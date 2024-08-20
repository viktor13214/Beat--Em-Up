public class CharacterController
{
    private TastModelCharacter _model; // Модель игрока 

    private IInput _input; // получаем управления

    private Move _move; // логика передвижение игрока

    private DeathLogic _deathLogic; // тут будет оповещение о смерти игрока

    private EventNotificationService _eventNotificationService; // сервис

    private TastControllerWeapon _currentWeapon; // оружие

  
  public  CharacterController(ref TastModelCharacter model,ref IInput input,ref Move move,ref DeathLogic deathLogic,
                              ref TastControllerWeapon weapon,ref EventNotificationService eventNotificationService)
  {
    _model = model; 
    _input = input;
    _move = move;
    _deathLogic = deathLogic;
    _currentWeapon = weapon;

    _eventNotificationService = eventNotificationService;

    _input.OnChangeMoveDir += _move.SetMoveDir; // подписываем на обновления данных чтобы игрок двигался
    _input.WeaponAttackStart += AttackWeapon; // подписываемся на нажатие кнопки атаки 


    _move.OnChangeVelocity += ChangeVelocity; // передаем в model скорость игрока,для его последующей анимации
    _deathLogic.OnDeath +=  DeathBoolChange; // подписываемся на событие смерти

    _currentWeapon.SetParent(_move.gameObject.transform);

    eventNotificationService.OnEnableEvent += OnEnable;
    eventNotificationService.OnDisableEvent += OnDisable; // и подписываемся для дальнейшей отписки при отключении объекта
  }

    private void OnEnable()
    {
        _currentWeapon.SetParent(_move.transform);

        _input.OnChangeMoveDir += _move.SetMoveDir; // подписываем на обновления данных чтобы игрок двигался
        _input.WeaponAttackStart += AttackWeapon; // подписываемся на нажатие кнопки атаки 


        _move.OnChangeVelocity += ChangeVelocity; // передаем в model скорость игрока,для его последующей анимации
        _deathLogic.OnDeath +=  DeathBoolChange; // подписываемся на событие смерти

        if(_currentWeapon == null) return; 
        _currentWeapon.SetParent(_move.transform);
    }
   private void OnDisable() 
   {
      _currentWeapon = null;

    _input.OnChangeMoveDir -= _move.SetMoveDir;
    _input.WeaponAttackStart -=  AttackWeapon;

    _move.OnChangeVelocity -= ChangeVelocity; 
    _deathLogic.OnDeath -=  DeathBoolChange; 

    

    _eventNotificationService.OnDisableEvent -= OnDisable; // отписываемся
   }

   public void ChangeVelocity(float velocity) => _model.Velocity = velocity;
 
   public void DeathBoolChange() =>  _model.IsDeath = true;

   private void AttackWeapon() // метод для вызова(мы специально создаем метод,так-как оружие может поменятся и если это будет происходить не черз метод у нас не будет отписки)
   {
      if(_currentWeapon.Attack(_move.gameObject.layer))
      {
        _model.AnimationAttackSet(_currentWeapon.GetLayerName(),_currentWeapon.GetCountCombo());
      }
   }
   public void Failed(string LayerName) // в будуйщем думаю этот метод пригадится не только как костыль )
   {
    _model.AnimationDamageSet(LayerName);
   }

    
}

