using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public enum BATTLE_STATE {INACTIVE, LOADING, ACTIVE, SUCCESS, FAIL}
    BATTLE_STATE currentState;

    [SerializeField]
    Camera _cam;
    [SerializeField]
    Transform levelTransform;

    LevelManager currentLevel;

    public void Init()
    {
        currentState = BATTLE_STATE.INACTIVE;
    }

    public void LoadLevel(int levelId)
    {
        currentState = BATTLE_STATE.LOADING;
        StartCoroutine(LoadLevelAsync(levelId));
    }

    IEnumerator LoadLevelAsync(int levelId)
    {
        
        AsyncOperation load = SceneManager.LoadSceneAsync(levelId);
        while(!load.isDone)
        {
            yield return null;
        }
        
        Debug.Log("Scene " + levelId + " Loaded!");

        currentLevel = FindObjectOfType<LevelManager>();
        currentLevel.Init(levelTransform);

        currentState = BATTLE_STATE.ACTIVE;
    }
}
