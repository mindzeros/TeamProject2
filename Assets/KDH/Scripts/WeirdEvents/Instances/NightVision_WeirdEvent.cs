using UnityEngine;

namespace KDH.Scripts.WeirdEvents
{
    internal class NightVision_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnStartEvent()
        {
            Debug.Log("이벤트2 시작");
        }

        public override void OnEndEvent()
        {
            Debug.Log("이벤트2 종료");
        }
    }
}
