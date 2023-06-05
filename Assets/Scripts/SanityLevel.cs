using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SanityLevel : MonoBehaviour
{
    [SerializeField] private RectTransform sanityBar;
    public float sanityPercent = 100f;
    public float lostRate = 1f;
    private bool onSafeSquare=false;
    private float sanityBarLength;
    private void Start()
    {
        sanityBarLength = sanityBar.rect.width;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onSafeSquare = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onSafeSquare = false;
        }
    }
    void Update()
    {
        if (sanityPercent > 100)
        {
            sanityPercent = 100;
        }
        if (sanityPercent >= 0 && !onSafeSquare)
            sanityPercent -= Time.deltaTime * lostRate;
        SetSanityBarLength();
    }
    void SetSanityBarLength()
    {
        sanityBar.sizeDelta = new Vector2(sanityBarLength * 0.01f * sanityPercent, sanityBar.rect.height);
    }
}
