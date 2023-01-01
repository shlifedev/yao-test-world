using System.Collections.Generic;
using UnityEngine;
namespace Assets.Game.YaoCore.Game.CharacterController
{
    [System.Serializable]
    public class ControllerStateMachine
    {
        public readonly Animator animator;

        public ControllerStateMachine(Animator animator)
        {
            this.animator = animator;
        }
    }

    public class State
    {
        public ControllerStateMachine Root { get; }

        public State(ControllerStateMachine root)
        {
            Root = root;
        }
        public virtual void Enter()
        {
            
        }

        public virtual void Update()
        {

        }

        public virtual void Exit()
        {

        }
    }

    public class IdleState : State
    {
        public IdleState(ControllerStateMachine root) : base(root)
        {
        }

        protected void StateTick()
        { 
        }
    }
     
    class CController : UnityEngine.MonoBehaviour
    {
        public UnityEngine.CharacterController controller;
        public Animator animator;



        const float gravity = 9.81f;
        public float moveSpeed = 3.0f;
        private bool groundedPlayer;
        private Vector3 playerVelocity;
        void UpdateGravity()
        {
            controller.Move(new Vector3(0, -gravity * Time.deltaTime, 0));
        }
        void UpdateJump()
        {

        }
        public void Movement(Vector2 dir)
        {
            var moveDirection = dir * moveSpeed * Time.deltaTime;
            controller.Move(moveDirection);
        }


        public void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                controller.Move(transform.forward * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                controller.Move(-transform.forward * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                controller.Move(transform.right * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                controller.Move(-transform.right * Time.deltaTime * moveSpeed);
            }

            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * moveSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            if (Input.GetKey(KeyCode.Space)&& groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(100 * -3.0f * gravity);
            }
            

            playerVelocity.y -= gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}
