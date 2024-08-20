using UnityEngine;

[CreateAssetMenu(menuName = "TastModelWapon/ScriptableModelWapon")]
public class ScriptableModelWapon : ScriptableObject // некий конфинг
{
    public LayerMask triggerLayerMask;
    public AnimatonLayer animatonLayer;

    public float Delay; // задержка
    public int countCombo; // количество сколько комбо в оружии
    public float Damage; // дамаг
}

