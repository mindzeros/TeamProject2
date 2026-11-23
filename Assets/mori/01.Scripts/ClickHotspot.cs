using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickHotspot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected UnityEvent onClick = new UnityEvent();

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onClick.Invoke();
        }
    }
}