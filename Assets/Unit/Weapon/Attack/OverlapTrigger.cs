using UnityEngine;
public class OverlapTrigger : AttackTrigger // тут проверяем оверлапом
{
    public override Collider[] GameObjectsForTrigger(Transform transform ,GameObject gameObject,float size,LayerMask layerMask)
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position,size,layerMask); 
        return colliders;
    }
}
