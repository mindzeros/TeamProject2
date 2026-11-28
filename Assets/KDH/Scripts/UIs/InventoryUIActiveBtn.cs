using Cysharp.Threading.Tasks;
using DG.Tweening;
using KDH.Scripts.Items;
using KDH.Scripts.Players;
using KDH.Scripts.Systems;
using System;
using System.Threading;
using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class InventoryUIActiveBtn : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SelectCurrentItem selectCurrentCompo;

        public bool Visiable { get; private set; } = false;

        [Header("Settings")]
        [SerializeField] private RectTransform target;
        [SerializeField] private Vector2 startPos, endPos;
        [SerializeField] private Ease ease;
        [SerializeField] private float moveTime;

        public bool _isRunning = false;
        private CancellationTokenSource _cts;

        private void OnDestroy()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }

        public void HandleChangeActive()
        {
            if (_isRunning) return;
            Motion(GetToken()).Forget();
        }

        private async UniTask Motion(CancellationToken token)
        {
            _isRunning = true;
            try
            {
                Vector2 position = Visiable ? startPos : endPos;
                Visiable = !Visiable;
                GameManager.Instance.UIManager.InventoryUI.RemoveCurrentItem();
                selectCurrentCompo.ResetSelectedPlayer();

                foreach (var i in GameManager.Instance.UIManager.InventorySelectUI)
                {
                    i.ResetUI();
                }

                await target.DOAnchorPos(position, moveTime).SetEase(ease).SetLink(gameObject).ToUniTask(TweenCancelBehaviour.KillAndCancelAwait, token);
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                _isRunning = false;
            }
        }

        private CancellationToken GetToken()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();
            return _cts.Token;
        }

        public void CancelToken()
        {
            _cts.Cancel();
        }
    }
}