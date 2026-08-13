using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _bulletDamage = 1;

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (tag.Equals("BulletPlayer"))
        {
            transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * _bulletSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag.Equals("BulletPlayer"))
        {
            if (collision.tag.Equals("Enemy"))
            {
                EnemyHealth health = collision.GetComponent<EnemyHealth>();

                if (health != null)
                {
                    health.TakeDamage();
                }

                Destroy(gameObject);
            }
        }
        else if (tag.Equals("BulletEnemy"))
        {
            if (collision.tag.Equals("Player"))
            {
                PlayerHealth player = collision.GetComponent<PlayerHealth>();

                if (player != null)
                {
                    player.TakeDamage(_bulletDamage);
                }

                Destroy(gameObject);
            }
        }

        if (collision.tag.Equals("EnemyStop"))
        {
            Destroy(gameObject);
        }
    }
}