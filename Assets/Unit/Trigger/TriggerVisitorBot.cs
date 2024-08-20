using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVisitorBot : MonoBehaviour,IVistior //опять же из-за того что не создал родительский класс для Контроллеров,приходится создавать разные
{
    private BotController _botController;
    private HealthController _healthController;

    public void Init(ref BotController botController,ref HealthController healthController) // метод инициализации
    {
        _botController = botController;
        _healthController = healthController;
    }
    public void Visit(FistControllerWeapon fistControllerWeapon,float Damage) // ну и соблюдаю контракт и соотвественно создаю свою реализаци,для бота например может быть что-то другое
    {
        _healthController.Damage(Damage);
        _botController.Failed(fistControllerWeapon.GetLayerName());
    }
    
}
