using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.UIs
{
    public class OutlineUI : MonoBehaviour
    {
        [SerializeField] protected Image image;
        [SerializeField] protected Material outlineMaterial;

        public void ResetUI()
        {
            image.material = null;
        }

        public virtual void OnClick()
        {
            image.material = outlineMaterial;
        }
    }
}
