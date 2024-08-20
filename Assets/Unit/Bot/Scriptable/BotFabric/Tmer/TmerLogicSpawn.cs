using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerLogicSpawn 
{
    private ScriptableLogicSpawnConfing _scriptableLogicSpawnConfing;

    public Action<int> stageApply;

    private float _time;

    public float Times
    {
        get
        {
            return _time;
        }
        set
        {
            _time = Mathf.Clamp(value,0,_scriptableLogicSpawnConfing.time.Max());
            
        }
    }

    private int _stage = 0;

    public int Stage
    {
        get
        {
            return _stage;
        }
        set
        {
            _stage = Mathf.Clamp(value,0,_scriptableLogicSpawnConfing.time.Count);
            if(_stage >= _scriptableLogicSpawnConfing.time.Count)
            {
                _stage = 0;
                Times = 0;
            }
        }
    }   
    
    
    public TimerLogicSpawn(ScriptableLogicSpawnConfing scriptableLogicSpawnConfing)
    {
        _scriptableLogicSpawnConfing = scriptableLogicSpawnConfing;
    }
    
    public void Update()
    {
        Times += Time.deltaTime / 2;
        Debug.Log(Mathf.Approximately(Times,_scriptableLogicSpawnConfing.time[Stage]));
        if(Mathf.Abs(Times - _scriptableLogicSpawnConfing.time[Stage]) < 0.2)
        {
            stageApply?.Invoke(_scriptableLogicSpawnConfing.countBot[Stage]);
            Stage++;
            Debug.Log("hell");
        }
    }
    
}
