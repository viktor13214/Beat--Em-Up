using UnityEngine;
using Cinemachine;
public class EntryPoint : MonoBehaviour
{


    [SerializeField] private PlayerUI _playerUIPrefab;

    [SerializeField]private PlayerSpawn _playerSpawn;

    [SerializeField]private CinemachineVirtualCamera _camera;

    [SerializeField] private Transform _point;

    [SerializeField] private WeaponFabric _weaponFabric;

    [SerializeField] private LogicSpawnBot _logicSpawnBot;

    [SerializeField] private Pool _poolObject;


    private Transform _playerTransform;
    
    private PlayerUI _playerUI;
    private IInput _input;

    
    private void OnDisable() 
    {
        if(_playerUI == null) return;
        _playerUI.dialogSystem.endDialog -= BotInit;    
    }

    void Awake()
    {
        _playerUI = Instantiate(_playerUIPrefab,_playerUIPrefab.transform.position,_playerUIPrefab.transform.rotation);
        _playerUI.gameObject.SetActive(true);
        
        TastControllerWeapon weapon = _weaponFabric.SpawnWeapon(_point,_point.rotation,WeaponList.Fist,ref _poolObject);
        _input = new InputMobile(_playerUI.joystick,_playerUI.buttonAttack);

        GameObject player = _playerSpawn.InitPlayer(ref _input,ref weapon,ref _playerUI.customSlider);
        _point = player.transform;
        
        _playerTransform = player.transform;

        _camera.Follow = player.transform;

        _playerUI.dialogSystem.endDialog += BotInit;
        

    }

    

    void BotInit()
    {
        _logicSpawnBot.Init(_playerTransform.transform,ref _poolObject);
        _logicSpawnBot.Spawn(5);

        _playerUI.dialogSystem.endDialog -= BotInit;
    }
    
}
