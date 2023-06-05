using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonPopIn : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(Time.time > startTime + 11) 
        {
            button.SetActive(true);
        }
    }
}
