using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (CompareTag("BulletPlayer"))
            transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
        else
            transform.position += Vector3.down * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bala del jugador
        if (CompareTag("BulletPlayer"))
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyHealth health = collision.GetComponent<EnemyHealth>();

                if (health != null)
                {
                    health.TakeDamage();
                }

                Destroy(gameObject);
            }
        }

        else if (CompareTag("BulletEnemy"))
        {
            if (collision.CompareTag("Player"))
            {
                PlayerHealth player = collision.GetComponent<PlayerHealth>();

                if (player != null)
                {
                    player.TakeDamage(1);
                }

                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("EnemyStop"))
        {
            Destroy(gameObject);
        }
    }
}