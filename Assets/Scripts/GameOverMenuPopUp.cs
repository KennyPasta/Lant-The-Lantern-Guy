using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuPopUp : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform gameOverMenu;
    private void Update()
    {
        if(playerMovement.playerStatus == false)
        {
            StartCoroutine(ShowMenu());
        }
    }
    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(1);
        gameOverMenu.gameObject.SetActive(true);
    }
}
