using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    GameStateManager _gameState;

    bool leftMouse;
    bool rightMouse;
    bool confirm;
    bool cancel;

    public void Init()
    {

    }

    private void Update()
    {
        leftMouse = Input.GetAxis(InputReference.LMB) > 0? true : false;
        rightMouse = Input.GetAxis(InputReference.RMB) > 0 ? true : false;
        confirm = Input.GetAxis(InputReference.CONFIRM) > 0 ? true : false;
        cancel = Input.GetAxis(InputReference.CANCEL) > 0 ? true : false;
    }

    private void FixedUpdate()
    {
        
    }
}
