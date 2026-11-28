using KDH.Scripts.Rooms;

namespace KDH.Scripts.WeirdEvents
{
    internal class Apocalypse_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnStartEvent()
        {
            CurtainRoom.S_Apocalypse = true;
        }

        public override void OnEndEvent()
        {
            CurtainRoom.S_Apocalypse = false;
            CurtainRoom.IsRunning = false;
        }
    }
}
