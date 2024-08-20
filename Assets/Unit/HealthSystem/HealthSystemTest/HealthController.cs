
public class HealthController
{
    private TastModelHealth _model;

    private TastDamageCalculator _damageCalculator;

    public HealthController(ref TastModelHealth model,ref TastDamageCalculator damageCalculator)
    {
        _model = model;
        _damageCalculator = damageCalculator;
    }
     
    public void Damage(float damage)
    {
        _model.HealthCount -= _damageCalculator.DamageCalculator(damage);
    }

}
