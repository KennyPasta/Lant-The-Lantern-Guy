using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private float delayTime = 0.3f;
    private float lastMoveTime;
    public bool playerStatus = true;
    private Animator anim;
    private enum LookDirection
    {
        DOWN , UP, LEFT , RIGHT
    }
    private LookDirection lookDirection = LookDirection.DOWN;

    private Vector3 targetPosition;
    void Start()
    {
        lastMoveTime = Time.time;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        bool isWall = false;
        targetPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.W) && Time.time > lastMoveTime + delayTime && playerStatus == true)
        {
            lookDirection = LookDirection.UP;
            targetPosition += new Vector3(0, 1, 0);
            lastMoveTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Time.time > lastMoveTime + delayTime && playerStatus == true)
        {
            lookDirection = LookDirection.LEFT;
            targetPosition += new Vector3(-1, 0, 0);
            lastMoveTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.S) && Time.time > lastMoveTime + delayTime && playerStatus == true)
        {
            lookDirection = LookDirection.DOWN;
            targetPosition += new Vector3(0, -1, 0);
            lastMoveTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.D) && Time.time > lastMoveTime + delayTime && playerStatus == true)   
        {
            lookDirection = LookDirection.RIGHT;
            targetPosition += new Vector3(1, 0, 0);
            lastMoveTime = Time.time;
        }
        Collider2D[] collider = Physics2D.OverlapCircleAll(targetPosition, 0.1f);
        foreach(Collider2D col in collider)
        {
            if (col.CompareTag("Wall")) 
            {
                isWall = true;
                break;
            }
        }
        if(isWall == false)
            transform.position = targetPosition;
        anim.SetInteger("lookDirectionInt", (int)lookDirection);
    }
}
