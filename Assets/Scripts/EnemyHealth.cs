using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _enemyHealth;
    private float _currentHealth;
    [SerializeField] private float _bulletDamage;
    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _enemyHealth;
    }

    public void TakeDamage()
    {
        _currentHealth -= _bulletDamage;
        StartCoroutine(DamageFlash());

        if (_currentHealth <= 0)
        {
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
