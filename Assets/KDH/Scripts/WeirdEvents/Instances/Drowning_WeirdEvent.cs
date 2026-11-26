using KDH.Scripts.Rooms;

namespace KDH.Scripts.WeirdEvents
{
    internal class Drowning_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnStartEvent()
        {
            CurtainRoom.S_Drowning = true;
        }

        public override void OnEndEvent()
        {
            CurtainRoom.S_Drowning = false;
            CurtainRoom.IsRunning = false;
        }
    }
}
