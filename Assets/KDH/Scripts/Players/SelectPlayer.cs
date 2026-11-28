using KDH.Scripts.Items;
using KDH.Scripts.Systems;
using KDH.Scripts.UIs;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.Players
{
    public class SelectPlayer : MonoBehaviour
    {
        [SerializeField] private Button playerIconBtns;
        [SerializeField] private OutlineUI outlineUI;
        [SerializeField] private SelectCurrentItem selectCurrentItem;
        [SerializeField] private CharacterStats target;

        private void Start()
        {
            playerIconBtns.onClick.AddListener(() =>
            {
                outlineUI.OnClick();
                selectCurrentItem.SelectPlayer();
                GameManager.Instance.UIManager.InventoryUI.CurrentTarget = target;
            });
        }
    }
}
