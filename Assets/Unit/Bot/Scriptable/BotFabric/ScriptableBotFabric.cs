using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Bot/ScriptableBotFabric")]
public class ScriptableBotFabric : ScriptableObject
{
    public List<ScriptableBot> scriptableBots; // типы ботов
}
