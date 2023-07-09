using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandManager : MonoBehaviour
{
    RaycastHit ObjectInHand;
    [HideInInspector] public bool inHand;
    [SerializeField] Camera _Camera;
    [SerializeField] Transform Parent;
    Ray ray;
    RaycastHit hitData;
    public static PlayerHandManager Instance;
    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(_Camera.ScreenPointToRay(Input.mousePosition), out hitData, 10f , 1, QueryTriggerInteraction.Ignore) && !inHand && hitData.transform.tag == "pickable")
            {
                inHand = true;
                hitData.rigidbody.isKinematic = true;
                hitData.collider.isTrigger = true;
                hitData.transform.position = transform.position;
                hitData.transform.SetParent(transform);
                ObjectInHand = hitData;
                hitData.transform.tag = "Untagged";
            }
            else if(inHand)
            {
                inHand = false;
                ObjectInHand.rigidbody.isKinematic = false;
                ObjectInHand.collider.isTrigger = false;
                ObjectInHand.transform.SetParent(Parent);
                ObjectInHand.transform.tag = "pickable";
            }
        }
    }
}
