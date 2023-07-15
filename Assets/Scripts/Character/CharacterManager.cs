using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Lean.Transition;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    public delegate void CharacterStateChange(CharacterState state);
    public event CharacterStateChange OnCharacterStateChange;
    [SerializeField] GameObject Character;
    [SerializeField] private InspectableDictionary<CharacterState, Animator> Animators;

    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }

    void OnEnable()
    {
        OnCharacterStateChange += StateChange;
    }

    void OnDisable()
    {
        OnCharacterStateChange -= StateChange;
    }


    private CharacterState _state = CharacterState.Default;
    public CharacterState state
    {
        get
        {
            return _state;
        }
        set
        {
            if(value != _state)
            {
                ClearFrame();
                OnCharacterStateChange?.Invoke(value);
                _state = value;
            }
        }
    }

    public enum CharacterState
    {
        Default,
        Idle,
        Jump,
        Fall,
        Run,
        TakeHit,
        Death,
        Attack1,
        Attack2,
        Attack3,
        Attack4
    }
    public void FlipCharacter()
    {
        Character.transform.Rotate(0f,180f,0f);
    }
    public void FlipCharLeft()
    {
        Character.transform.rotation = Quaternion.Euler(Character.transform.rotation.x, 180f, Character.transform.rotation.z);
    }
    public void FlipCharRight()
    {
        Character.transform.rotation = Quaternion.Euler(Character.transform.rotation.x, 0, Character.transform.rotation.z);
    }
    public void CharJump()
    {
        Character.transform
            .localPositionTransition(new Vector3(Character.transform.position.x,Character.transform.position.y + 2,Character.transform.position.z),0.4f)
            .JoinTransition()
            .localPositionTransition(Character.transform.position,0.2f);
    }
    void StateChange(CharacterState state)
    {
        Animators[state].gameObject.SetActive(true);
    }
    void ClearFrame()
    {
        foreach (Animator ani in Animators.Values)
        {
            ani.gameObject.SetActive(false);
        }
    }
}
