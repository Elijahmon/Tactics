using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public enum CAMERA_MODE { CHASE, FREE, LOCKED}

    [SerializeField]
    Camera _cam;

    [SerializeField]
    float leftMovementBounds;
    [SerializeField]
    float rightMovementBounds;
    [SerializeField]
    float upperMovementBounds;
    [SerializeField]
    float LowerMovementBounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessMousePosition(Vector2 mousePosition)
    {
        Vector2 viewportPos = _cam.ScreenToViewportPoint(mousePosition);
        if(viewportPos.x > rightMovementBounds)
        {
            //TODO: Move Right
        }
        if(viewportPos.x < leftMovementBounds)
        {
            // TODO: Move Left
        }
        if(viewportPos.y > upperMovementBounds)
        {
            //TODO: Move Up
        }
        if(viewportPos.y < LowerMovementBounds)
        {
            //TODO: Move Down
        }
    }

    public Camera GetCamera()
    {
        return _cam;
    }
}
