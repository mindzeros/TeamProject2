using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class PlayerSelectOutlineUI : OutlineUI
    {
        [SerializeField] private PlayerSelectOutlineUI[] otherUI; 

        public override void OnClick()
        {
            foreach (var entity in otherUI)
            {
                entity.ResetUI();
            }

            image.material = outlineMaterial;
        }
    }
}
