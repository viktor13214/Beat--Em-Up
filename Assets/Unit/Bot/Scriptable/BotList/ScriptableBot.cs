
using UnityEngine;
[CreateAssetMenu(menuName = "Bot/Bot")]
public class ScriptableBot : ScriptableObject // это тип бота
{
   public ScriptableDataBot scriptableDataBot;

   public TastViewUnit _view;

   public BotList botList;
}
