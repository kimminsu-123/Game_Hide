using System.Diagnostics;
using Com.Hide.Player.Status;
using UnityEngine;
using Logger = Com.Hide.Utils.Logger;

namespace Com.Hide.Player.Movable
{
    public abstract class PlayerMoveController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] protected float runSpeed;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float jumpForce;
        
        [Header("Conditions")]
        [SerializeField] protected float groundCheckLineLength;
        [SerializeField] protected LayerMask groundLayerMask;
        
        [Header("Components")]
        [SerializeField] protected Transform cachedTr;
        [SerializeField] protected Rigidbody rigid;
        
        protected PlayerStatusHandler StatusHandler;
        protected bool IsGround;

        private void Awake()
        {
            OnAwake();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }

        protected virtual void OnAwake()
        {
            StatusHandler = GetComponent<PlayerStatusHandler>();
        }

        protected virtual void OnFixedUpdate()
        {
            Rotate();
            Move();

            CheckDetectGround();
            Jump();
        }

        protected abstract void Jump();
        protected abstract void Move();
        protected abstract void Rotate();

        private void CheckDetectGround()
        {
            IsGround = Physics.Raycast(cachedTr.position, Vector3.down, groundCheckLineLength, groundLayerMask);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, transform.position + transform.up * -groundCheckLineLength);
        }
    }
}