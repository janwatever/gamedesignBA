using System;
using System.Collections.Generic;
using UnityEngine;
using Prototype.Manager;

namespace Prototype.FreeCam
{
    public class FreeCam : MonoBehaviour
    {
        [SerializeField] private float AnimBlendSpeed = 8.9f;
        [SerializeField] private float UpperLimit = -40f;
        [SerializeField] private float BottomLimit = 70f;
        [SerializeField] private float MouseSensitivity = 21.9f;
        [SerializeField] private Transform Camera;
        private InputManager _inputManager;
        private const float _movementSpeed = 5f;
        private Animator _animator;
        private bool _hasAnimator;
        private int _xVelHash;
        private int _yVelHash;
        private float _xRotation;
        private Vector2 _currentVelocity;


        void Start()
        {
            _hasAnimator = TryGetComponent<Animator>(out _animator);
            _inputManager = GetComponent<InputManager>();
        }

        void Update()
        {
            // if (_inputManager.Possess)
            // {
            //     StartLooking();
            // }
            // else if (_inputManager.Interact)
            // {
            //     StopLooking();
            // }
        }

        void OnDisable()
        {
            StopLooking();
        }

        private void StartLooking()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Move();
            Look();
        }

        private void StopLooking()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void Move()
        {
            float targetSpeed = _movementSpeed;
            if (_inputManager.Move == Vector2.zero)
            { targetSpeed = 0.1f; }

            _currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _inputManager.Move.x * targetSpeed, Time.fixedDeltaTime);
            _currentVelocity.y = Mathf.Lerp(_currentVelocity.y, _inputManager.Move.y * targetSpeed, Time.fixedDeltaTime);

            transform.position = transform.TransformVector(new Vector3(_currentVelocity.x,_currentVelocity.y));
        }

        private void Look()
        {
            var Mouse_X = _inputManager.Look.x;
            var Mouse_Y = _inputManager.Look.y;

            _xRotation -= Mouse_Y * MouseSensitivity * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, UpperLimit, BottomLimit);

            Camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            transform.Rotate(Vector3.up, Mouse_X * MouseSensitivity * Time.deltaTime);
        }

    }
}