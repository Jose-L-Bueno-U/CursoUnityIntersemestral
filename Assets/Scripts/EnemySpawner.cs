using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemigos")]
    [SerializeField] private GameObject _normalEnemy;
    [SerializeField] private GameObject _bigEnemy;

    [Header("Spawn")]
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _bigEnemyChance = 0.2f;

    private float _spawnTimer;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnTime)
        {
            SpawnEnemy();
            _spawnTimer = 0;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomPosition = GetPosition();

        GameObject enemyToSpawn;

        float randomChance = Random.Range(0f, 1f);

        if (randomChance <= _bigEnemyChance)
        {
            enemyToSpawn = _bigEnemy;
        }
        else
        {
            enemyToSpawn = _normalEnemy;
        }

        Instantiate(enemyToSpawn, randomPosition, transform.rotation);
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxCollider2D.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}