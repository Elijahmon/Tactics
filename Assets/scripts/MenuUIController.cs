using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : UIController
{
    public void OnStartGamePressed()
    {
        GameStateManager.instance.StartGame();
    }
}
