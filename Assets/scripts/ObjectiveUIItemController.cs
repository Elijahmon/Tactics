using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveUIItemController : UIController
{
    LevelObjective _objective;

    [SerializeField]
    GameObject checkMark;
    [SerializeField]
    TextMeshProUGUI label;

    public override void Init()
    {
        gameObject.SetActive(false);
    }

    public void UpdateItem(LevelObjective objective)
    {
        switch(objective.GetObjectiveType())
        {
            case LevelObjective.OBJECTIVE_TYPE.LOOT:
                label.text = string.Format("Items Stolen: {0}/{1} ", objective.GetProgress(), objective.GetRequirement());
                gameObject.SetActive(true);
                break;
            case LevelObjective.OBJECTIVE_TYPE.ESCAPE:
                label.text = string.Format("Characters Escaped: {0}/{1}", objective.GetProgress(), objective.GetRequirement());
                gameObject.SetActive(true);
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
        checkMark.SetActive(objective.IsCompleted());
    }
}
