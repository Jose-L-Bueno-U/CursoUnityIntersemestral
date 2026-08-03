using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Collider2D _collider2D;

    private void Awake() 
    {
        _collider2D = GetComponent<Collider2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Enemy") && !_collider2D.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
