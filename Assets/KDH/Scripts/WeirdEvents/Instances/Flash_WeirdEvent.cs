using KDH.Scripts.Rooms;
using UnityEngine;

namespace KDH.Scripts.WeirdEvents
{
    internal class Flash_WeirdEvent : AbstractWeirdEvent
    {
        [SerializeField] private GameObject sumGaangePrefab;

        private GameObject _sumGaangeObj;

        public override void OnStartEvent()
        {
            _sumGaangeObj = Instantiate(sumGaangePrefab, DoorRoom.SumGaangeTrm);
        }

        public override void OnEndEvent()
        {
            Destroy(_sumGaangeObj);
        }
    }
}
