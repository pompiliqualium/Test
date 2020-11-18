using UnityEngine;
using UnityEngine.Events;

public class CharacterAnimations : MonoBehaviour
{
    public Animator animator;
    public Character character;
    public UnityEvent @event;


    public float horizontalMove = 0;
    public bool jump = false;
    public bool duck = false;

    public enum CharacterAnimationStates
    {
        Idle,
        Run,
        Jump
    }

    public class CharacterAnimationController
    {
        public void SetCurrentState(CharacterAnimationStates state) {

        }
    }

    private void Awake() {
        @event.AddListener(() => Debug.Log("ва"));

    }



    void Update() {
        horizontalMove = Input.GetAxis("Horizontal") * character.Speed;
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if(Input.GetKeyDown("w")) {
            animator.SetBool("Jump",true);
        }
        if(Input.GetKeyDown("s")) {
            animator.SetBool("Duck",true);
        }
        if(Input.GetKeyUp("s")) {
            animator.SetBool("Duck",false);
        }
        if(Input.GetKeyUp("w")) {
            animator.SetBool("Jump",false);
        }

        if(character.isGrounded == true) {
            animator.SetBool("IsGrounded",true);
        } else {
            animator.SetBool("IsGrounded",false); ;
        }


    }
}
