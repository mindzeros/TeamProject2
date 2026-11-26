using KDH.Scripts.Cameras;
using UnityEngine;

namespace KDH.Scripts.Notebooks
{
    internal class NotebookOutlineDrawer : OutlineDrawer
    {
        [SerializeField] private CameraZoom cameraZoom;
        
        private void OnEnable()
        {
            _spriteRenderer.material = defaultMaterial;
        }

        protected override void OnMouseEnter()
        {
            if (!cameraZoom.Zooming)
            {
                _spriteRenderer.material = OutlineMaterial;
            }
        }

        private void OnMouseOver()
        {
            if (_spriteRenderer.material != defaultMaterial && cameraZoom.Zooming)
            {
                _spriteRenderer.material = defaultMaterial;
            }
        }

        protected override void OnMouseExit()
        {
            if (!cameraZoom.Zooming)
            {
                _spriteRenderer.material = defaultMaterial;
            }
        }
    }
}
