using UnityEngine;
using Prototype.Manager;
using Prototype.PlayerControl;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Prototype.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] public GameObject _playerObject;
        [SerializeField] private GameObject _menuUI;
        private InputManager _inputManager;
        private PlayerController _playerController;
        private Canvas _currentCanvas;
        private PlayerInput PlayerInput;
        public bool MenuInput {get; private set;}
        private InputActionMap _currentMap;
        private InputAction _menuInputAction;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            PlayerInput = _playerObject.GetComponent<PlayerInput>();
            _playerController = _playerObject.GetComponent<PlayerController>();
            _inputManager = _playerObject.GetComponent<InputManager>();
            _currentCanvas = _menuUI.GetComponent<Canvas>();

            _currentMap = PlayerInput.currentActionMap;
            _menuInputAction = _currentMap.FindAction("MenuInput");
            _menuInputAction.performed += ctx => ToggleUI();

            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
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


        private void ToggleUI()
        {
            if(_currentCanvas != null)
            {
                _currentCanvas.gameObject.SetActive(!_currentCanvas.gameObject.activeSelf);

                if(_currentCanvas.gameObject.activeSelf)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Time.timeScale = 1;
                }
            }
            

        }


    }
}
