using System.Threading.Tasks;
using UnityEngine;

public class FistControllerWeapon : TastControllerWeapon
{
   
   public FistControllerWeapon(ref TastModelWeapon model,AttackTrigger attackTrigger,Transform transform) : base(ref model,ref attackTrigger,transform)
   {
   }

    public override bool Attack(LayerMask layerMask)
    {
        if(_model.IsAttack == true) return false;

        _model.IsAttack = true;
        _model.CountCombo++;

        StopAttack();
        Collider[] colliders = _attackTrigger.GameObjectsForTrigger(_transform.gameObject.transform,_transform.gameObject,1f,_model._triggerLayerMask);
        
        foreach(Collider collider in colliders )
        {
            if(collider.TryGetComponent<IVistior>(out IVistior vistior) && collider.gameObject.layer != layerMask)
            {
                vistior.Visit(this,_model.Damage);
            }
        }  
        return true;
    }

    public async override void StopAttack()
    { 
       await Task.Delay(1000 * (int)_model.Delay);
       _model.IsAttack = false;
       await Task.Delay(1000 * 1);
       _model.CountCombo--;
    }

}
