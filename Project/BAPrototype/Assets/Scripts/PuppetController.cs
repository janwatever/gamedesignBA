using System;
using Prototype.Manager;
using UnityEngine;

namespace Prototype.PuppetControl
{
    public class PuppetController : MonoBehaviour
    {
        [SerializeField] private float AnimBlendSpeed = 8.9f;
        private Rigidbody _puppetRB;
        [SerializeField] private Transform CameraRoot;
        [SerializeField] private Transform Camera;
        [SerializeField] private float UpperLimit = -40f;
        [SerializeField] private float BottomLimit = 70f;
        [SerializeField] private float MouseSensitivity = 21.9f;
        private InputManager _inputManager;
        private Animator _animator;
        private bool _hasAnimator;
        private int _xVelHash;
        private int _yVelHash;
        private Vector3 rotation;

        private const float _walkSpeed = 2f;
        private const float _runSpeed = 6f;

        private Vector2 _currentVelocity;

        void Start()
        {
            _hasAnimator = TryGetComponent<Animator>(out _animator);
            _puppetRB = GetComponent<Rigidbody>();
            _inputManager = GetComponent<InputManager>();

            _xVelHash = Animator.StringToHash("X_Velocity");
            _yVelHash = Animator.StringToHash("Y_Velocity");
        }

        private void FixedUpdate()
        {
            Move();
            //FacingDirection();
            RotatePlayer();
        }

        private void LateUpdate()
        {
            //CameraMovement();
            
        }

        private void Move()
        {
            if(!_animator) 
            {return;}

            float targetSpeed = _walkSpeed;
            if (_inputManager.Move == Vector2.zero)
            { targetSpeed = 0.1f; }

            _currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _inputManager.Move.x, AnimBlendSpeed * Time.fixedDeltaTime);
            _currentVelocity.y = Mathf.Lerp(_currentVelocity.y, _inputManager.Move.y, AnimBlendSpeed * Time.fixedDeltaTime);

            Vector3 moveDirection = transform.right * _currentVelocity.x + transform.forward * _currentVelocity.y;
            
            Vector3 moveVelocity = moveDirection * targetSpeed;

            var xVelDifference = _currentVelocity.x - _puppetRB.linearVelocity.x;
            var zVelDifference = _currentVelocity.y - _puppetRB.linearVelocity.z;

            // Preserve current Y velocity for gravity
            _puppetRB.linearVelocity = new Vector3(moveVelocity.x, _puppetRB.linearVelocity.y, moveVelocity.z);
            // _puppetRB.AddForce(moveVelocity,ForceMode.VelocityChange);
            _animator.SetFloat(_xVelHash , _currentVelocity.x);
            _animator.SetFloat(_yVelHash , _currentVelocity.y);
        }

        void RotatePlayer()
        {
            // Only rotate if there's movement
            Vector3 flatDirection = new Vector3(_puppetRB.linearVelocity.x, 0, _puppetRB.linearVelocity.z);

            if (flatDirection.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3f * Time.fixedDeltaTime);
            }
        }
        // private void FacingDirection()
        // {
        //     rotation = new Vector3(_inputManager.Move.x, 0, _inputManager.Move.y);
            
        //     if (rotation != Vector3.zero)
        //     {
        //         if(_inputManager.Move.y < 0)
        //         {
        //             rotation.z -= _inputManager.Move.y;
        //         }
        //         Quaternion targetRotation = Quaternion.LookRotation(rotation);
        //         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        //     }
        // }
    }
}
