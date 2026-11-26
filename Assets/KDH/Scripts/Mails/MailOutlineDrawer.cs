namespace KDH.Scripts.Mails
{
    internal class MailOutlineDrawer : OutlineDrawer
    {
        private void OnEnable()
        {
            _spriteRenderer.material = defaultMaterial;
        }

        protected override void OnMouseEnter()
        {
            _spriteRenderer.material = OutlineMaterial;
        }

        protected override void OnMouseExit()
        {
            _spriteRenderer.material = defaultMaterial;
        }
    }
}
