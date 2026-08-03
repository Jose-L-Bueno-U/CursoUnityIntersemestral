using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _enemyYSpeed;

    [SerializeField] private GameObject _enemyBullet;
    private float _ShootTime = 1f;
    private float _shootTimer;

    private void Update() 
    {
        transform.Translate(Vector3.down * _enemyYSpeed * Time.deltaTime);

        _shootTimer += Time.deltaTime;
        shoot();
    }

    private void shoot()
    {
        if (_shootTimer >= _ShootTime)
        {
            Instantiate(_enemyBullet, transform.position, transform.rotation);
            _shootTimer = 0;
        }
    }
}
