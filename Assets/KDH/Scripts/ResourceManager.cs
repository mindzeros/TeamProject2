using System;
using System.Collections.Generic;
using KDH.Scripts.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KDH.Scripts
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        
        [SerializeField] private int _credit;

        public int Credit
        {
            get => _credit;
            set
            {
                _credit = Mathf.Max(0, value);
                OnCreditChange?.Invoke(Credit);
            }
        }

        [SerializeField] private int _life = 3;

        public int Life
        {
            get => _life;
            set
            {
                _life = Mathf.Max(0, value);
                OnChangeLife?.Invoke(Life);
            }
        }

        public event Action<int> OnCreditChange;
        public event Action OnItemBuy;
        public event Action<int> OnChangeLife;

        private readonly Dictionary<ItemSO, int> _itemDict = new();
        private readonly Dictionary<ItemSO, int> _mailItemDict = new();
        private readonly Dictionary<ItemSO, int> _delieryItemDict = new();
        public IReadOnlyDictionary<ItemSO, int> ItemDict => _itemDict;
        public IReadOnlyDictionary<ItemSO, int> MailItemDict => _mailItemDict;
        public IReadOnlyDictionary<ItemSO, int> DeliveryItemDict => _delieryItemDict;

        public event Action OnItemAmountChanged;

        private void Start()
        {
            OnCreditChange += _uiManager.CreditText.SetCreditText;
            OnChangeLife += _uiManager.HealthText.ChangeHealthText;
            OnItemAmountChanged += _uiManager.InventoryUI.SetInventory;

            OnCreditChange?.Invoke(Credit);
            OnChangeLife?.Invoke(Life);
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.yKey.wasPressedThisFrame)
            {
                foreach (var i in _itemDict)
                    Debug.Log(i.Key.itemName + ": " + i.Value);
            }
        }
# endif
        
        private void OnDestroy()
        {
            OnCreditChange -= _uiManager.CreditText.SetCreditText;
            OnChangeLife -= _uiManager.HealthText.ChangeHealthText;
            OnItemAmountChanged -= _uiManager.InventoryUI.SetInventory;
        }

        public void AddDeliveryItem(ItemSO item, int count) // 주문
        {
            if (_delieryItemDict.TryGetValue(item, out int currentValue))
            {
                _delieryItemDict[item] = currentValue + count;
            }
            else
            {
                _delieryItemDict[item] = 1;
            }
        }

        public void AddMailItem(ItemSO item, int count) // 우편함에 아이템 넣기
        {
            _mailItemDict.TryAdd(item, count);
        }

        public void GetItem(ItemSO item, int count) // 즉시 아이템을 획득
        {
            _itemDict.TryAdd(item, count);
            OnItemAmountChanged?.Invoke();
        }

        public void UseItem(CharacterStats target, ItemSO item, int count)
        {
            if (!GameManager.Instance.UIManager.InventoryUI.ExceptionMessage()) return;

            _itemDict[item] -= count;
            DHM.GameManager.Instance.UseItemOnCharacter(item, target);

            if (_itemDict[item] <= 0)
            {
                GameManager.Instance.UIManager.InventoryUI.RemoveCurrentItem();
                _itemDict.Remove(item);
            }

            OnItemAmountChanged?.Invoke();
        }

        public void GetCredit(int amount)
        {
            Credit += amount;
        }
        public void GetLife(int amount)
        {
            Life += amount;
        }
        
        public void UseCredit(int amount)
        {
            // 내가 살 수 있는지 검사 해야 함.
            if (Credit < amount)
            {
                _uiManager.MessageUI.SetUI("크레딧이 부족합니다.");
                return;
            }
            
            Credit -= amount;
            OnItemBuy?.Invoke();
        }

        public void SubstractLife(int amount)
        {
            Life -= amount;
        }

        public void ClearDeliveryDict()
        {
            _delieryItemDict.Clear();
        }

        public void ClearMailDict()
        {
            _mailItemDict.Clear();
        }
    }
}
