using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class PlayerStatusUIBtn : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        public void HandleChangeActive()
        {
            target.SetActive(!target.activeSelf);
        }
    }
}
