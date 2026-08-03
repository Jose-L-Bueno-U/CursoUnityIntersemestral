using UnityEngine;

public class PLayerLimitBorder : MonoBehaviour
{
    private Vector2 _screenBounds;
    private float _playerHeight;
    private float _playerWidth;
    private Collider2D _collider2D;

    private void Awake() 
    {
        _collider2D = GetComponent<Collider2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerWidth = _collider2D.bounds.extents.x;
        _playerHeight = _collider2D.bounds.extents.y;
        Vector3 screenValues = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        _screenBounds = Camera.main.ScreenToWorldPoint(screenValues);
    }

    // Update is called once per frame
    private void LateUpdate() {
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -_screenBounds.x + _playerWidth, _screenBounds.x - _playerWidth);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -_screenBounds.y + _playerHeight, _screenBounds.y - _playerHeight);
        transform.position = currentPosition;
    }
}
