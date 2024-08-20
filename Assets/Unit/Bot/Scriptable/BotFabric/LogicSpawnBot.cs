using System.Collections.Generic;
using UnityEngine;

public class LogicSpawnBot : MonoBehaviour
{
   [SerializeField] private BotFabric botFabric;
   
   [SerializeField] private WeaponFabric weaponFabric;
   
   [SerializeField] private ScriptableBotFabric scriptableBotFabric;

   [SerializeField] private List<Transform> transformsList = new List<Transform>();

   [SerializeField] private List<ScriptableDataHealth> scriptableDataHealths = new List<ScriptableDataHealth>(); 

   [SerializeField] private ScriptableLogicSpawnConfing scriptableLogicSpawnConfing;

    private List<DeathLogic> deathLogics = new List<DeathLogic>();

    private int countBot;  // действующее количество ботов
    private Transform _target; // цель на которую боты будут бежать

    private TimerLogicSpawn timerLogicSpawn; // таймер

    private Pool _poolObject; // пул

   void Awake()
   {
      botFabric  = GetComponent<BotFabric>();

      timerLogicSpawn = new TimerLogicSpawn(scriptableLogicSpawnConfing);
      timerLogicSpawn.stageApply += Spawn;
   }
   void OnDisable() => timerLogicSpawn.stageApply -= Spawn;

   void Update() => timerLogicSpawn.Update();

    public void Init(Transform target,ref Pool poolObject)
    {
        _target = target;
        _poolObject = poolObject;
    }
   public  void Spawn(int countBots)
   {
        int count = countBots - countBot; // необходимое количество ботов,что-бы достичь цели
        for(int i = 0;i < count;i++)
        {
            countBot++;

            Transform pointSpawn = transformsList[Random.Range(0,transformsList.Count)];
            TastControllerWeapon currentWeapon = weaponFabric.SpawnWeapon(pointSpawn,pointSpawn.rotation,WeaponList.Fist,ref _poolObject);
            BotController botController = botFabric.SpawnBot(pointSpawn,pointSpawn.rotation,BotList.TastBot,currentWeapon,scriptableDataHealths[0],_target,ref _poolObject);

            deathLogics.Add(botController.GetDeath());
            botController.GetDeath().OnDeath += BotDeath;
        }
   }
   public void  BotDeath()
   {
     countBot--;
   }
}
