using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryGuardController : EnemyCharacterController
{
    List<PlayerCharacterController> spottedCharacters;

    public override void Init(LevelManager manager)
    {
        base.Init(manager);
        spottedCharacters = new List<PlayerCharacterController>();
    }

    protected override void Alert(PlayerCharacterController spottedTarget)
    {
        base.Alert(spottedTarget);
    }

    // Update is called once per frame
    void Update()
    {
        spottedCharacters = GetPlayerCharactersInVision();
        if (alerted)
        {
            if (spottedCharacters.Contains(target))
            {
                Debug.Log("Spotted :" + target);
            }
            else
            {
                LoseTarget();
            }
        }
        else
        {
            if (spottedCharacters.Count > 0)
            {
                Alert(spottedCharacters[0]); //TODO: Maybe logic here?
            }
         }
    }
}
