using DG.Tweening;
using System;
using UnityEngine;

namespace KDH.Scripts.UIs
{
    public class XMoveUI : MonoBehaviour
    {
        [SerializeField] private RectTransform target;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private Ease ease;
        [SerializeField] private float time;

        private Vector3 _startPos;

        private void Start()
        {
            _startPos = target.anchoredPosition;
        }

        public void Anim()
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(target.DOAnchorPos(targetPos, time).SetEase(ease));
            seq.AppendCallback(() => target.DOAnchorPos(_startPos, 0).SetEase(ease));
        }
    }
}
