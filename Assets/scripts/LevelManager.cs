using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    BattleManager _battle;

    [SerializeField]
    LevelConfig _config;
    [SerializeField]
    List<LevelObjective> levelObjectives = new List<LevelObjective>(6);
    [SerializeField]
    Transform _origin;
    [SerializeField]
    Transform _characterSpawn;
    [SerializeField]
    List<LootItemController> loot;
    [SerializeField]
    List<ExitController> exits;

    [SerializeField]
    List<EnemyCharacterController> enemies;

    public void Init(BattleManager battle, Transform origin)
    {
        _battle = battle;
        _origin.transform.position = origin.transform.position;
        _battle.SpawnPlayerCharacter(_characterSpawn.position);

        loot = new List<LootItemController>();
        foreach(var lootItem in FindObjectsOfType<LootItemController>())
        {
            loot.Add(lootItem);
            lootItem.Init(this);
        }

        exits = new List<ExitController>();
        foreach(var exit in FindObjectsOfType<ExitController>())
        {
            exits.Add(exit);
            exit.Init(this);
        }

        enemies = new List<EnemyCharacterController>();
        foreach(var enemy in FindObjectsOfType<EnemyCharacterController>())
        {
            enemies.Add(enemy);
            enemy.Init(this);
        }

        levelObjectives = new List<LevelObjective>();
        foreach(var obj in _config.objectives)
        {
            levelObjectives.Add(new LevelObjective(obj));
            levelObjectives[levelObjectives.Count - 1].Init(this);
        }
            
        _battle.UpdateObjectiveUI(levelObjectives);
        

    }

    public void LootItemAquired(LootItemController item)
    {
        //Debug.Log("Looted item " + item.name);
        loot.Remove(item);
        UpdateObjectives();

        Destroy(item.gameObject);
    }

    void ActivateExits()
    {
        Debug.Log("Opening Exits");
        foreach(var exit in exits)
        {
            exit.ToggleActive(true);
        }
    }

    public void ExitReached(PlayerCharacterController character)
    {
        Debug.Log("Character Escaped!");
        _battle.DespawnCharacterEscaped(character);
        UpdateObjectives();
        if(EvaluateVictoryConditions())
        {
            _battle.EndBattleVictory();
        }
    }

    bool EvaluateVictoryConditions()
    {
        bool victory = true;
        bool openExits = true;
        foreach(var objective in levelObjectives)
        {
            if(objective.GetObjectiveType() != LevelObjective.OBJECTIVE_TYPE.NONE)
            {
                if (objective.IsCompleted() == false)
                {
                    if(objective.GetObjectiveType() != LevelObjective.OBJECTIVE_TYPE.ESCAPE)
                    {
                        openExits = false;
                    }
                    victory = false;
                    break;
                }
            }
        }
        if(openExits)
        {
            ActivateExits();
        }
        return victory;
    }

    void UpdateObjectives()
    {
        foreach(var objective in levelObjectives)
        {
            objective.UpdateStatus(this);
            //Debug.Log("Updated Objective " + objective.GetObjectiveType() + " :" + objective.IsCompleted());
        }
        _battle.UpdateObjectiveUI(levelObjectives);
        EvaluateVictoryConditions();
    }

    public void Unload()
    {
        Destroy(this.gameObject);
    }

    public int GetRemainingLootItemCount()
    {
        return loot.Count;
    }

    public int GetRemainingPlayerCharacterCount()
    {
        return _battle.GetPlayerCharacters().Count;
    }
}
