using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private TastViewCharacter _view; 

    private CharacterController _controller; // контроллер персонажа
    private TastModelCharacter _model;// модель персонажа


    [SerializeField]private ScriptableDataHealth scriptableDataHealth;

    private TastViewHealth _viewHealth;
    private HealthController _healthController; // контроллер жизни
    private TastModelHealth _modelHealth; // модель жинзи

    private TastDamageCalculator tastDamageCalculator; // и калькулятор дамага в будующем можно будет прагидывать через DI.


    private Move _move; // тип движения игрока
    [SerializeField] private Transform point;

    private TriggerVisitor triggerVisitor; // триггер игрока,что-бы он реагировал на атаку и в будующем на другие предметы например на различные item
    private EventNotificationService _eventNotificationService; // сервис отписки ивентов
    private DeathLogic _deathLogic; //локига смерти


    

    
    public GameObject InitPlayer(ref IInput input,ref TastControllerWeapon ControllerWeapon,ref CustomSlider customSlider) // метод для создания игрока
    {
         TastViewCharacter view  = Instantiate(_view,point.transform.position,point.transform.rotation); // создаем игрока и получаем ссылку на view

        _move = view.gameObject.GetComponent<Move>(); //получаем _move с игрока
        
        _viewHealth = view.gameObject.GetComponent<TastViewHealth>(); // получаем хп с игрока

        _eventNotificationService = view.gameObject.GetComponent<EventNotificationService>(); // ну и собственно наш сервис
        // по хорошему это все надо было бы проверить на null и если то выкинуть ошибку
        
         tastDamageCalculator = new BasicDamageCalculator(); // сейчас это сделано костыльно,и не гибко но я просто решил так-сделать,так-сказать на будующее

        _modelHealth = new ModelHealth(_viewHealth,scriptableDataHealth); // создаем modelHealth для игрока
        _healthController = new HealthController(ref _modelHealth,ref tastDamageCalculator); // создаем _helathController для игрока
        _viewHealth.Init(customSlider,_modelHealth.HealthCount);

        _deathLogic = new DeathCharacterLogic(ref _modelHealth.OnDead); // создаем локигу смерти,в будующем я смогу "убивать" игрока например просто прокинув action от таймера например


        // ниже инициализация MVC - Игрока
        _model = new TastModelCharacter(view); 
        _controller = new CharacterController(ref _model,ref input,ref _move,ref _deathLogic,ref ControllerWeapon,ref _eventNotificationService);
        // и инициализируем  триггер 
        triggerVisitor = view.gameObject.GetComponent<TriggerVisitor>();
        triggerVisitor.Init(ref _controller,ref _healthController);

        // возвращаем объект для прокидывания например в камеру
        return view.gameObject;
    }
    
}
