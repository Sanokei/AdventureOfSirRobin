using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class InventoryTimer : MonoBehaviour
{
    public delegate void TimerFinish(InventoryTimer timer);
    public static event TimerFinish TimerFinishEvent;
    public delegate void TimerGone(InventoryTimer timer);
    public static event TimerGone TimerGoneEvent;
    public float Time;
    public string Task;

    public void Timer()
    {
        TimerFinishEvent?.Invoke(this);
        Destroy(gameObject);
    }
    void OnDisable()
    {
        TimerGoneEvent?.Invoke(this);
        TimersManager.ClearTimer(Timer);
    }

    public void CreateTimer(float seconds, string task)
    {
        TimersManager.SetTimer(this, seconds, Timer);
        TimersManager.SetPaused(Timer, true);
        Time = TimersManager.RemainingTime(Timer);
        Task = task;
    }
    public void SubTimeButton(float seconds)
    {
        float timeRemaining = TimersManager.RemainingTime(Timer);
        if(timeRemaining - seconds <= 0)
        {
            Timer();
        }
        else
        {
            TimersManager.ClearTimer(Timer);
            TimersManager.SetTimer(this, timeRemaining - seconds, Timer);
        }
    }
}
