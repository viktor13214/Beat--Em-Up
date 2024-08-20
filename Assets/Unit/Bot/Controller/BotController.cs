using UnityEngine;

public class BotController 
{
    private TastBotModel _model; // я не наруаю принцип подстановки,так-как в этом классе я определенном понимаю что мне нужен бот котроллер иначе будет некоректно работаь

    private MoveBot _moveBot;

    private TastControllerWeapon _currentWeapon;

    private DeathLogic _deathLogic;

    private StateMachine _stateMachine;

    private EventNotificationService _eventNotificationService;

    private StateAttack _stateAttack;
    
    /* почему то не стал создавать родительский класс например TastController не могу объяснить свое поведение,но щас уже устал
    тут очень много повторяющегося кода */
    public BotController(TastBotModel tastModelUnit,TastControllerWeapon tastControllerWeapon,MoveBot moveBot,
                        ref DeathLogic deathLogic,StateMachine stateMachine,Transform target,
                        ref EventNotificationService eventNotificationService)
    {
        _model = tastModelUnit;
        _moveBot = moveBot;
        _currentWeapon = tastControllerWeapon;  
        _stateMachine = stateMachine;
        _deathLogic = deathLogic;
        _eventNotificationService = eventNotificationService;


        
        _stateAttack = new StateAttack(_stateMachine,_currentWeapon,target,_model.MinDistansAttack);
    
        _stateMachine.AddState(new StatePursue(_stateMachine,_moveBot,target,_model.MinDistansAttack));
        _stateMachine.AddState(_stateAttack);
    
        _stateMachine.SetState<StatePursue>();
        
        _stateAttack.OnAttack += AttackWeapon;

        _moveBot.OnChangeVelocity += ChangeVelocity;
        _deathLogic.OnDeath += DeathBoolChange;

        _currentWeapon.SetParent(_moveBot.transform);

        eventNotificationService.OnEnableEvent += OnEnable;
        eventNotificationService.OnDisableEvent += OnDisable;
    }
    private void OnEnable()
    {
        _stateAttack.OnAttack += AttackWeapon;

        _moveBot.OnChangeVelocity += ChangeVelocity;
        _deathLogic.OnDeath += DeathBoolChange;

        if(_currentWeapon == null) return; 
        _currentWeapon.SetParent(_moveBot.transform);
    }
   private void OnDisable()
   {
        _currentWeapon = null;
         _stateAttack.OnAttack -= AttackWeapon;

        _moveBot.OnChangeVelocity -= ChangeVelocity;
        _deathLogic.OnDeath -= DeathBoolChange;
   }


   public void ChangeVelocity(float velocity) => _model.Velocity = velocity;
 
   public void DeathBoolChange() =>  _model.IsDeath = true;



   private void AttackWeapon(TastControllerWeapon weapon) // метод для вызова(мы специально создаем метод,так-как оружие может поменятся и если это будет происходить не черз метод у нас не будет отписки)
   {
        _model.AnimationAttackSet(weapon.GetLayerName(),weapon.GetCountCombo());
   }
   public void Failed(string LayerName) // в будуйщем думаю этот метод пригодится не только как костыль )
   {
    _model.AnimationDamageSet(LayerName);
   }

   public DeathLogic GetDeath()  // тоже некий костыль
   {
    return _deathLogic;
   }
}
