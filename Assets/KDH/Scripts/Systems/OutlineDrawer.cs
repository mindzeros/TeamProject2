using UnityEngine;

public class OutlineDrawer : MonoBehaviour
{
    [SerializeField] protected Material OutlineMaterial;
    [SerializeField] protected Material defaultMaterial;

    protected SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    protected virtual void OnMouseEnter()
    {
        _spriteRenderer.material = OutlineMaterial;
    }

    protected virtual void OnMouseExit()
    {
        _spriteRenderer.material = defaultMaterial;
    }
}
