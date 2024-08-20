using UnityEngine;
[RequireComponent(typeof(Animator))]
public abstract class TastViewUnit : MonoBehaviour
{
    private Animator animator;
    
    void Awake()
    {
      animator = GetComponent<Animator>();
    }

  public void SetVelocity(float Velocity)
  {
     animator.SetFloat("Velocity",Velocity);
  }

   public virtual void Death()
   {
     gameObject.SetActive(false); // по хорошему тут надо наверное создать,какой нибудь DeathView и вызывать его тут передавая некие параметры
   }
    public virtual void SetAnimaton(string animatonLayer,int CountCombo)
    {      
       animator.SetLayerWeight(animator.GetLayerIndex(animatonLayer),1);

       animator.SetFloat("Attack",CountCombo);
       animator.SetTrigger("AttackTrigger");
    }
    public virtual void SetAnimatonFailed(string animatonLayer)
    {
       animator.SetLayerWeight(animator.GetLayerIndex(animatonLayer),1);

       animator.SetTrigger("Failed"); 
    }
}
