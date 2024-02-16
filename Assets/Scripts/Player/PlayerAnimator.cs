using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   [SerializeField] private Animator _animator;

   private PlayerMover _mover;
   private InputReader _input;
   
   private void Awake()
   {
      _mover = GetComponent<PlayerMover>();
      _input = GetComponent<InputReader>();
   }
    
   private void Update()
   {
       _animator.SetBool("isGrounded", _mover.IsGrounded);
       _animator.SetFloat("vertical", _input.Vertical);
       _animator.SetFloat("horizontal", _input.Horizontal);
   }
}
