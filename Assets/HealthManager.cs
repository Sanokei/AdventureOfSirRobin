using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public delegate void Death();
    public static event Death OnDeathEvent;
    int Health = 3;
    [SerializeField] List<Image> Hearts;
    [SerializeField] Sprite BrokenHeart;

    void OnEnable()
    {
        InventoryTimer.TimerFinishEvent += KillHeart;
    }

    void OnDisable()
    {
        InventoryTimer.TimerFinishEvent -= KillHeart;
    }

    void KillHeart(InventoryTimer timer)
    {
        Hearts[3 - Health].sprite = BrokenHeart;
        --Health;
        if(3 - Health == 3)
            OnDeathEvent?.Invoke();
    }
}
