using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : MonoBehaviour
{
    protected LevelManager _manager;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float visionAngle;
    [SerializeField]
    protected float visionDistance;

    protected bool alive;
    protected bool alerted;
    protected PlayerCharacterController target;

    public virtual void Init(LevelManager manager)
    {
        alive = true;
        _manager = manager;
    }

    public virtual void TakeDamage(int delta)
    {
        if(health - delta <= 0)
        {
            health = 0;
            Die();
        }
        else
        {
            health -= delta;
        }
    }

    protected virtual void Die()
    {
        alive = false;
        //TODO: Die
    }

    protected List<PlayerCharacterController> GetPlayerCharacters()
    {
        return BattleManager.instance.GetPlayerCharacters();
    }

    protected virtual List<PlayerCharacterController> GetPlayerCharactersInVision()
    {
        List<PlayerCharacterController> characters = GetPlayerCharacters();
        List<PlayerCharacterController> spottedCharacters = new List<PlayerCharacterController>();
        foreach(var character in characters)
        {
            if(BattleManager.instance.GetDistanceBetween(character, this) <= visionDistance)
            {
                Vector3 direction = character.transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);
                if(angle <= visionAngle)
                {
                    Debug.DrawRay(transform.position, direction, Color.red, 2f);
                    Debug.Log("Spotted: " + character.name);
                    spottedCharacters.Add(character);
                }
               
            }
        }
        return spottedCharacters;
    }

    protected virtual void Alert(PlayerCharacterController spottedTarget)
    {
        alerted = true;
        target = spottedTarget;
    }

    protected virtual void LoseTarget()
    {
        target = null;
    }
}
