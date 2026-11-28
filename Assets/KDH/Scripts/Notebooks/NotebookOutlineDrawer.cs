using KDH.Scripts.Cameras;
using UnityEngine;

namespace KDH.Scripts.Notebooks
{
    internal class NotebookOutlineDrawer : OutlineDrawer
    {
        [SerializeField] private CameraZoom cameraZoom;
        
        private void OnEnable()
        {
            spriteRenderer.material = defaultMaterial;
        }

        protected override void OnMouseEnter()
        {
            if (!cameraZoom.Zooming)
            {
                spriteRenderer.material = OutlineMaterial;
            }
        }

        private void OnMouseOver()
        {
            if (spriteRenderer.material != defaultMaterial && cameraZoom.Zooming)
            {
                spriteRenderer.material = defaultMaterial;
            }
        }

        protected override void OnMouseExit()
        {
            if (!cameraZoom.Zooming)
            {
                spriteRenderer.material = defaultMaterial;
            }
        }
    }
}
