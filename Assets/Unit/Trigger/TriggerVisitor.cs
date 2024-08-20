using UnityEngine;

public class TriggerVisitor : MonoBehaviour,IVistior // приходится унаследоватся от монобеха чтобы определать на TryGetComponent,возможно этого можно было избежать
{
    private CharacterController _characterController;
    private HealthController _healthController;

    public void Init(ref CharacterController characterController,ref HealthController healthController) // метод инициализации
    {
        _characterController = characterController;
        _healthController = healthController;
    }
    public void Visit(FistControllerWeapon fistControllerWeapon,float Damage) // ну и соблюдаю контракт и соотвественно создаю свою реализаци,для бота например может быть что-то другое
    {
        _healthController.Damage(Damage);
        _characterController.Failed(fistControllerWeapon.GetLayerName());
    }
}
