using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimation;
    private int sceneIndex;
    public IEnumerator Transition() 
    {
        transitionAnimation.SetTrigger("EndTrigger");
        yield return new WaitForSeconds(0.8f);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
