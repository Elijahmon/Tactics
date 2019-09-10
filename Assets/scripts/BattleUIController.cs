using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIController : UIController
{
    [SerializeField]
    Camera _cam;
    [SerializeField]
    GameObject loadingScreen;
    [SerializeField]
    GameObject victoryScreen;
    [SerializeField]
    GameObject objectiveScreen;
    [SerializeField]
    List<ObjectiveUIItemController> objectiveSlots;
    [SerializeField]
    RectTransform cursor;

    public override void Init()
    {
        ToggleLoadingScreen(false);
        ToggleVictoryScreen(false);
        ToggleObjectiveScreen(false);
        foreach(ObjectiveUIItemController objectiveSlot in objectiveSlots)
        {
            objectiveSlot.Init();
        }
    }
    
    public void ToggleLoadingScreen(bool toggle)
    {
        loadingScreen.SetActive(toggle);
    }

    public void ToggleVictoryScreen(bool toggle)
    {
        victoryScreen.SetActive(toggle);
    }

    public void ToggleObjectiveScreen(bool toggle)
    {
        objectiveScreen.SetActive(true);
    }

    public void UpdateObjectiveList(List<LevelObjective> objectives)
    {
        int i = 0;
        foreach (var slot in objectiveSlots)
        {
            slot.UpdateItem(objectives[i]);
            i++;
        }
    }

    public void UpdateCursorPosition(Vector2 mousePosition)
    {
       cursor.anchoredPosition = _cam.ScreenToViewportPoint(mousePosition);
    }

    public void OnReturnToMainMenuPressed()
    {
        BattleManager.instance.ExitBattle();
    }
}
