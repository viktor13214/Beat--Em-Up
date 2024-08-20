using System.Linq;
using UnityEngine;

public class BotFabric : MonoBehaviour // это просто повторения кода к сожалению,я просто немного устал
{
    [SerializeField] private ScriptableBotFabric scriptableBotFabric;

    private Pool _poolObject;
    

    public BotController SpawnBot(Transform point,Quaternion rotation,BotList botList,TastControllerWeapon tastControllerWeapon,
                                  ScriptableDataHealth scriptableDataHealth,Transform target,ref Pool poolObject)
    {
            
            ScriptableBot scriptableBot = scriptableBotFabric.scriptableBots.Where(x => x.botList.ToString() == 
                                                                                  botList.ToString()).First();

            _poolObject = poolObject;

            PoolObject bot =_poolObject.GetFreeElement(scriptableBot._view.GetComponent<PoolObject>(),point.position,rotation);
            if(bot == null)
            {
                throw new System.Exception("нету пула на боте )"); 
            }

            TastViewUnit view = bot.GetComponent<TastViewUnit>();

            MoveBot _move = view.gameObject.GetComponent<MoveBot>(); 
            
           

            EventNotificationService _eventNotificationService = view.gameObject.GetComponent<EventNotificationService>(); 

            StateMachine stateMachine = view.GetComponent<StateMachine>();


            
            TastViewHealth _viewHealth = view.gameObject.GetComponent<TastViewHealth>(); 

            TastDamageCalculator tastDamageCalculator = new BasicDamageCalculator(); 

            TastModelHealth _modelHealth = new ModelHealth(_viewHealth,scriptableDataHealth); 
            HealthController _healthController = new HealthController(ref _modelHealth,ref tastDamageCalculator); 


            DeathLogic _deathLogic = new DeathCharacterLogic(ref _modelHealth.OnDead);

            switch(botList.ToString()) //не самое лучше проверять на switch так-как может жестко разростить,думал сделать динамическое определенние типов,но немного забыл как это делал
            {
                case "TastBot":
                   
                    TastBotModel tastBotModel = new TastBotModel(view,scriptableBot.scriptableDataBot);
                    BotController botController = new BotController(tastBotModel,tastControllerWeapon,_move,ref _deathLogic,stateMachine,target,ref _eventNotificationService);

                  TriggerVisitorBot  triggerVisitor = view.gameObject.GetComponent<TriggerVisitorBot>();
                  triggerVisitor.Init(ref botController,ref _healthController);
                  return botController;
            }
            return null;
    }
   
}
