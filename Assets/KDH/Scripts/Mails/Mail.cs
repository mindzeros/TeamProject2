using System.Collections.Generic;
using UnityEngine;

namespace KDH.Scripts.Mails
{
    public class Mail : MonoBehaviour
    {
        [SerializeField] private ResourceManager _resourceManager;
        [field: SerializeField] public MailBoxController MailBoxController { get; private set; }
        [SerializeField] private MiniItemUI _mailPrefab;
        [SerializeField] private Transform _contentTrm;
        [SerializeField] private string nullItemText = "아이템이 더 이상 없는 거 같다..";

        private void Start()
        {
            MailBoxController.CollectBtn.onClick.AddListener(DestroyItems);

            if (MailBoxController.TargetUI.activeSelf)
            {
                MailBoxController.HandleChangeActive();
            }
        }

        private void OnDestroy()
        {
            MailBoxController.CollectBtn.onClick.RemoveAllListeners();
        }

        public void InitItem(IReadOnlyDictionary<ItemSO, int> items)
        {
            foreach (var item in items)
            {
                MiniItemUI miniItemUI = Instantiate(_mailPrefab, _contentTrm);
                miniItemUI.Icon.sprite = item.Key.icon;
                miniItemUI.Count.SetText("x" + item.Value);
            }

            MailBoxController.MailMainText.SetText($"{_contentTrm.childCount}{MailBoxController.Message}");
        }

        public void DestroyItems()
        {
            for(int i = 0; i < _contentTrm.childCount; i++)
            {
                Destroy(_contentTrm.GetChild(i).gameObject);
            }

            foreach (var item in _resourceManager.MailItemDict)
            {
                _resourceManager.GetItem(item.Key, item.Value);
            }

            MailBoxController.MailMainText.SetText(nullItemText);
            _resourceManager.ClearMailDict();
        }
    }
}
