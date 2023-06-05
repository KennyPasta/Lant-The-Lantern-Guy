using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float followSpeed = 0.2f;
    private SanityLevel sanityLevel;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        sanityLevel = target.gameObject.GetComponent<SanityLevel>();
    }
    
    void FixedUpdate()
    {
        float targetCameraSize = Zoom(sanityLevel.sanityPercent);
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);
        transform.position = smoothedPosition;
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetCameraSize, 0.1f);
    }
    float Zoom(float sanity)
    {
        float cameraSize = 1.5f + 0.025f*sanity;
        return cameraSize;
    }
}
