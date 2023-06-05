using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyCollect : MonoBehaviour
{
    [SerializeField] private SanityLevel sanityLevel;
    public float sanityBonus = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Firefly")
        {
            sanityLevel.sanityPercent += sanityBonus;
            Destroy(collision.gameObject);
        }
    }
}
