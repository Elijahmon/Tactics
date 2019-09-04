using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController :  UIController
{

    [SerializeField]
    GameObject _menuUI;
    [SerializeField]
    GameObject _battleUI;

    public override void Init()
    {
        base.Init();
        ToggleMenuUI(true);
        ToggleBattleUI(false);
    }

    public void OnStartGamePressed()
    {
        GameStateManager.instance.StartGame();
    }

    public void ToggleMenuUI(bool toggle)
    {
        _menuUI.SetActive(toggle);
    }

    public void ToggleBattleUI(bool toggle)
    {
        _battleUI.SetActive(toggle);
    }

}
