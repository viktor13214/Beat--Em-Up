using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WeaponFabric/ScriptableWeaponFabric")]
public class ScriptableWeaponFabric : ScriptableObject
{
    public List<WeaponScriptable> weaponScriptables;
}
