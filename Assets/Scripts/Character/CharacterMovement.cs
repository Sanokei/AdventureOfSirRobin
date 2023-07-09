using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Utils;
using Lean.Transition;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] List<Transform> TargetPosition;
    [SerializeField] List<PlayableDirector> Movement;
    public void Move(int Target)
    {
        playerCamera.transform.localPositionTransition(TargetPosition[Target].position,2);
    }
}
