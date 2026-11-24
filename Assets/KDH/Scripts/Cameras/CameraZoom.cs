using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

namespace KDH.Scripts.Cameras
{
    public class CameraZoom : MonoBehaviour
    {
        [Header("Start Values")]
        [SerializeField] private float startValue;
        [SerializeField] private Vector3 startPosition;
        [Header("End Values")]
        [SerializeField] private float endValue;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private Camera _camera;
        [SerializeField] private float duration;

        private bool _isRunning;
        public bool IsRunning => _isRunning;

        public async UniTask CameraZoomIn()
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            try
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(_camera.DOOrthoSize(endValue, duration).SetEase(Ease.InOutCubic));
                seq.Join(_camera.transform.DOMove(endPosition, duration).SetEase(Ease.InOutCubic));

                await seq.AsyncWaitForCompletion();
            }
            catch (Exception exception)
            {
                Debug.Log(exception);
            }
            finally
            {
                _isRunning = false;
            }
        }

        public async UniTask CameraZoomOut()
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            try
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(_camera.DOOrthoSize(startValue, duration).SetEase(Ease.InOutCubic));
                seq.Join(_camera.transform.DOMove(startPosition, duration).SetEase(Ease.InOutCubic));

                await seq.AsyncWaitForCompletion();
            }
            catch (Exception exception)
            {
                Debug.Log(exception);
            }
            finally
            {
                _isRunning = false;
            }
        }
    }
}
