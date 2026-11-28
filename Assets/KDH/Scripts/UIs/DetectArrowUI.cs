using Cysharp.Threading.Tasks;
using KDH.Scripts.UIs;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.KDH.Scripts.UIs
{
    internal class DetectArrowUI : DetectAreaUI
    {
        [SerializeField] private List<FadeColorUI> arrowsUI = new List<FadeColorUI>();

        private CancellationTokenSource token;

        private void Start()
        {
            GetToken();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            CancelToken();
            foreach (var ui in arrowsUI)
            {
                ui.Show();
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            var token = GetToken().Token;
            foreach (var ui in arrowsUI)
            {
                ui.FadeInColor(token).Forget();
            }
        }

        private void OnDestroy()
        {
            CancelToken();
        }

        private CancellationTokenSource GetToken()
        {
            if (token != null)
            {
                token.Cancel();
                token.Dispose();
            }

            token = new CancellationTokenSource();

            return token;
        }

        private void CancelToken()
        {
            token.Cancel();
        }
    }
}
