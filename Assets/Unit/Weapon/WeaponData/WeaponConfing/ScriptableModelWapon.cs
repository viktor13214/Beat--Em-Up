using UnityEngine;

[CreateAssetMenu(fileName = "TastModelWapon", menuName = "TastModelWapon", order = 0)]
public class ScriptableModelWapon : ScriptableObject // некий конфинг
{
    public LayerMask triggerLayerMask;
    public AnimatonLayer animatonLayer;

    public float Delay; // задержка
    public int countCombo; // количество сколько комбо в оружии
    public float Damage; // дамаг
}

