using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace Typewriter
{
    [RequireComponent(typeof(TMP_Text))]
    public class TypewriterEffect : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textBox;
        [Range(0,1)] public float TextSpeed = 0.85f; 

        public void SetText(string story)
        {
            StartCoroutine("PlayText", story);
        }
        private IEnumerator PlayText(string story)
        {
            foreach (char c in story) 
            {
                _textBox.text += c;
                yield return new WaitForSeconds (1-TextSpeed);
            }
        }
    }
}