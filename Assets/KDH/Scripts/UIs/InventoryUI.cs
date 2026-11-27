using Assets.KDH.Scripts.UIs;
using KDH.Scripts.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.UIs
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private ResourceManager resources;
        [SerializeField] private Button useBtn;
        [SerializeField] private InvetoryItemListUI[] listUIs;

        public static ItemSO CurrentItem { get; set; }

        private void Awake()
        {
            useBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.Resources.UseItem(CurrentItem, 1);
            });
        }

        public void SetInventory()
        {
            foreach (var ui in listUIs)
            {
                ui.Generate(resources.ItemDict);
            }
        }
    }
}
