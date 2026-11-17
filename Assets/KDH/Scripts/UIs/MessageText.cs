using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class MessageText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI showText;
        [SerializeField] private Color color;
        [SerializeField] private float showDuration;
        [SerializeField] private float duration;

        private MessageUI _messageUI;

        public void Init(MessageUI messageUI)
        {
            _messageUI = messageUI;
        }

        public void SetText(string text)
        {
            showText.color = color;
            showText.SetText(text);
            Fade().Forget();
        }

        private async UniTask Fade()
        {
            try
            {
                await UniTask.Delay((int)showDuration * 1000);
                await showText.DOFade(0, duration).AsyncWaitForCompletion();
                _messageUI.messages.Enqueue(this);
                gameObject.SetActive(false);
            }
            catch (Exception exception)
            {
                Debug.Log(exception);
            }
        }
    }
}
