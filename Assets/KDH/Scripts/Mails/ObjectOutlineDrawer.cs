namespace KDH.Scripts.Mails
{
    internal class ObjectOutlineDrawer : OutlineDrawer
    {
        private void OnEnable()
        {
            spriteRenderer.material = defaultMaterial;
        }

        protected override void OnMouseEnter()
        {
            spriteRenderer.material = OutlineMaterial;
        }

        protected override void OnMouseExit()
        {
            spriteRenderer.material = defaultMaterial;
        }
    }
}
