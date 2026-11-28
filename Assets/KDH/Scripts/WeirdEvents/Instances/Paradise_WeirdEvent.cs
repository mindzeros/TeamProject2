using KDH.Scripts.Rooms;

namespace KDH.Scripts.WeirdEvents
{
    internal class Paradise_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnStartEvent()
        {
            CurtainRoom.S_Paradise = true;
        }

        public override void OnEndEvent()
        {
            CurtainRoom.S_Paradise = false;
            CurtainRoom.IsRunning = false;
        }
    }
}
