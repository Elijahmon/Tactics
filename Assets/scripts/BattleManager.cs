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
    List<PlayerCharacterController> playerCharacters;
    List<EnemyCharacterController> enemyCharacters;

    public void Init()
    {
        loadedLevel = -1;
        instance = this;
        currentState = BATTLE_STATE.INACTIVE;
        _player.Init(GameStateManager.instance.GetPlayer());
        playerCharacters = new List<PlayerCharacterController>();
        enemyCharacters = new List<EnemyCharacterController>();
    }

    public void SpawnPlayerCharacter(Vector3 position)
    {
       playerCharacters.Add(_player.SpawnCharacter(position));
    }

    public void DespawnCharacterEscaped(PlayerCharacterController character)
    {
        _player.Deselect();
        playerCharacters.Remove(character);
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
        _player.InitForLevel(_levelTransform);
        loadedLevel = levelId;
        currentState = BATTLE_STATE.ACTIVE;
    }

    public void ExitBattle()
    {
        if(currentState != BATTLE_STATE.INACTIVE)
        {
            playerCharacters.Clear();
            enemyCharacters.Clear();
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



    #region Util
    public float GetDistanceBetween(PlayerCharacterController a, PlayerCharacterController b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
    public float GetDistanceBetween(PlayerCharacterController a, EnemyCharacterController b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
    public float GetDistanceBetween(EnemyCharacterController a, PlayerCharacterController b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
    #endregion

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
    public void ProcessScrollInput(float input)
    {
        switch(currentState)
        {
            case BATTLE_STATE.ACTIVE:
                _player.ProcessScrollInput(input);
                break;
        }
    }
    #endregion

    #region Getters
    public int GetLoadedLevelID()
    {
        return loadedLevel;
    }
    public List<PlayerCharacterController> GetPlayerCharacters()
    {
        return playerCharacters;
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
