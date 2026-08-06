using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;
    private float _spawnTimer;
    private BoxCollider2D _boxCollider2D;

private void Awake() 
{
    _boxCollider2D = GetComponent<BoxCollider2D>();
}

private void Update() 
{
    _spawnTimer += Time.deltaTime;
    if(_spawnTimer >= _spawnTime)
        {
            SpawnEnemy();
            _spawnTimer = 0;
        } 
}

private void SpawnEnemy()
    {
        Vector2 randomPosition = GetPosition();
        Instantiate(_enemy, randomPosition, transform.rotation);
    }

private Vector2 GetPosition()
    {
        Bounds bounds = _boxCollider2D.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomy = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(randomX, randomy);
    }
}
