using UnityEngine;

public  abstract class AttackTrigger // этот класс определяет способ аттаки будь то через райкаст или оверлап.
{
    public abstract  Collider[] GameObjectsForTrigger(Transform transform ,GameObject gameObject,float size,LayerMask layerMask);
}
