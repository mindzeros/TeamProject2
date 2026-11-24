using UnityEngine;

namespace KDH.Scripts.WeirdEvents
{
    internal class WaterNotFlow_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnStartEvent()
        {
            Debug.Log("이벤트3 시작");
        }

        public override void OnEndEvent()
        {
            Debug.Log("이벤트3 종료");
        }
    }
}
