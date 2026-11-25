using UnityEngine;

namespace KDH.Scripts.Rooms
{
    public class DoorRoom : Room
    {
        [SerializeField] private Transform sumGaangeTrm;
        public static Transform SumGaangeTrm { get; private set; }

        private void Start()
        {
            SumGaangeTrm = sumGaangeTrm;
        }
    }
}
