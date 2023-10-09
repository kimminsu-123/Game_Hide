using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Com.Hide.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public bool IsMove => !Direction.Equals(Vector2.zero);
        public Vector2 Direction { get; private set; }
        public bool IsJump { get; private set; }
        public bool IsSprint { get; private set; }

        private void OnMove(InputValue value)
        {
            Direction = value.Get<Vector2>().normalized;
        }

        private void OnPressedJump()
        {
            IsJump = true;
        }

        private void OnReleasedJump()
        {
            IsJump = false;
        }

        private void OnPressedSprint()
        {
            IsSprint = true;
        }

        private void OnReleasedSprint()
        {
            IsSprint = false;
        }
    }
}