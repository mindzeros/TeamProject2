using Assets.KDH.Scripts.UIs;
using KDH.Scripts.Items;
using KDH.Scripts.Systems;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.UIs
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private ResourceManager resources;
        [SerializeField] private InvetoryItemListUI[] listUIs;
        [SerializeField] private SelectCurrentItem selectCurrentItem;
        [SerializeField] private Button useBtn;

        [Header("Current Item Info UI")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Image icon;

        public static ItemSO CurrentItem { get; set; }
        public static Action OnCurrentItemChanged;
        public CharacterStats CurrentTarget { get; set; }

        private void Awake()
        {
            useBtn.onClick.AddListener(() =>
            {
                ExceptionMessage();
                GameManager.Instance.Resources.UseItem(CurrentTarget, CurrentItem, 1);
            });
        }

        public bool ExceptionMessage()
        {
            if (!selectCurrentItem.HasSelected())
            {
                GameManager.Instance.UIManager.MessageUI.SetUI("플레이어를 선택해 주세요");

                return false;
            }
            else if (CurrentItem == null)
            {
                GameManager.Instance.UIManager.MessageUI.SetUI("아이템을 선택해 주세요");

                return false;
            }

            return true;
        }

        private void Start()
        {
            OnCurrentItemChanged += ChangeCurrentItemInfo;
        }

        private void OnDestroy()
        {
            OnCurrentItemChanged -= ChangeCurrentItemInfo;
        }

        public void SetInventory()
        {
            foreach (var ui in listUIs)
            {
                ui.Generate(resources.ItemDict);
            }
        }

        public void RemoveCurrentItem()
        {
            CurrentItem = null;
            ResetCurrentItemInfo();
        }

        private void ResetCurrentItemInfo()
        {
            nameText.SetText("");
            descriptionText.SetText("");
            icon.sprite = null;
        }

        private void ChangeCurrentItemInfo()
        {
            nameText.SetText(CurrentItem.itemName);
            descriptionText.SetText(CurrentItem.description);
            icon.sprite = CurrentItem.icon;
        }
    }
}
