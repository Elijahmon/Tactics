using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public static GameStateManager instance;

    public enum GameState { MENU, BATTLE, GAME_OVER}
    GameState currentState;

    [SerializeField]
    InputHandler _input;
    [SerializeField]
    MainUIController _ui;
    [SerializeField]
    BattleManager _battle;

    void Awake()
    {
        Object.DontDestroyOnLoad(this);
        instance = this;
        currentState = GameState.MENU;
        _ui.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        currentState = GameState.BATTLE;
        _ui.ToggleMenuUI(false);
        _ui.ToggleBattleUI(true);
        _battle.LoadLevel(1);
    }

    #region Getters
    public GameState GetGameState()
    {
        return currentState; 
    }
    #endregion
}
