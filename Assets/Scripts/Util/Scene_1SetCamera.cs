using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Scene_1SetCamera : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    void Start()
    {
        pm.canMove = false;
    }

    public void TransBackZero()
    {
        transform.rotationTransition(Quaternion.Euler(0,0,0),1);
    }
}
