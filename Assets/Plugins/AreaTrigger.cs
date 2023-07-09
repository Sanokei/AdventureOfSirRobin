using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public delegate void OnAreaTriggered(GameObject self, Collider other);
    public static event OnAreaTriggered OnEnterEvent;
    public static event OnAreaTriggered OnExitEvent;
    public static event OnAreaTriggered OnStayEvent;
    private void OnTriggerEnter(Collider other)
    {
        OnEnterEvent?.Invoke(gameObject, other);
    }
    private void OnTriggerExit(Collider other)
    {
        OnExitEvent?.Invoke(gameObject, other);
    }
    private void OnTriggerStay(Collider other)
    {
        OnExitEvent?.Invoke(gameObject, other);
    }
}
