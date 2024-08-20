using UnityEngine;


[CreateAssetMenu(menuName = "Weapon/WeaponScriptable")]
public class WeaponScriptable : ScriptableObject 
{
    public ScriptableModelWapon Weapon; //  конфиг для оружия

    public TastViewWeapon _view; // его так-сказать экземпляр

    public WeaponList weaponList; // и тип его анимации
}
