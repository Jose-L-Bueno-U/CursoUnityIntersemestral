using UnityEngine;

public class BGManager : MonoBehaviour
{
    [SerializeField] private float _BGspeed;
    private Vector2 _offset;
    private Material _material;

    private void Awake() 
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update() 
    {
        _offset = new Vector2(0f, _BGspeed * Time.deltaTime);
        _material.mainTextureOffset += _offset;

        if (_material.mainTextureOffset.y >= 1)
        {
            _material.mainTextureOffset = new Vector2(0f, 0f);
        }
    }
}
