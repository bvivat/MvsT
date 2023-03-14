using UnityEngine;

public class animator_controller : MonoBehaviour
{

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void run(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
}