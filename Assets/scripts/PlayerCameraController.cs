using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public enum CAMERA_MODE { FREE, CHASE, LOCKED}

    [SerializeField]
    Camera _cam;
    [SerializeField]
    Collider _coll;
    [SerializeField]
    Rigidbody _rigidbody;
    [SerializeField]
    Transform chaseTarget;

    [SerializeField]
    float leftMovementBounds;
    [SerializeField]
    float rightMovementBounds;
    [SerializeField]
    float upperMovementBounds;
    [SerializeField]
    float LowerMovementBounds;
    [SerializeField]
    int maxY;
    [SerializeField]
    int minY;


    [SerializeField]
    float chaseLerpSpeeed;
    [SerializeField]
    int minXOffset;
    [SerializeField]
    int maxXOffset;
    [SerializeField]
    float panSpeed;
    [SerializeField]
    float zoomSpeed;

    CAMERA_MODE currentMode;
    float xOffset;

    public void Init()
    {
        currentMode = CAMERA_MODE.FREE;
        xOffset = minXOffset;
        transform.position = new Vector3(transform.position.x, minY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = Vector3.Lerp(transform.position, new Vector3(chaseTarget.position.x + xOffset, transform.position.y, chaseTarget.position.z), chaseLerpSpeeed);
    }

    #region Input
    public void ProcessMousePosition(Vector2 mousePosition)
    {
        if (currentMode == CAMERA_MODE.FREE)
        {
            Vector2 viewportPos = _cam.ScreenToViewportPoint(mousePosition);
            Vector3 newPos = chaseTarget.transform.position;

            if (viewportPos.x > rightMovementBounds)
            {
                newPos = new Vector3(newPos.x, newPos.y, newPos.z + panSpeed);
            }
            if (viewportPos.x < leftMovementBounds)
            {
                newPos = new Vector3(newPos.x, newPos.y, newPos.z - panSpeed);
            }
            if (viewportPos.y > upperMovementBounds)
            {
                newPos = new Vector3(newPos.x - panSpeed, newPos.y, newPos.z);
            }
            if (viewportPos.y < LowerMovementBounds)
            {
                newPos = new Vector3(newPos.x + panSpeed, newPos.y, newPos.z);
            }
            chaseTarget.transform.position = newPos;
        }
    }
    public void ProcessScrollInput(float input)
    {
        input *= zoomSpeed;
        xOffset = Mathf.Clamp(xOffset - input, minXOffset, maxXOffset);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - input, minY, maxY), transform.position.z);
    }
    #endregion

    public void ActivateChaseCamera()
    {
        currentMode = CAMERA_MODE.CHASE;
    }
    public void ActivateFreeCamera()
    {
        currentMode = CAMERA_MODE.FREE;
    }

    public Camera GetCamera()
    {
        return _cam;
    }
}
