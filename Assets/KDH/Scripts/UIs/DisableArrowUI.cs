using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class DisableArrowUI : MonoBehaviour
    {
        [SerializeField] private RoomViewController roomViewController;

        private void OnEnable()
        {
            roomViewController.Arrows.SetActive(false);
        }

        private void OnDisable()
        {
            roomViewController.Arrows.SetActive(true);
        }
    }
}
