using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsHandManager : MonoBehaviour
{
    public delegate void TimerSuccess();
    public static event TimerSuccess TimerSuccessEvent;
    public static GodsHandManager Instance;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip AudioSuccess;
    [SerializeField] AudioClip AudioFailure;
    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }
    public string LookingFor{get;set;}
    void OnEnable()
    {
        AreaTrigger.OnEnterEvent += OnEnter;
    }

    void OnDisable()
    {
        AreaTrigger.OnEnterEvent -= OnEnter;
    }

    void OnEnter(GameObject self, Collider other)
    {
        // fine for now ig
        if(self.name == "godhand" && other.transform.tag == "pickable")
        {
            if(other.name.ToLower() == LookingFor.ToLower())
            {
                // InventoryTimerManager.Instance.timers[0].Timer(); // dont do this, this will get rid of a heart
                TimerSuccessEvent?.Invoke();
                Destroy(InventoryTimerManager.Instance.timers[0].gameObject);
                AudioSource.clip = AudioSuccess;
                AudioSource.Play();
            }
            else
            {
                InventoryTimerManager.Instance.timers[0].SubTimeButton(10f);
                AudioSource.clip = AudioFailure;
                AudioSource.Play();
            }
        }
    }
}
