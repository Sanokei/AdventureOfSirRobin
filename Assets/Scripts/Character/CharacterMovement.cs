using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Utils;
using Lean.Transition;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] InspectableDictionary<string, Transform> TargetPosition;
    [SerializeField] InspectableDictionary<string, PlayableDirector> Movement;
    public void Move(string Target)
    {
        char LorR;
        // assuming it cant be the same target you are at now
        int time = (int)Mathf.Abs((playerCamera.transform.position - TargetPosition[Target].position).x / 10);
        if((playerCamera.transform.position - TargetPosition[Target].position).x > 0)
            LorR = 'L';
        else
            LorR = 'R';
        Movement[$"Run{LorR}"].Play();
        playerCamera.transform.localPositionTransition(TargetPosition[Target].position, time)
        .EventTransition(() => Movement[$"Idle{LorR}"].Play(), time);
    }
}
