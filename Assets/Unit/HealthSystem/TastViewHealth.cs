using UnityEngine.UI;
using TMPro;
using UnityEngine;

public abstract class TastViewHealth : MonoBehaviour
{
    private CustomSlider _healthSlider;
    
    public void Init(CustomSlider customSlider,float count)
    {
        _healthSlider = customSlider;
        _healthSlider.Init(count);
    }
    
    
    public void ChangeUI(float healthCount)
    {
        if(_healthSlider == null) return;
        _healthSlider.ChangeSlider(healthCount);
    }
}
