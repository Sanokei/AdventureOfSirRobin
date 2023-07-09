using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Timers;
using TMPro;
using System;

public class InventoryTimerManager : MonoBehaviour
{
    [HideInInspector] public List<InventoryTimer> timers = new List<InventoryTimer>();
    [SerializeField] TMP_Text TimerText;
    [SerializeField] TMP_Text TaskText;
    [SerializeField] PlayableDirector TenSecRemaining;
    public static InventoryTimerManager Instance;
    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }
    void OnEnable()
    {
        InventoryTimerAdd.TimerCreateEvent += (t) => {Instance.timers.Add(t);};
        InventoryTimer.TimerGoneEvent += (t) => {Instance.timers.Remove(t);};
    }
    void OnDisable()
    {
        InventoryTimerAdd.TimerCreateEvent -= (t) => {Instance.timers.Add(t);};
        InventoryTimer.TimerGoneEvent -= (t) => {Instance.timers.Remove(t);};
    }

    void Update()
    {
        if(timers.Count > 0)
        {
            if(TimersManager.IsTimerPaused(timers[0].Timer))
            {
                TimersManager.SetPaused(timers[0].Timer, false);
            }
            float timeRemaining = TimersManager.RemainingTime(timers[0].Timer);
            TimeSpan t = TimeSpan.FromSeconds( (double)timeRemaining );
            TimerText.text = $"{t.Minutes:D2}m:{t.Seconds:D2}s;{t.Milliseconds:D2}ms";
            TaskText.text = timers[0].Task;
            if(t.Seconds == 13)
            {
                TenSecRemaining.Play();
            }
            if(t.Seconds <= 15)
            {
                TimerText.color = Color.red;
            }
        }
        if(timers.Count == 0 && TimerText.text != "00m:00s;000ms")
        {
            TenSecRemaining?.Stop();
            TimerText.text = "00m:00s;000ms";
            TimerText.color = Color.white;
            TaskText.text = "";
        }
    }
}
