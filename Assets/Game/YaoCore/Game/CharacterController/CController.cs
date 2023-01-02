using System.Collections.Generic;
using UnityEngine;
namespace Assets.Game.YaoCore.Game.CharacterController
{  
     
    class CController : UnityEngine.MonoBehaviour
    {
        [SerializeField] private Transform forwardReferenceCamera;
        [SerializeField] private UnityEngine.CharacterController controller;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform root; 
        [SerializeField] private Vector2 planeInputDir;
        public Transform Root
        {
            get
            {
                if (root) return root;
                return this.transform;
            }
        }
        

        const float gravity = 9.81f;
        public float moveSpeed = 3.0f;
         
        /// <summary>
        /// 캐릭터가 카메라 전면을 바라보게한다.
        /// </summary>
        public void LookForward()
        {
            var virtualPos = forwardReferenceCamera.transform.position;
            virtualPos.y = this.transform.position.y;
            var dir = virtualPos - this.transform.position;
            var dirNormalize = dir.normalized;
            this.transform.LookAt(this.transform.position - dirNormalize);
        }
        void UpdateGravity()
        {
            controller.Move(new Vector3(0, -gravity * Time.deltaTime, 0));
        } 

        void UpdateMoveInput()
        {
            if (Input.GetKey(KeyCode.W))
            {
                controller.Move((Root.forward * moveSpeed) * Time.deltaTime);
                animator.SetBool("movement", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                controller.Move((-Root.forward * moveSpeed) * Time.deltaTime);
                animator.SetBool("movement", true);
            }
            if (Vector2.zero == planeInputDir)
                animator.SetBool("movement", false);
        }


        public void Update()
        {
            UpdateGravity();
            LookForward(); 
            planeInputDir = new Vector2(Mathf.Ceil(Input.GetAxis("Horizontal")), Mathf.Ceil(Input.GetAxis("Vertical")));
            // 임시처리
            UpdateMoveInput();
        }
    }
}
