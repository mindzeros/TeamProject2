using KDH.Scripts.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.Items
{
    public class ItemSOHandler : MonoBehaviour
    {
        public ItemSO ItemData { get; private set; }

        [SerializeField] private Image panel, amountPanel, purChaseBtn;
        [SerializeField] private TextMeshProUGUI _amount;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private Image _icon;

        private int _currentAmount;
        
        public void SetItemData(ItemSO item)
        {
            ItemData = item;
            _currentAmount = 0;
            SetBaseColor();

            if (ItemData == null)
            {
                _amount.SetText("");
                _cost.SetText("");
                _icon.sprite = null;
                
                return;
            }

            UpdateItemInfo(item);
            _icon.sprite = ItemData.icon;
        }

        private void UpdateItemInfo(ItemSO item)
        {
            if (_currentAmount >= item.amountMaxRange)
            {
                _amount.SetText($"{_currentAmount} / {item.amountMaxRange}");
                _cost.SetText("구매 완료");
                return;
            }

            _amount.SetText($"{_currentAmount} / {item.amountMaxRange}");
            _cost.SetText($"{ItemData.cost}크레딧");
        }

        public bool AddPurchaseAmount(ItemSO item)
        {
            if (_currentAmount >= item.amountMaxRange)
            {
                SetHalfColor();
                GameManager.Instance.UIManager.MessageUI.SetUI("더 이상 구매할 수 없습니다");
                UpdateItemInfo(item);
                return false;
            }

            _currentAmount++;
            UpdateItemInfo(item);

            return true;
        }

        private void SetBaseColor()
        {
            panel.color = Color.white;
            purChaseBtn.color = Color.white;
            _amount.color = Color.black;
            _cost.color = Color.black;
            amountPanel.color = Color.white;
        }

        private void SetHalfColor()
        {
            panel.color = new Color(255, 255, 255, 125);
            purChaseBtn.color = new Color(255, 255, 255, 125);
            _cost.color = new Color(0, 0, 0, 125);
            amountPanel.color = new Color(255, 255, 255, 125);
        }
    }
}
