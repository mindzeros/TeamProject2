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
        private readonly int _hashParadise = Animator.StringToHash("Paradise");
        private readonly int _hashApocalypse = Animator.StringToHash("Apocalypse");
        private readonly int _hashOpened = Animator.StringToHash("IsOpened");
        internal static bool S_Drowning;
        internal static bool S_Kid;
        internal static bool S_Paradise;
        internal static bool S_Apocalypse;
        public static bool IsRunning { get; internal set; }

        private bool _openState;

        private void OnEnable()
        {
            SetVisual();
            animController.AnimationBooler(_hashOpened, _openState);
        }

        public void SetVisual()
        {
            // TODO
            if (S_Kid)
            {
                animController.AnimationTrigger(_hashKid);
            }
            else if (S_Drowning)
            {
                animController.AnimationTrigger(_hashDrowning);
            }
            else if (S_Paradise)
            {
                animController.AnimationTrigger(_hashParadise);
            }
            else if (S_Apocalypse)
            {
                animController.AnimationTrigger(_hashApocalypse);
            }
        }

        internal IEnumerator SetAnim()
        {
            if (!IsRunning && !S_Kid && !S_Drowning && !S_Paradise && !S_Apocalypse) // 이상현상인 if문 고치는 거랑 위에 트리거 키는 거 말곤 없음 힘들어서 대충 짬
            {
                IsRunning = true;
                roomController.Arrows.SetActive(false);

                animController.AnimationBooler(_hashOpened, _openState);
                
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
