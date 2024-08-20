public class TastBotModel : TastModelUnit
{   

    public ScriptableDataBot _scriptableDataBot;

    public float MinDistansAttack;
    public TastBotModel(TastViewUnit view,ScriptableDataBot scriptableDataBot) : base(view)
    {
        _scriptableDataBot  = scriptableDataBot;
        MinDistansAttack = _scriptableDataBot.MinDistansAttack;
    }
}
