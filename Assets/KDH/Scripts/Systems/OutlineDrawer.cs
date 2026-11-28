using UnityEngine;

public class OutlineDrawer : MonoBehaviour
{
    [SerializeField] protected Material OutlineMaterial;
    [SerializeField] protected Material defaultMaterial;

    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected virtual void OnMouseEnter()
    {
        spriteRenderer.material = OutlineMaterial;
    }

    protected virtual void OnMouseExit()
    {
        spriteRenderer.material = defaultMaterial;
    }
}
