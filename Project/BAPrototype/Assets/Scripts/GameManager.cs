using UnityEngine;
using Prototype.Manager;
using Prototype.PlayerControl;
using UnityEngine.InputSystem;

namespace Prototype.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] public GameObject _playerObject;
        private InputManager _inputManager;
        private PlayerController _playerController;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _playerController = _playerObject.GetComponent<PlayerController>();
            _inputManager = _playerObject.GetComponent<InputManager>();
        }

        // Update is called once per frame
        void Update()
        {
            StopPlayerMoving();
        }

        void StopPlayerMoving()
        {
            if(_inputManager.StopMove == true )
            {
               _playerController._stopMoving = true;
            }
            else
            {
                _playerController._stopMoving = false;
            }
        }


    }
}
