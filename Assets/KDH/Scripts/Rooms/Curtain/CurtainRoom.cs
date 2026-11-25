using KDH.Scripts.Systems;
using System.Collections;
using UnityEngine;

namespace KDH.Scripts.Rooms
{
    internal class CurtainRoom : Room
    {
        [SerializeField] private RoomViewController roomController;
        [SerializeField] private RoomAnimationController animController;
        private readonly int _hashOpenCurtain = Animator.StringToHash("Open");
        private readonly int _hashCloseCurtain = Animator.StringToHash("Close");
        private readonly int _hashKid = Animator.StringToHash("Kid");
        private readonly int _hashDrowning = Animator.StringToHash("Drowning");
        private readonly int _hashIdle = Animator.StringToHash("Idle");
        internal static bool S_Drowning;
        internal static bool S_Kid;
        public static bool IsRunning { get; internal set; }

        private bool _openState;

        public void SetVisual()
        {
            // TODO
        }

        internal IEnumerator SetAnim()
        {
            if (!IsRunning && !S_Kid && !S_Drowning)
            {
                IsRunning = true;
                roomController.Arrows.SetActive(false);

                if (_openState)
                {
                    animController.AnimationTrigger(_hashCloseCurtain);
                }
                else
                {
                    animController.AnimationTrigger(_hashOpenCurtain);
                }

                yield return new WaitForSeconds(1f);

                roomController.Arrows.SetActive(true);
                _openState = !_openState;
                IsRunning = false;
            }
        }
    }
}
