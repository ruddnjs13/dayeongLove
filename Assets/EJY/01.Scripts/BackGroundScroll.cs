using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] private float _offSet;

    private float _currentScroll;
    private float _ratio;

    private SpriteRenderer _spriteRenderer;
    private Material _BackGroundMat;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _BackGroundMat = _spriteRenderer.material;

        _currentScroll = 0;
        _ratio = 1f / _spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        _currentScroll += _ratio * Time.deltaTime * _offSet;

        _BackGroundMat.mainTextureOffset = new Vector2(_currentScroll,0);
    }
}
