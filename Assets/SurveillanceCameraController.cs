using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCameraController : EnemyCharacterController
{
    [SerializeField]
    float turnSpeed;
    [SerializeField]
    float rotationTime;
    [SerializeField]
    Transform cameraPivot;

    [SerializeField]
    Vector3 rotationTargetA;
    [SerializeField]
    Vector3 rotationTargetB;

    List<PlayerCharacterController> spottedCharacters;
    float timer;

    public override void Init(LevelManager manager)
    {
        base.Init(manager);
    }

    private void Update()
    {
        spottedCharacters = GetPlayerCharactersInVision();
        if (alerted)
        {
            if (spottedCharacters.Contains(target))
            {
                LookAtTarget();
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
            else
            {
                if (timer > rotationTime)
                {
                    FlipDirection();
                }
                else
                {
                    PassiveRotate();
                }
            }
        }
        timer += Time.deltaTime / rotationTime;
    }

    protected override void Alert(PlayerCharacterController spottedTarget)
    {
        base.Alert(spottedTarget);
    }

    protected override void LoseTarget()
    {
        base.LoseTarget();
        alerted = false;
        //Debug.Log("Lost " + Vector3.Distance(cameraPivot.transform.localEulerAngles, rotationTargetA) + " : " + Vector3.Distance(cameraPivot.localEulerAngles, rotationTargetB));
        if (Vector3.Distance(cameraPivot.transform.localEulerAngles, rotationTargetA) < Vector3.Distance(cameraPivot.localEulerAngles, rotationTargetB))
        {
            timer = 0;
        }
        else
        {
            FlipDirection();
        }
    }

    void LookAtTarget()
    {
        
        Vector3 direction = target.transform.position - cameraPivot.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle <= visionAngle)
        {
            cameraPivot.LookAt(target.transform);
        }
        //Quaternion rot = cameraPivot.localRotation;
        //cameraPivot.LookAt(target.transform);
        //cameraPivot.localRotation = Quaternion.Lerp(rot, cameraPivot.localRotation, turnSpeed);
    }

    void FlipDirection()
    {
        Vector3 temp = rotationTargetA;
        rotationTargetA = rotationTargetB;
        rotationTargetB = temp;
        timer = 0;
    }
    void PassiveRotate()
    {
        cameraPivot.localEulerAngles = Vector3.Lerp(rotationTargetA, new Vector3(cameraPivot.eulerAngles.x, rotationTargetB.y, cameraPivot.eulerAngles.z), timer);
    }

    protected override List<PlayerCharacterController> GetPlayerCharactersInVision()
    {
        List<PlayerCharacterController> characters = GetPlayerCharacters();
        List<PlayerCharacterController> spottedCharacters = new List<PlayerCharacterController>();
        foreach (var character in characters)
        {
            if (BattleManager.instance.GetDistanceBetween(character, this) <= visionDistance)
            {
                Vector3 direction = character.transform.position - cameraPivot.position;
                float angle = Vector3.Angle(direction, cameraPivot.forward);
                if (angle <= visionAngle)
                {
                    Debug.DrawRay(transform.position, direction, Color.red, 2f);
                    Debug.Log("Spotted: " + character.name);
                    spottedCharacters.Add(character);
                }

            }
        }
        return spottedCharacters;
    }

}
