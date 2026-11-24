using System;

namespace KDH.Scripts.WeirdEvents
{
    internal class Nothing_WeirdEvent : AbstractWeirdEvent
    {
        public override void OnEndEvent()
        {
            throw new NotImplementedException();
        }

        public override void OnStartEvent()
        {
            throw new NotImplementedException();
        }
    }
}
