using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private float spikeActivationTime;
    private Animator anim;
    public enum SpikeState
    {
        INACTIVE, ACTIVE, LETHAL
    }
    public SpikeState state = SpikeState.INACTIVE;
    void Start()
    {
        anim = GetComponent<Animator>();
        spikeActivationTime = 0f;
    }
    private void Update()
    {
        if (state == SpikeState.ACTIVE && Time.time>spikeActivationTime + 0.45f)
        {
            state = SpikeState.LETHAL;
        }
        else if ( state == SpikeState.LETHAL && Time.time > spikeActivationTime + 0.6f)
        {
            state = SpikeState.INACTIVE;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("SpikeActivate");
            spikeActivationTime = Time.time;
            state = SpikeState.ACTIVE;
        }
        
    }
}
