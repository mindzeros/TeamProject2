using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.UIs
{
    internal class FadeColorUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [Header("Settings")]
        [SerializeField] private float delayTime;
        [SerializeField] private float fadeTime;

        public void Show()
        {
            image.DOKill();          // 진행 중인 트윈 정리
            image.color = Color.white;
        }

        public async UniTask FadeInColor(CancellationToken token)
        {
            try
            {
                await UniTask.WaitForSeconds(delayTime, cancellationToken: token);
                await image.DOFade(0, fadeTime).SetEase(Ease.Linear).ToUniTask(TweenCancelBehaviour.KillAndCancelAwait, token);
            }
            catch (OperationCanceledException)
            {

            }
        }
    }
}
