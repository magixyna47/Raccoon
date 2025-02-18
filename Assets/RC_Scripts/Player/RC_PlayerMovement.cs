using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RC_PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    private RC_IA_PlayerControls _playerControls;
    
    private Rigidbody _rigidbody;
    private bool _isMoving;

    private void Awake()
    {
        _playerControls = new RC_IA_PlayerControls();
        _playerControls.Player.Enable();
        _playerControls.Player.Move.started += ctx => OnMoveInput();
        _playerControls.Player.Move.canceled += ctx => OnMoveCancelled();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMoveInput()
    {
        StartCoroutine(MovePlayer());
    }

    private IEnumerator MovePlayer()
    {
        _isMoving = true;
        
        while (_isMoving)
        {
            var move = _playerControls.Player.Move.ReadValue<Vector2>();
            Vector3 movement = new Vector3(move.x, 0, move.y);
            _rigidbody.MovePosition(transform.position + movement * Time.deltaTime * _walkSpeed);
            yield return null;
        }
    }

    private void OnMoveCancelled()
    {
        _isMoving = false;
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }
}
