using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjective
{
    public enum OBJECTIVE_TYPE {NONE, LOOT, ESCAPE};

    [SerializeField]
    OBJECTIVE_TYPE _type;

    int progress;
    int requirement;
    bool completed;

    public LevelObjective(OBJECTIVE_TYPE type)
    {
        _type = type;
    }

    public void Init(LevelManager level)
    {
        completed = false;
        progress = 0;
        switch(_type)
        {
            case OBJECTIVE_TYPE.LOOT:
                requirement = level.GetRemainingLootItemCount();
                break;
            case OBJECTIVE_TYPE.ESCAPE:
                requirement = level.GetRemainingPlayerCharacterCount();
                break;
            default:
                requirement = 1;
                break;
        }
    }

    public OBJECTIVE_TYPE GetObjectiveType()
    {
        return _type;
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public void UpdateStatus(LevelManager manager)
    {
        
        switch (_type)
        {
            case OBJECTIVE_TYPE.LOOT:
                progress = requirement - manager.GetRemainingLootItemCount();
                if (progress >= requirement)
                {
                    progress = requirement;
                    completed = true;
                }
                break;
            case OBJECTIVE_TYPE.ESCAPE:
                progress = requirement - manager.GetRemainingPlayerCharacterCount();
                if (progress >= requirement)
                {
                    progress = requirement;
                    completed = true;
                }
                break;
        }
    }

    public int GetProgress()
    {
        return progress;
    }

    public int GetRequirement()
    {
        return requirement;
    }
}
