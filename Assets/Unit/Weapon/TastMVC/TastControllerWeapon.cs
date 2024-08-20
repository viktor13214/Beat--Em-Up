using UnityEngine;

public abstract class TastControllerWeapon 
{
    protected TastModelWeapon _model; 

    protected AttackTrigger _attackTrigger; 

    protected Transform _transform; // по хорошему надо бы засунуть позицию в модель

    public TastControllerWeapon(ref TastModelWeapon model,ref AttackTrigger attackTrigger,Transform transform)
    {
        _model = model;
        _attackTrigger = attackTrigger;
        _transform = transform;
    }
    // некие костыли,что бы получать данные от модели,незнаю правильно ли это.Скорей всего нет,так-как я нарушаю некую инкапсуляция
    public string GetLayerName()
    {
        return _model._scriptableModelWapon.animatonLayer.ToString();   
    }
    public int GetCountCombo()
    {
        return _model.CountCombo;
    }

    public void SetParent(Transform parent)
    {
        _model.Parent = parent;
    }
    
    public abstract bool Attack(LayerMask ignore); 

    public abstract void StopAttack(); 

}
