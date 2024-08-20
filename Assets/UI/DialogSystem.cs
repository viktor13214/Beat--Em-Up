using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Lang _lang;
    [SerializeField] private TMP_Text TextBlock;
    [SerializeField][TextArea(3,10)]private List<string> dialogTextRu = new List<string>();

    [SerializeField][TextArea(3,10)]private List<string> dialogTextEn = new List<string>();
    

    [SerializeField] private float timeTextActive = 2f;

    public Action endDialog;



    public int TextNumber
    {
        get
        {
            return _textNumbre;
        }
        set
        {
            _textNumbre = Mathf.Clamp(value,0,dialogTextRu.Count);
        }
    }
    private int _textNumbre;

    private Input _controlsInput;

    void Awake()
    {
        _controlsInput = new Input();
    }
   
    void OnEnable()
    {
      
        _controlsInput.Enable();
    }
     void OnDisable()
    {
        _controlsInput.Disable();
    }

     void Start()
     {
        
        _controlsInput.InputAny.Click.started += ctx => ChangeDialog(ctx);
     }

   
    private void ChangeDialog(InputAction.CallbackContext context)
    {
        
        
        if(TextNumber >= dialogTextRu.Count ) 
        {
            endDialog?.Invoke();
            gameObject.SetActive(false);
            return;    
        }
        string textDialog = string.Empty;

        if(_lang.ToString() == "ru") textDialog = dialogTextRu[TextNumber];

        else textDialog = dialogTextEn[TextNumber];
        

        TextBlock.text = string.Empty;

        foreach(char c in textDialog)
        {
            TextBlock.text += c;
        }  
        TextNumber++;
    }
  /*  IEnumerator DialogStart()
    {


        yield break;
    }*/
}
