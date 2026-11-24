using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class NextDayFadeInOutUI : FadeInOutUI
    {
        [SerializeField] private RoomViewController roomViewController;
        [SerializeField] private TextMeshProUGUI _message;

        public override void Fade(float fadeInTime, float fadeOutTime, float relateTime)
        {
            
        }
        
        public void Fade(float fadeInTime, float fadeOutTime, float relateTime, string message, Action action, Color color)
        {
            Sequence seq = DOTween.Sequence();

            roomViewController.Arrows.SetActive(false);

            _targetRect.gameObject.SetActive(true);
            _message.gameObject.SetActive(true);
            
            _message.SetText(message);
            _message.color = new Color(color.r, color.g, color.b, 0);

            seq.Append(_targetRect.DOFade(1, fadeInTime).SetEase(Ease.Linear));
            seq.Append(_message.DOFade(1, fadeInTime).SetEase(Ease.Linear));
            
            seq.AppendInterval(relateTime);
            seq.AppendCallback(() => action());
            
            seq.Append(_message.DOFade(0, fadeOutTime).SetEase(Ease.Linear));
            seq.Append(_targetRect.DOFade(0, fadeOutTime).SetEase(Ease.Linear));
            seq.AppendCallback(() => _targetRect.gameObject.SetActive(false));
            seq.AppendCallback(() => _message.gameObject.SetActive(false));
            seq.AppendCallback(() => roomViewController.Arrows.SetActive(true));
        }
    }
}