using KDH.Scripts.Rooms;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurtainClickHotspot : ClickHotspot
{
    [SerializeField] private CurtainRoom curtainRoom;

    public override void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(curtainRoom.SetAnim());

        onClick?.Invoke();
    }
}
