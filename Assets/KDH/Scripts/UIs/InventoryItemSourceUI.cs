using KDH.Scripts.UIs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.KDH.Scripts.UIs
{
    internal class InventoryItemSourceUI : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI CountText { get; private set; }
        [field: SerializeField] public Image Icon { get; private set; }
        public ItemSO ItemData { get; set; }

        private Button _btn;

        private void Awake()
        {
            _btn = GetComponent<Button>();
        }

        private void Start()
        {
            _btn.onClick.AddListener(() =>
            {
                SetCurrentItem();
            });
        }

        private void SetCurrentItem()
        {
            InventoryUI.CurrentItem = ItemData;
            InventoryUI.OnCurrentItemChanged?.Invoke();
        }
    }
}
