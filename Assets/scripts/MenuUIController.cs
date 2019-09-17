using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIController : UIController
{
    [SerializeField]
    Button startGameButton;
    [SerializeField]
    TMP_Dropdown levelSelect;

    int selectedLevel;

    public override void Init()
    {
        base.Init();

        List<string> levels = new List<string>();
        for(int i = SceneManager.sceneCountInBuildSettings-1; i > 0; i--)
        {
            levels.Add("Level " + i);
        }

        levelSelect.AddOptions(levels);
        OnDropDownSelect();
    }

    public void OnStartGamePressed()
    {
        GameStateManager.instance.StartGame(selectedLevel);
    }

    public void OnDropDownSelect()
    {
        selectedLevel = levelSelect.value+1;
    }
}
