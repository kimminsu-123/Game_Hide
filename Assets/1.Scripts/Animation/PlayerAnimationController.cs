using System;
using Com.Hide.Player.Status;
using UnityEngine;

namespace Com.Hide.Player.Animation
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField]
        protected PlayerStatusHandler playerStatusHandler;
        protected Animator Animator => _animator;

        private Animator _animator;
        
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}