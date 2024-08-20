using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler // реализовал просто слабенький джостик,довольно корявый,вообще лучше бы использоваль ассет но не хочу случайно нарушить инструкцию
{
    public Vector2 direct = Vector2.zero;

    private bool isClick = false;

    private Vector2 startPosition;

    private RectTransform _rectTransform;

    Input inputAction;

    void OnEnable()
    {
        inputAction = new Input();
        inputAction.Enable();

        _rectTransform = GetComponent<RectTransform>();
        startPosition = _rectTransform.position;
    }
    void OnDisable()
    {
        inputAction.Disable();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
         isClick = false;
         
         _rectTransform.position = startPosition;
         direct = Vector2.zero;
    }   

    void Update()
    {
        if(isClick == false) return;

        Vector2 dir = -startPosition + (inputAction.InputAny.ScreenPosition.ReadValue<Vector2>());
        direct = Vector3.Normalize(dir);

        if(Vector2.Distance(_rectTransform.position,(Vector2)startPosition + direct * 3000 * Time.deltaTime) > 25) // магические числа )
        {
            _rectTransform.position = (Vector2)startPosition + direct * 3000 * Time.deltaTime;
        }
    }
    public Vector2 GetDirect()
    {
        return direct;
    }

}
