using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private SceneTransitions st;
    private void Start()
    {
        st = GameObject.Find("TransitionPanel").GetComponent<SceneTransitions>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            StartCoroutine(st.Transition());
        }
    }
}
