using System.Linq;
using UnityEngine;

public class WeaponFabric : MonoBehaviour
{
    [SerializeField] private ScriptableWeaponFabric weaponFabric; // тоже можно будет через DI прокидывать например,но пока вот так)

    private Pool _poolObject;
    public TastControllerWeapon SpawnWeapon(Transform point,Quaternion rotation,WeaponList weaponList,ref Pool poolObject)
    {
            WeaponScriptable weaponType = weaponFabric.weaponScriptables.Where(x => x.weaponList.ToString() == 
                                                                              weaponList.ToString()).First();

            if(weaponType._view == null) return null;
            
            _poolObject = poolObject;

            PoolObject weapon =  _poolObject.GetFreeElement(weaponType._view.GetComponent<PoolObject>(),point.position,rotation);
           
            TastViewWeapon _view = weapon.GetComponent<TastViewWeapon>();

            switch(weaponList.ToString()) //не самое лучше проверять на switch так-как может жестко разростить,думал сделать динамическое определенние типов,но немного забыл как это делал
            {
                case "Fist":
                    TastModelWeapon tastModelWeapon = new FistModelWeapon(ref _view,weaponType.Weapon);
                    TastControllerWeapon  controller = new FistControllerWeapon(ref tastModelWeapon,new OverlapTrigger(),_view.transform);
                    return controller;
                
            }
            return null;
    }
}
