using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    int loadedLevel;

    public enum BATTLE_STATE {INACTIVE, LOADING, ACTIVE, SUCCESS, FAIL}
    BATTLE_STATE currentState;

    [SerializeField]
    BattleUIController _ui;
    [SerializeField]
    PlayerController _player;
    [SerializeField]
    Camera _cam;
    [SerializeField]
    Transform _levelTransform;

    LevelManager currentLevel;

    public void Init()
    {
        loadedLevel = -1;
        instance = this;
        currentState = BATTLE_STATE.INACTIVE;
    }

    public void SpawnPlayerCharacter(Vector3 position)
    {
        _player.SpawnCharacter(position);
    }

    public void DespawnCharacterEscaped(PlayerCharacterController character)
    {
        _player.Deselect();
        _player.DespawnCharacter(character);
    }

    public void UpdateObjectiveUI(List<LevelObjective> objectives)
    {
        _ui.UpdateObjectiveList(objectives);
    }

    public void EndBattleVictory()
    {
        currentState = BATTLE_STATE.SUCCESS;
        _ui.ToggleVictoryScreen(true);
    }

    public void LoadLevel(int levelId)
    {
        currentState = BATTLE_STATE.LOADING;
        _ui.ToggleLoadingScreen(true);
        StartCoroutine(LoadLevelAsync(levelId));
    }

    IEnumerator LoadLevelAsync(int levelId)
    {
        
        AsyncOperation load = SceneManager.LoadSceneAsync(levelId);
        while(!load.isDone)
        {
            yield return null;
        }
        
        //Debug.Log("Scene " + levelId + " Loaded!");
        _ui.ToggleLoadingScreen(false);

        currentLevel = FindObjectOfType<LevelManager>();
        currentLevel.Init(this, _levelTransform);
        loadedLevel = levelId;
        currentState = BATTLE_STATE.ACTIVE;
    }

    public List<PlayerCharacterController> GetPlayerCharacters()
    {
        return _player.GetCharacters();
    }

    public void ExitBattle()
    {
        if(currentState != BATTLE_STATE.INACTIVE)
        {
            GameStateManager.instance.ExitBattle();
        }
    }

    public void UnloadLevel(int levelId)
    {
        _ui.ToggleVictoryScreen(false);
        _ui.ToggleLoadingScreen(true);
        _player.Deselect();
        currentLevel.Unload();
    }



    public int GetLoadedLevelID()
    {
        return loadedLevel;
    }

    #region Input
    public void ProcessLMBDownInput(Vector2 mousePosition)
    {
        switch(currentState)
        {
            case BATTLE_STATE.ACTIVE:
                _player.ProcessLMBInput(mousePosition);
                break;
        }
    }
    public void ProcessLMBUpInput(Vector2 mousePosition)
    {
        switch (currentState)
        {
            case BATTLE_STATE.ACTIVE:
                break;
        }
    }
    public void ProcessRMBDownInput(Vector2 mousePosition)
    {
        switch (currentState)
        {
            case BATTLE_STATE.ACTIVE:
                _player.ProcessRMBInput(mousePosition);
                break;
        }
    }
    public void ProcessRMBUpInput(Vector2 mousePosition)
    {
        switch (currentState)
        {
            case BATTLE_STATE.ACTIVE:
                break;
        }
    }
    public void ProcessConfirmInput(bool input)
    {
        switch (currentState)
        {
            case BATTLE_STATE.ACTIVE:
                _player.ProcessConfirmInput(input);
                break;
        }
    }
    public void ProcessCancelInput(bool input)
    {
        switch (currentState)
        {
            case BATTLE_STATE.ACTIVE:
                _player.ProcessCancelInput(input);
                break;
        }
    }
    public void ProcessMousePosition(Vector2 mousePosition)
    {
        switch(currentState)
        {
            case BATTLE_STATE.ACTIVE:
                _ui.UpdateCursorPosition(mousePosition);
                _player.ProcessMousePosition(mousePosition);
                break;
        }
    }
    #endregion

    //TODO: Remove
    IEnumerator UnloadLevelAsync(int levelId)
    {
        AsyncOperation load = SceneManager.UnloadSceneAsync(levelId);
        while (!load.isDone)
        {
            yield return null;
        }
        _ui.ToggleLoadingScreen(false);
        loadedLevel = -1;
        currentState = BATTLE_STATE.INACTIVE;
    }
}
