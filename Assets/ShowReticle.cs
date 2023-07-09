using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReticle : MonoBehaviour
{
    [SerializeField] Image ret;
    public bool showRet{get;set;}
    void Update()
    {
        ret.color = new Color(255f,255f,255f, (showRet ? 255f : 0f));
    }
}
