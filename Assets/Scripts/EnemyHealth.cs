using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header("Vida del enemigo")]
    [SerializeField] private float _enemyHealth;
    private float _currentHealth;

    [SerializeField] private float _bulletDamage;

    [Header("Puntaje")]
    [SerializeField] private int _enemyScore = 100;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _currentHealth = _enemyHealth;
    }

    public void TakeDamage()
    {
        _currentHealth -= _bulletDamage;

        StartCoroutine(DamageFlash());

        if (_currentHealth <= 0)
        {
            WinCondition win = FindFirstObjectByType<WinCondition>();

            if (win != null)
            {
                win.AddScore(_enemyScore);
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator DamageFlash()
    {
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = Color.white;
    }
}