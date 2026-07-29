using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector2 _input;
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;
    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _input * _moveSpeed * Time.fixedDeltaTime);
    }

private void ReadInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
    }

}
