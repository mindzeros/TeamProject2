using UnityEngine;

namespace KDH.Scripts.WeirdEvents
{
    public class WeirdEventManager : MonoBehaviour
    {
        public AbstractWeirdEvent AbstractWeirdEvent { get; private set; }

        [field: SerializeField] public Transform WeirdEventSpawner { get; private set; }

        public bool HasWeirdEvent { get; set; }

        private void StartEvents()
        {
            if (AbstractWeirdEvent == null)
            {
                return;
            }

            AbstractWeirdEvent.OnStartEvent();
        }

        public void EndEvents()
        {
            if (AbstractWeirdEvent == null)
            {
                return;
            }

            var currentWeirdEvent = AbstractWeirdEvent;
            AbstractWeirdEvent = null;

            currentWeirdEvent.OnEndEvent();
            Destroy(currentWeirdEvent.gameObject);
        }

        public void ReplaceAndStartEvent(GameObject prefab)
        {
            EndEvents();    

            if (AbstractWeirdEvent != null) // 2차 방어선
            {
                Destroy(AbstractWeirdEvent.gameObject);
            }

            if (prefab == null)
            {
                AbstractWeirdEvent = null; // 없을 때는 하지말기 (초반에는 없음)
                return;
            }

            GameObject instance = Instantiate(prefab, WeirdEventSpawner);
            AbstractWeirdEvent = instance.GetComponent<AbstractWeirdEvent>();

            Debug.Log("설문 이름:" + AbstractWeirdEvent);

            StartEvents();
        }
    }
}
