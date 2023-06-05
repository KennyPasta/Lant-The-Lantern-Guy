using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float fadeInStartTime;
    private float startTime;
    private float fadeInSpeed = 1f;
    private void Start()
    {
        text=GetComponent<TextMeshProUGUI>();
        startTime = Time.time;
        text.color = new Color(255, 255, 255, 0);
    }
    private void Update()
    {
        if(Time.time > startTime + fadeInStartTime)
        {
            FadeInText();
        }
    }
    private void FadeInText()
    {
        text.color = new Color(255, 255, 255, (Time.time-startTime-fadeInStartTime)*fadeInSpeed);
        
    }
}
