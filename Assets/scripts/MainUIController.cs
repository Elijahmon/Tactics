using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController :  UIController
{

    [SerializeField]
    MenuUIController _menuUI;
    [SerializeField]
    BattleUIController _battleUI;

    public override void Init()
    {
        base.Init();
        _menuUI.Init();
        ToggleMenuUI(true);
        _battleUI.Init();
        ToggleBattleUI(false);
    }

    public void ToggleMenuUI(bool toggle)
    {
        _menuUI.gameObject.SetActive(toggle);
    }

    public void ToggleBattleUI(bool toggle)
    {
        _battleUI.gameObject.SetActive(toggle);
    }

}
