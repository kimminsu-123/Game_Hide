using Cinemachine;
using Com.Hide.Input;
using Com.Hide.Player.Status;
using UnityEngine;

namespace Com.Hide.Player.Movable
{
    public class LocalPlayerMoveController : PlayerMoveController
    {
        [SerializeField] private CinemachineVirtualCamera playerCam;

        private PlayerInputHandler _playerInput;
        
        private float _turnSmoothVelocity = 0f;
        private readonly float _smoothTime = 0.1f;

        protected override void OnAwake()
        {
            base.OnAwake();

            _playerInput = GetComponent<PlayerInputHandler>();
        }

        protected override void Jump()
        {
            if (_playerInput.IsJump && IsGround)
            {
                rigid.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
                StatusHandler.ChangeStatus(PlayerStatusEnum.Jump);
            }
        }

        protected override void Move()
        {
            if (!_playerInput.IsMove)
                return;
            
            var yRotation = Quaternion.AngleAxis(playerCam.transform.eulerAngles.y, Vector3.back);
            var dir = yRotation * _playerInput.Direction;
            
            var vel = rigid.velocity;

            var speed = _playerInput.IsSprint ? runSpeed : moveSpeed;
            
            vel.x = dir.x * speed;
            vel.z = dir.y * speed;
            
            rigid.velocity = vel;
        }

        protected override void Rotate()
        {
            if (!_playerInput.IsMove)
                return;
            
            var dir = _playerInput.Direction;

            var playerAngleY = cachedTr.eulerAngles.y;            
            var targetAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
            
            var angle = Mathf.SmoothDampAngle(playerAngleY, targetAngle, ref _turnSmoothVelocity, _smoothTime);

            cachedTr.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}