using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private SanityLevel sanityLevel;
    private PlayerMovement playerMovement;
    private SpikeScript spikeScript;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        sanityLevel = GetComponent<SanityLevel>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hole")
        {
            sanityLevel.sanityPercent *= 0f;
        }
        if (collision.gameObject.tag == "Spike")
        {
            spikeScript = collision.gameObject.GetComponent<SpikeScript>();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            if (spikeScript.state == SpikeScript.SpikeState.LETHAL)
            {
                sanityLevel.sanityPercent *= 0f;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spike" && spikeScript.state == SpikeScript.SpikeState.LETHAL)
        {
            spikeScript = null;
        }
    }
    private void Update()
    {
        if (sanityLevel.sanityPercent <= 0f) 
        {
            playerMovement.playerStatus = false;
        }
    }
}
