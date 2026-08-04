using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _enemyYSpeed;
    [SerializeField] private float _enemyXSpeed;
    private float _targetXPosition;
    private float _enemyWidth;
    private Vector2 _screenBounds;
    private Collider2D _collider2D;

    [SerializeField] private GameObject _enemyBullet;
    private float _ShootTime = 1f;
    private float _shootTimer;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _enemyWidth = _collider2D.bounds.extents.x;
        Vector3 screenValues = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        _screenBounds = Camera.main.ScreenToWorldPoint(screenValues);
        SetRandomXPosition();
    }

    private void Update() 
    {
        transform.Translate(Vector3.down * _enemyYSpeed * Time.deltaTime);

        _shootTimer += Time.deltaTime;
        shoot();
        Move();
    }

    private void shoot()
    {
        if (_shootTimer >= _ShootTime)
        {
            Instantiate(_enemyBullet, transform.position, transform.rotation);
            _shootTimer = 0;
        }
    }

    private void Move()
    {
        float newXPosition = Mathf.MoveTowards(transform.position.x, _targetXPosition, _enemyXSpeed * Time.deltaTime);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        if (Mathf.Abs(transform.position.x - _targetXPosition) < 0.1f)
        {
            SetRandomXPosition();
        }
    }

    private void SetRandomXPosition()
    {
        _targetXPosition = Random.Range(-_screenBounds.x + _enemyWidth, _screenBounds.x - _enemyWidth);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag.Equals("EnemyStop"))
        {
            Destroy(gameObject);
        }
    }
}
