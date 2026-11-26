using UnityEngine;

namespace KDH.Scripts.Rooms
{
    public class RoomAnimationController : MonoBehaviour
    {
        [SerializeField] protected Animator animCompo;

        public void AnimationTrigger(int hash)
        {
            if (animCompo == null)
            {
                return;
            }

            animCompo.SetTrigger(hash);
        }

        public void AnimationBooler(int hash, bool boolean)
        {
            if (animCompo == null)
            {
                return;
            }

            animCompo.SetBool(hash, boolean);
        }
    }
}
