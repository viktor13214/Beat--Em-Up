using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Bot/ScriptableLogicSpawnConfing")]
public class ScriptableLogicSpawnConfing : ScriptableObject
{
    public List<float> time; //время через которое будут спавнится боты

    public List<int> countBot; // сколько ботов должно быть
}
