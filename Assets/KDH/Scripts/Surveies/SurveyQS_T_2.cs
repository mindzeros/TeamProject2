using KDH.Scripts.Rooms;
using System.Collections.Generic;

namespace KDH.Scripts.Surveies
{
    public class SurveyQS_T_2 : AbstractSurveySpecialCondition
    {
        private readonly Dictionary<Room, bool> roomDict = new();
        private Survey _parent;

        private void Awake()
        {
            _parent = GetComponentInParent<Survey>();
        }

        private void Start()
        {
            foreach (var room in _parent.Rooms)
            {
                roomDict.TryAdd(room, false);
            }
        }

        public void SetDictValue(Room room)
        {
            roomDict[room] = true;
        }

        public override bool SpecialCondition()
        {
            foreach (var room in roomDict)
            {
                if (room.Value == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
