using System.Collections;
using Com.Hide.Input;
using Com.Hide.Player.Status;
using UnityEngine;

namespace Com.Hide.Player.Animation
{
    public class LocalPlayerAnimator : PlayerAnimationController, IPlayerStatusListener
    {
        [SerializeField]
        private PlayerInputHandler playerInputHandler;
        
        private readonly int _hashMove = Animator.StringToHash("Move");
        private readonly int _hashJump = Animator.StringToHash("Jump");
        private readonly int _hashDie = Animator.StringToHash("Die");

        private void Start()
        {
            playerStatusHandler.AddListener(this);
            StartCoroutine(UpdateCoroutine());
        }

        private IEnumerator UpdateCoroutine()
        {
            while (true)
            {
                ProcessMoveAnimation();
                
                yield return null;
            }
        }

        private void ProcessMoveAnimation()
        {
            var v = rigid.velocity.magnitude;
            Animator.SetFloat(_hashMove, v);
        }

        public void OnChangePlayerStatus(PlayerStatusEnum status)
        {
            switch (status)
            {
                case PlayerStatusEnum.Jump:
                    Animator.Play(_hashJump);
                    break;
                case PlayerStatusEnum.Die:
                    Animator.Play(_hashDie);
                    break;
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}