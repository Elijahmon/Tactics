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
    [SerializeField]
    PlayerController _playerController;

    Player _player;
    int loadedLevel;

    void Awake()
    {
        
        Object.DontDestroyOnLoad(this);
        instance = this;
        _battle.Init();
        _ui.Init();
        currentState = GameState.MENU;
        loadedLevel = 1;
        _playerController.Init(CreateNewPlayer("Default"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player CreateNewPlayer(string name)
    {
        _player = new Player(name);
        return _player;
    }

    public void StartGame(int levelID)
    {
        currentState = GameState.BATTLE;
        _ui.ToggleMenuUI(false);
        _ui.ToggleBattleUI(true);
        Debug.Log("Loading Scene " + levelID);
        _battle.LoadLevel(levelID);
    }

    public void ExitBattle()
    {
        if(currentState == GameState.BATTLE)
        {
            _battle.UnloadLevel(_battle.GetLoadedLevelID());
            currentState = GameState.MENU;
            _ui.ToggleBattleUI(false);
            _ui.ToggleMenuUI(true);
        }
    }

    #region Getters
    public GameState GetGameState()
    {
        return currentState; 
    }
    public Player GetPlayer()
    {
        return _player;
    }
    #endregion
}
