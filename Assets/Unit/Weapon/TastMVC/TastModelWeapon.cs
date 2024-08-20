using UnityEngine;

public abstract class TastModelWeapon : MonoBehaviour
{

    private TastViewWeapon _view; 
    public ScriptableModelWapon _scriptableModelWapon; // некий конфинг оружия

   
    private int _countCombo; // количество комбо это показатель скоко раз игрок нажал кнопку атаки,сделна по факту сейчас для красивой анимации,но в будующем можно влиять на damage и все такое
    public int CountCombo
    {
        get
        {
            return _countCombo;
        }
        set
        {
            _countCombo = Mathf.Clamp(value,-1,_scriptableModelWapon.countCombo); // -1 для того чтобы можно было воспроизводить первую анимаю удара
            if(_countCombo >= _scriptableModelWapon.countCombo ) // тут сбрасываю 
            {
                _countCombo = 0;
            }
        }
    }
    
    
    private float _damage; // дамаг собственно
    public float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
    
    
    private bool _isAttack; // атакует ли оружие
    public bool IsAttack
    {
        get
        {
            return _isAttack;
        }
        set
        {
            _isAttack = value;
            if(_isAttack == true)
            {
                //вызываем например анимацию оружия или спавним эффект(для этого я бы наверно создал отдельный SpawnEffectService)
            }
        }
    }


    public float Delay; // задержка для оружия
    public LayerMask _triggerLayerMask; // маски на которые будет реагировать

    private Transform _parent;

    public Transform Parent
    {
        get
        {
            return _parent;
        }
        set
        {
            _parent = value;
            _view.SetParent(_parent);
        }
    }
    
    public TastModelWeapon(ref TastViewWeapon view,ref ScriptableModelWapon scriptableModelWapon)
    {
        _view = view;
        _scriptableModelWapon = scriptableModelWapon;

        // инициализируем все из конфига 
        Delay = _scriptableModelWapon.Delay;
        CountCombo = _scriptableModelWapon.countCombo;
        _damage = _scriptableModelWapon.Damage;
        _triggerLayerMask = scriptableModelWapon.triggerLayerMask;
    }
}
