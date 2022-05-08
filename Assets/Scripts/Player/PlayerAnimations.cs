using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerController.farDistance)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
