using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTimerAdd : MonoBehaviour
{
    public delegate void TimerCreate(InventoryTimer timer);
    public static event TimerCreate TimerCreateEvent;
    [SerializeField] InventoryTimer Prefab;
    [SerializeField] Transform Parent;
    public float Time{get;set;}
    public string Task{get;set;}

    public void AddTimer()
    {
        InventoryTimer ITM = Instantiate(Prefab,Parent);
        ITM.CreateTimer(Time, Task);

        TimerCreateEvent?.Invoke(ITM);
    }
}
