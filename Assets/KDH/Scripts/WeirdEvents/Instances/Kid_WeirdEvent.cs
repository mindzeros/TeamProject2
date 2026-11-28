using KDH.Scripts.Rooms;

namespace KDH.Scripts.WeirdEvents
{
    internal class Kid_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnStartEvent()
        {
            CurtainRoom.S_Kid = true;
        }

        public override void OnEndEvent()
        {
            CurtainRoom.S_Kid = false;
            CurtainRoom.IsRunning = false;
        }
    }
}
