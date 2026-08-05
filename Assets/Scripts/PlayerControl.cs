using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runModifier;
    private float _runMultiplier;
    private float _isRunning;
    private Vector2 _input;

    [Header("Disparo")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _shootCooldown;
    private float _shootTimer;
    private float _isShooting;

    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;
    private Animator _animator;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        //Correr
        Run();

        //Disparar
        _shootTimer += Time.deltaTime;
        if(_shootTimer >= _shootCooldown)
        {
            Shoot();
            _shootTimer = 0;
        }

        //Animacion
        _animator.SetFloat("xMovement", _input.x);
    }

    private void FixedUpdate() 
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _input  * _runMultiplier *  _moveSpeed * Time.fixedDeltaTime);
    }

private void ReadInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
        _isRunning = _playerInput.actions["Correr"].ReadValue<float>();
        _isShooting = _playerInput.actions["Shoot"].ReadValue<float>();
    }

    private void Run()
    {
        if (_isRunning == 1)
        {
            _runMultiplier = _runModifier;
        }
        else
        {
            _runMultiplier = 1;
        }
    }

    private void Shoot()
    {
        if(_isShooting != 0)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
    }

}
