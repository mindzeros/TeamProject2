using UnityEngine;

namespace KDH.Scripts.Items
{
    public class SelectCurrentItem : MonoBehaviour
    {
        private bool _playersSelected;

        public void ResetSelectedPlayer()
        {
            _playersSelected = false;
        }

        public void SelectPlayer()
        {
            _playersSelected = true;
        }

        public bool HasSelected()
        {
            if (_playersSelected)
            {
                return true;
            }

            return false;
        }
    }
}
