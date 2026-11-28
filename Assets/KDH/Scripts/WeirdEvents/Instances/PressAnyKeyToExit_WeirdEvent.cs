using KDH.Scripts.Notebooks;
using UnityEngine;

namespace KDH.Scripts.WeirdEvents
{
    internal class PressAnyKeyToExit_WeirdEvent : AbstractWeirdEvent
    {
        [SerializeField] private GameObject weridEventPrefab;

        private GameObject _weirdEventObj;

        public override void OnEndEvent()
        {
            Destroy(_weirdEventObj);
        }

        public override void OnStartEvent()
        {
            _weirdEventObj = Instantiate(weridEventPrefab, NotebookWeirdEvent.anyKeyInputEventTrm);
        }
    }
}
