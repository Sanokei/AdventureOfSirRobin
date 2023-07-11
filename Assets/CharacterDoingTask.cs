using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterDoingTask : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] Image Slider;
    [SerializeField] List<PlayableDirector> pd;
    int tasknum = 0;
    void OnEnable()
    {
        InventoryTimer.TimerFinishEvent += DoNextTask;
        GodsHandManager.TimerSuccessEvent += DoNextTask;
    }

    void OnDisable()
    {
        InventoryTimer.TimerFinishEvent -= DoNextTask;
        GodsHandManager.TimerSuccessEvent -= DoNextTask;
    }
    void DoNextTask(InventoryTimer L)
    {
        DoNextTask();
    }
    void DoNextTask()
    {
        if(tasknum == 4)
            SceneManager.LoadScene("Scene_2");
        pd[tasknum].Play();
        tasknum++;
    }
}
