using KDH.Scripts.Cameras;
using KDH.Scripts.Systems;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KDH.Scripts.Notebooks
{
    public class Notebook : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [field: SerializeField] public GameObject MonitorScreen { get; private set; }
        [SerializeField] private CameraZoom cameraZoom;
        [SerializeField] private RoomViewController roomController;

        public bool IsActive => MonitorScreen.activeSelf;
        private bool _isRunning;

        private void Start()
        {
            if (IsActive)
            {
                MonitorScreen.SetActive(false);
            }
        }

        public async void HandleChangeActive() // 버튼과 직렬화로 연결 됌
        {
            if (_isRunning)
            {
                return;
            }

            try
            {
                _isRunning = true;

                if (MonitorScreen.activeSelf)
                {
                    MonitorScreen.SetActive(false);
                    await cameraZoom.CameraZoomOut();
                    roomController.Arrows.SetActive(true);
                }
                else
                {
                    roomController.Arrows.SetActive(false);
                    await cameraZoom.CameraZoomIn();
                    MonitorScreen.SetActive(true);
                }
            }
            catch ( Exception exception)
            {
                Debug.Log(exception);
            }
            finally
            {
                _isRunning = false;
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}
