using UnityEngine;
using UnityEngine.UI;
public class CustomSlider : MonoBehaviour
{
    private Image _slider;
    
    private float startValue;
    void Awake()
    {
        _slider = GetComponent<Image>();
    }

    public void Init(float value)
    {
        
        startValue = value;
        
    }

    public void ChangeSlider(float value)
    {
        _slider.fillAmount = value / startValue;
    }
}
