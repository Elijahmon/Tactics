using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    GameStateManager _gameState;
    [SerializeField]
    BattleManager _battle;
    [SerializeField]
    MainUIController _ui;

    bool oldLeftMouse;
    bool oldRightMouse;
    bool oldConfirm;
    bool oldCancel;

    bool leftMouse;
    bool rightMouse;
    bool confirm;
    bool cancel;
    Vector2 mousePostion;
    float scroll;

    public void Init()
    {

    }

    private void Update()
    {
        
        leftMouse = Input.GetAxis(InputReference.LMB) > 0? true : false;
        rightMouse = Input.GetAxis(InputReference.RMB) > 0 ? true : false;
        confirm = Input.GetAxis(InputReference.CONFIRM) > 0 ? true : false;
        cancel = Input.GetAxis(InputReference.CANCEL) > 0 ? true : false;
        mousePostion = Input.mousePosition;
        scroll = Input.GetAxis(InputReference.SCROLL);
    }

    private void FixedUpdate()
    {
        switch(_gameState.GetGameState())
        {
            case GameStateManager.GameState.MENU:
                HandleInputMenu();
                break;
            case GameStateManager.GameState.BATTLE:
                HandleInputBattle();
                break;
            case GameStateManager.GameState.GAME_OVER:
                HandleInputGameOver();
                break;
        }
    }

    void HandleInputMenu()
    {

    }

    void HandleInputBattle()
    {
        #region Buttons
        if(oldLeftMouse != leftMouse)
        {
            if(leftMouse)
            {
                _battle.ProcessLMBDownInput(mousePostion);
            }
            else
            {
                _battle.ProcessLMBUpInput(mousePostion);
            }
            oldLeftMouse = leftMouse;
        }
        if (oldRightMouse != rightMouse)
        {
            if (rightMouse)
            {
                _battle.ProcessRMBDownInput(mousePostion);
            }
            else
            {
                _battle.ProcessRMBUpInput(mousePostion);
            }
            oldRightMouse = rightMouse;
        }
        #endregion

        #region Movement
        _battle.ProcessMousePosition(mousePostion);
        _battle.ProcessScrollInput(scroll);
        #endregion
    }

    void HandleInputGameOver()
    {

    }
}
