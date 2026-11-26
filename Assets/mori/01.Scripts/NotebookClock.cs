using KDH.Scripts.Systems;
using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class NotebookClock : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private TMP_Text clockText;

    private DateTime startDate = DateTime.Today;
    private int startMinutes = 8 * 60;
    private int endMinutes = 21 * 60;

    public DateTime CurrentTime { get; private set; }

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.Survey.OnSurveyCompleted += RefreshClock;
        gameManager.OnDayChanged += RefreshClock;
        RefreshClock();
    }

    private void OnDestroy()
    {
        gameManager.Survey.OnSurveyCompleted -= RefreshClock;
        gameManager.OnDayChanged -= RefreshClock;
    }

    private void RefreshClock()
    {
        int total = gameManager.TodaySurveies.list.Count;
        int completed = gameManager.Survey.CompletedSurveyCount;
        int elapsed = total == 0 ? 0 : (int)Math.Round(
            (endMinutes - startMinutes) * (double)completed / total);

        CurrentTime = startDate.
            AddDays(gameManager.CurrentDay).
            AddMinutes(startMinutes + elapsed);
        clockText.SetText(CurrentTime.ToString(
            "tt h:mm\nyyyy-MM-dd",
            CultureInfo.GetCultureInfo("ko-KR")));
    }
}
