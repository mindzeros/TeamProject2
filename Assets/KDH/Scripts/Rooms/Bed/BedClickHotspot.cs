using KDH.Scripts.Systems;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BedClickHotspot : ClickHotspot
{
    [SerializeField] private GameObject blackground, bedding;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.Survey.HasCompletedSurvey)
        {
            StartCoroutine(Sleep());
        }

        onClick?.Invoke();
    }

    private IEnumerator Sleep()
    {
        bedding.SetActive(true);
        yield return new WaitForSeconds(3f);
        bedding.SetActive(false);
    }
}
