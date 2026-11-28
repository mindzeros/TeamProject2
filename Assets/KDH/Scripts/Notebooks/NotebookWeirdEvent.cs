using UnityEngine;

namespace KDH.Scripts.Notebooks
{
    public class NotebookWeirdEvent : MonoBehaviour
    {
        [SerializeField] private Transform anykeyInputWeridEventTrm;
        public static Transform anyKeyInputEventTrm;

        private void Start()
        {
            anyKeyInputEventTrm = anykeyInputWeridEventTrm;
        }
    }
}
